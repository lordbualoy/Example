using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Odbc;

namespace DBIsolationLevel
{
    class Program
    {
        static void Main(string[] args)
        {
            Normal();
            Advance();
        }

        static void Normal()
        {
            string sql = "";
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            OdbcConnection connection = new OdbcConnection("DSN=MSMAXX;UID=sa;PWD=seniorsoftsql85");
            OdbcConnection connection2 = new OdbcConnection("DSN=MSMAXX;UID=sa;PWD=seniorsoftsql85");
            connection.Open();
            connection2.Open();
            OdbcTransaction t = connection.BeginTransaction();
            try
            {
                sql = "update unitname set ordinary=1;";
                using (OdbcCommand cmd = new OdbcCommand(sql, connection, t))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.Common.DbException DbEx)
            {
            }

            OdbcTransaction t2 = connection2.BeginTransaction();
            try
            {
                sql = "select * from unitname;";
                using (OdbcCommand cmd = new OdbcCommand(sql, connection2, t2))
                using (OdbcDataAdapter da = new OdbcDataAdapter(cmd))
                {
                    da.Fill(dt2);
                }
            }
            catch (System.Data.Common.DbException DbEx)
            {
            }

            t.Rollback();
            t2.Rollback();
        }

        static void Advance()
        {
            string sql = "";
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            OdbcConnection connection = new OdbcConnection("DSN=MSMAXX;UID=sa;PWD=seniorsoftsql85");
            OdbcConnection connection2 = new OdbcConnection("DSN=MSMAXX;UID=sa;PWD=seniorsoftsql85");
            connection.Open();
            connection2.Open();
            OdbcTransaction t = connection.BeginTransaction();
            try
            {
                sql = "update unitname set ordinary=1;insert into unitname(sysunitid,unitname) values(1000,'aaaa');";
                using (OdbcCommand cmd = new OdbcCommand(sql, connection, t))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.Common.DbException DbEx)
            {
            }

            OdbcTransaction t2 = connection2.BeginTransaction(IsolationLevel.ReadUncommitted);
            try
            {
                sql = "select * from unitname;";
                using (OdbcCommand cmd = new OdbcCommand(sql, connection2, t2))
                using (OdbcDataAdapter da = new OdbcDataAdapter(cmd))
                {
                    da.Fill(dt2);   //จะอ่านสิ่งที่ยังไม่ได้ commit ขึ้นมาด้วย และจะไม่ติด lock
                }
            }
            catch (System.Data.Common.DbException DbEx)
            {
            }

            t.Rollback();
            t2.Rollback();
        }
    }
}
