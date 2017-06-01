using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Odbc;

namespace ADO.Net_ODBCCommand_Parameters
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string connectionString = "DSN=FBMAXX;UID=seniorsoft;PWD=MySenior;Role=ProMaxx";
                using (OdbcConnection connection = new OdbcConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM UNITNAME WHERE SYSUNITID IN (?,?,?);";
                    using (OdbcCommand cmd = new OdbcCommand(sql, connection))
                    using (OdbcDataAdapter adapter = new OdbcDataAdapter(cmd))
                    {
                        OdbcParameter parameter;
                        parameter = new OdbcParameter("p1", 1);
                        cmd.Parameters.Add(parameter);
                        parameter = new OdbcParameter(name: "p2", value: 2);
                        cmd.Parameters.Add(parameter);
                        parameter = new OdbcParameter() { ParameterName = "p3", Value = 3, DbType = DbType.Int32 };
                        cmd.Parameters.Add(parameter);

                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception e)
            {
            }
            finally
            {
            }
        }
    }
}
