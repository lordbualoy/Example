using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace DataTable_SaveTo_And_LoadFrom_File
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable dt = new DataTable();
            DataRow dr;
            dt.TableName = "test";
            dt.Columns.Add("col1", typeof(int));
            dt.Columns.Add("col2", typeof(int));
            dt.Columns.Add("col3", typeof(int));

            dr = dt.NewRow();
            dr["col1"] = 1;
            dr["col2"] = 10;
            dr["col3"] = 100;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["col1"] = 2;
            dr["col2"] = 10;
            dr["col3"] = 100;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["col1"] = 3;
            dr["col2"] = 10;
            dr["col3"] = 100;
            dt.Rows.Add(dr);

            dt.WriteXml("datatable.xml",XmlWriteMode.WriteSchema);

            DataTable dt2 = new DataTable();
            dt2.ReadXml("datatable.xml");
        }
    }
}
