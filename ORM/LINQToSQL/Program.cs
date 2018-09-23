using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQToSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            //LINQ To SQL Class (*.dbml) ควรจะใช้ file เดียวทั้ง database
            //ทีนี้เวลาจะลาก Table เข้ามาสามารถเลือกหลายๆ table ใน server explorer แล้วลากมาทีเดียวได้
            //แล้วก็ถ้าวันหลังอยากเพิ่ม table อื่นๆก็สามารถลากมาใส่เพิ่มได้ จะเป็นการ append

            const string connectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=Experiment;Integrated Security=True";
            using (LINQClassDataContext context = new LINQClassDataContext(connectionString))
            {
                //CRUD
                IEnumerable<Table1> table1Rows = from t in context.Table1s  //the query is deferred
                                             where t.Id >= 4
                                             orderby t.Id descending
                                             select t;
                Table1 _1stRow = table1Rows.ElementAtOrDefault(0);          //the query got executed here
                _1stRow.Name = "newname";

                context.Table1s.InsertOnSubmit(new Table1 { Id = 7, Name = "g" });

                context.SubmitChanges();

                _1stRow = (from t in context.Table1s
                          where t.Id == 7
                          select t).FirstOrDefault();
                context.Table1s.DeleteOnSubmit(_1stRow);
                context.SubmitChanges();



                //Inner Join
                //select t1.MaterialID, t1.MaterialName, t2.ItemID, t2.ItemName, t2.MaterialID as ItemMaterialID
                //from material t1
                //inner join item t2
                //on t1.MaterialID = t2.MaterialID
                var joined = from t1 in context.Materials
                             join t2 in context.Items
                             on t1.MaterialID equals t2.MaterialID
                             select new { t1.MaterialID, t1.MaterialName, t2.ItemID, t2.ItemName, ItemMaterialID = t2.MaterialID };
                foreach (var e in joined) { }

                //Cross Join
                //select t1.MaterialID, t1.MaterialName, t2.ItemID, t2.ItemName, t2.MaterialID as ItemMaterialID
                //from material t1
                //cross join item t2
                var xjoined = from t1 in context.Materials
                              from t2 in context.Items
                              select new { t1.MaterialID, t1.MaterialName, t2.ItemID, t2.ItemName, ItemMaterialID = t2.MaterialID };
                foreach (var e in xjoined) { }

                //Left Join
                //select t1.MaterialID, t1.MaterialName, t2.ItemID, t2.ItemName, t2.MaterialID as ItemMaterialID
                //from material t1
                //left join item t2
                //on t1.MaterialID = t2.MaterialID
                var ljoined = from t1 in context.Materials
                              join t2 in context.Items
                              on t1.MaterialID equals t2.MaterialID
                                into temp
                                from j in temp.DefaultIfEmpty()
                             select new { t1.MaterialID, t1.MaterialName, j.ItemID, j.ItemName, ItemMaterialID = j.MaterialID };
                foreach (var e in ljoined) { }



                //return as IEnumerable vs IQueryable
                IEnumerable< Table1 > ienum = from t in context.Table1s
                                               where t.Id >= 4
                                               select t;
                _1stRow = ienum.ElementAtOrDefault(0);     //can use ElementAtOrDefault

                IQueryable<Table1> iqueryable = from t in context.Table1s
                                                where t.Id >= 4
                                                select t;
                try
                {
                    _1stRow = iqueryable.FirstOrDefault();         //can use FirstOrDefault
                    _1stRow = iqueryable.ElementAtOrDefault(0);     //cannot use ElementAtOrDefault
                }
                catch { }



                //IQueryable vs IOrderedQueryable
                //no order by returns IQueryable
                var iqueryable1 = from t in context.Table1s
                                where t.Id >= 4
                                select t;

                //has order by returns IOrderedQueryable
                var iqueryable2 = from t in context.Table1s
                                  where t.Id >= 4
                                  orderby t.Id descending
                                  select t;



                //transaction
                context.Connection.Open();
                context.Transaction = context.Connection.BeginTransaction();
                try
                {
                    context.Table1s.InsertOnSubmit(new Table1 { Id = 1, Name = "a" });
                    context.SubmitChanges();
                    context.Transaction.Commit();
                }
                catch (Exception)
                {
                    context.Transaction.Rollback();
                }
                context.Connection.Close();
            }

            using (Custom.CustomDataContext context = new Custom.CustomDataContext(connectionString))
            {
                //CRUD
                IEnumerable<Custom.Table1> table1Rows = from t in context.Table1Rows  //the query is deferred
                                                 where t.Id >= 4
                                                 orderby t.Id descending
                                                 select t;
                Custom.Table1 _1stRow = table1Rows.ElementAtOrDefault(0);          //the query got executed here
                _1stRow.Name = "newname2";

                context.Table1Rows.InsertOnSubmit(new Custom.Table1 { Id = 7, Name = "g" });

                context.SubmitChanges();

                _1stRow = (from t in context.Table1Rows
                           where t.Id == 7
                           select t).FirstOrDefault();
                context.Table1Rows.DeleteOnSubmit(_1stRow);
                context.SubmitChanges();
            }
        }
    }
}
