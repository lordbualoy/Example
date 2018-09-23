using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQToSQL.Custom
{
    public class CustomDataContext : System.Data.Linq.DataContext
    {
        public CustomDataContext(string cs) : base(cs) { }

        public System.Data.Linq.Table<Table1> Table1Rows;
        public System.Data.Linq.Table<Table2> Table2Rows;
    }

    [System.Data.Linq.Mapping.Table(Name = "Table1")]
    public class Table1
    {
        [System.Data.Linq.Mapping.Column(Name = "Id", DbType = "Int NOT NULL", IsPrimaryKey = true)]
        public int Id { get; set; }
        [System.Data.Linq.Mapping.Column(Name = "Name", DbType = "VarChar(50) NOT NULL", CanBeNull = false)]
        public string Name { get; set; }
    }

    [System.Data.Linq.Mapping.Table(Name = "Table2")]
    public class Table2
    {
        [System.Data.Linq.Mapping.Column(Name = "Id", DbType = "Int NOT NULL", IsPrimaryKey = true)]
        public int Id { get; set; }
        [System.Data.Linq.Mapping.Column(Name = "Name", DbType = "VarChar(50) NOT NULL", CanBeNull = false)]
        public string Name { get; set; }
    }
}
