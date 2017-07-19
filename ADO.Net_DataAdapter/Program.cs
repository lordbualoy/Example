﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Odbc;

namespace ADO.Net_DataAdapter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string connectionString =  "DSN=FBMAXX;UID=seniorsoft;PWD=MySenior;Role=ProMaxx";
                using (OdbcConnection connection = new OdbcConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM UNITNAME;";
                    using (OdbcCommand cmd = new OdbcCommand(sql, connection))
                    using (OdbcDataAdapter adapter = new OdbcDataAdapter(cmd))
                            //The OdbcDataAdapter does not automatically generate the SQL statements required to reconcile changes made to a DataSet associated with the data source.
                            //However, you can create an OdbcCommandBuilder object that generates SQL statements for single-table updates by setting the SelectCommand property of the OdbcDataAdapter.
                            //The OdbcCommandBuilder then generates any additional SQL statements that you do not set.
                    using (OdbcCommandBuilder builder = new OdbcCommandBuilder(adapter))
                            //When this constructor of OdbcCommandBuilder is invoked, the OdbcCommandBuilder registers itself as a listener for RowUpdating events that are generated by the OdbcDataAdapter specified as an argument of this constructor.
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        DataRowCollection dr1 = dt.Rows;
                        dt.Rows[0][2] = "A";
                        dt.Rows[1].Delete();

                        adapter.RowUpdating += OnRowUpdatingListener;
                        using (OdbcTransaction t = connection.BeginTransaction())
                        {
                            cmd.Transaction = t;
                            try
                            {
                                adapter.Update(dt);
                            }
                            catch (OdbcException OdbcEx)
                            {
                                t.Rollback();
                                throw OdbcEx;
                            }
                            t.Commit();
                            cmd.Transaction = adapter.DeleteCommand.Transaction = adapter.UpdateCommand.Transaction = adapter.InsertCommand.Transaction = null;
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

        static void OnRowUpdatingListener(object sender, System.Data.Common.RowUpdatingEventArgs e)
        {
            StatementType statementType = e.StatementType;
            UpdateStatus updateStatus = e.Status;
            string commandText = e.Command.CommandText;
            OdbcParameter[] parameters = new OdbcParameter[e.Command.Parameters.Count]; e.Command.Parameters.CopyTo(parameters, 0);
        }
    }
}