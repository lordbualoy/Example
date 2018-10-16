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

                    string procedureName2 = "_Proc";
                    using (SqlCommand cmd = new SqlCommand(procedureName2, connection))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        //Input Argument
                        cmd.Parameters.Add(new SqlParameter { ParameterName = "@Param", DbType = System.Data.DbType.Int32, Value = 5, });

                        //Ref Argument
                        SqlParameter _refParam = new SqlParameter { ParameterName = "@RefParam", DbType = System.Data.DbType.Int32, Direction = System.Data.ParameterDirection.Output };
                        cmd.Parameters.Add(_refParam);

                        //Return Code Argument
                        SqlParameter _returnCode = new SqlParameter { Direction = System.Data.ParameterDirection.ReturnValue };
                        cmd.Parameters.Add(_returnCode);

                        connection.Open();
                        object scalarResult = cmd.ExecuteScalar();
                        int? resultSet = null;
                        if (scalarResult != null && scalarResult != DBNull.Value)
                            resultSet = (int)scalarResult;
                        int refParam = (int)_refParam.Value;
                        int returnCode = (int)_returnCode.Value;
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
