using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ADO.Net_StoredProcedure
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            CREATE PROCEDURE [dbo].[Procedure]
	            @p1 int,
	            @p2 varchar(5)
            AS
	            insert into Table1 values(@p1, @p2)
            */

            try
            {
                string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=Experiment;Integrated Security=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string procedureName = "Procedure";
                    using (SqlCommand cmd = new SqlCommand(procedureName, connection))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlParameter parameter;
                        parameter = new SqlParameter("@p1", 6);
                        cmd.Parameters.Add(parameter);
                        parameter = new SqlParameter() { ParameterName = "@p2", Value = "f", DbType = System.Data.DbType.AnsiString };
                        cmd.Parameters.Add(parameter);

                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
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
