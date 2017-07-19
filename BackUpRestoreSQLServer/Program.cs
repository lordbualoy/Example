using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace BackUpRestoreSQLServer
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=localhost;Initial Catalog=master;User id=sa;Password=seniorsoftsql85;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                try
                {
                    string
                    tsql = "BACKUP DATABASE {0} TO {1} WITH {2};";
                    tsql = string.Format(tsql, "MSMAXX", "DISK='C:\\box\\test.bak'", "INIT,CHECKSUM");
                    using (SqlCommand cmd = new SqlCommand(tsql, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    tsql = "RESTORE DATABASE {0} FROM {1} WITH {2};";

                    //แบบปกติ (backup จาก MSMAXX แล้ว restore เป็น MSMAXX เหมือนเดิม)
                    //tsql = string.Format(tsql, "MSMAXX", "DISK='C:\\box\\test.bak'", "RECOVERY,REPLACE");

                    //แบบเปลี่ยนชื่อ (backup จาก MSMAXX แล้วจะ restore เป็นชื่ออื่น เช่น MSMAXX2)
                    string originalDBName = "MSMAXX";
                    string newDBName = "MSMAXX2";
                    string with = "RECOVERY,REPLACE"
                        + ",MOVE '{0}' TO 'C:\\Program Files\\Microsoft SQL Server\\MSSQL12.SQLEXPRESS2014\\MSSQL\\DATA\\{1}.mdf'"
                        + ",MOVE '{0}_Log' TO 'C:\\Program Files\\Microsoft SQL Server\\MSSQL12.SQLEXPRESS2014\\MSSQL\\DATA\\{1}_Log.ldf'"
                        ;
                    with = string.Format(with, originalDBName, newDBName);
                    tsql = string.Format(tsql, newDBName, "DISK='C:\\box\\test.bak'", with);

                    using (SqlCommand cmd = new SqlCommand(tsql, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException e)
                {
                }
            }
        }
    }
}
