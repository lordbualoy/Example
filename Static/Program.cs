using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Static
{
    class Program
    {
        static void Main(string[] args)
        {
            //int get = test.a;
            //string gets = test.b;
            //get = test.teststr.a;
            //gets = test.teststr.b;

            //test.a = 50;
            //test.b = "50";
            //test.teststr.a=100;
            //test.teststr.b="200";

            //get = test.a;
            //gets = test.b;
            //get = test.teststr.a;
            //gets = test.teststr.b;
            access();
            set();
            access();
            test.method();

            abc a = new abc();
            def d = new def();
        }

        static void set()
        {
            test.a = 50;
            test.b = "50";
            test.teststr.a = 100;
            test.teststr.b = "200";
        }

        static void access()
        {
            int get = test.a;
            string gets = test.b;
            get = test.teststr.a;
            gets = test.teststr.b;
        }
    }

    public class abc
    {
        protected Int32 q;
        protected System.Data.DataTable dt;
    }

    public class def : abc
    {
        q=20;
        //dt //= new System.Data.DataTable();
        //public def()
        //{
        //    dt = new System.Data.DataTable();
        //}
    }

    public static class test
    {
        public static int a = 10;
        public static string b = "10";
        public static System.Data.DataTable qqqq2;

        public struct teststr
        {
            public static int a = 20;
            public static string b = "20";
        }

        public static void method()
        {
            System.Data.DataTable qqqq = new System.Data.DataTable();
            qqqq2 = qqqq;
            qqqq.Columns.Add("111",typeof(Int32));
            qqqq.Columns.Add("222",typeof(Int32));
            System.Data.DataRow dr=qqqq.NewRow();
            dr[0] = 1;
            dr[1] = 2;
            qqqq.Rows.Add(dr);
        }
    }
}
