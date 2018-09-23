using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Transactions;

namespace ADO.Net_SqlCommand_Parameters
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=Experiment;Integrated Security=True;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = "INSERT INTO TABLE1 VALUES (@Id, @Name);";
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        SqlParameter parameter;
                        parameter = new SqlParameter("@Id", 5);
                        cmd.Parameters.Add(parameter);
                        parameter = new SqlParameter { ParameterName = "@Name", Value = "e", DbType = System.Data.DbType.AnsiString };
                        cmd.Parameters.Add(parameter);

                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                }

                using (TransactionScope scope = new TransactionScope())     //it's seems the compiler magic has allowed the TransactionScope to know which connection's transaction to use without the need to explicitly stated
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string sql = "INSERT INTO TABLE1 VALUES (@Id, @Name);";
                        using (SqlCommand cmd = new SqlCommand(sql, connection))
                        {
                            SqlParameter parameter;
                            parameter = new SqlParameter("@Id", 7);
                            cmd.Parameters.Add(parameter);
                            parameter = new SqlParameter { ParameterName = "@Name", Value = "h", DbType = System.Data.DbType.AnsiString };
                            cmd.Parameters.Add(parameter);

                            connection.Open();
                            cmd.ExecuteNonQuery();
                            connection.Close();

                            parameter = new SqlParameter("@Id", 1);
                            cmd.Parameters.Add(parameter);
                            parameter = new SqlParameter { ParameterName = "@Name", Value = "a", DbType = System.Data.DbType.AnsiString };
                            cmd.Parameters.Add(parameter);

                            connection.Open();

                            try
                            {
                                cmd.ExecuteNonQuery();
                                scope.Complete();           //this method will set the consistency bit in scope to true from the initial value of false; if it is false the transaction will rollback and commit if it is true
                            }
                            catch (SqlException) { throw; }
                            finally
                            {
                                connection.Close();
                            }
                        }
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
