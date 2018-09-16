using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

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
