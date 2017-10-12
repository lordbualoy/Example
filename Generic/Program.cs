using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generic
{
    class Program
    {
        static GenericDelegate_Example.Example1<int> test7;

        static void Main(string[] args)
        {
            GenericClass_Example1.GenericClass<int> test1 = new GenericClass_Example1.GenericClass<int>(10);
            test1.Data = 20;

            GenericClass_Example2.GenericClass<SampleClass, SampleClass2> test2 =
                new GenericClass_Example2.GenericClass<SampleClass, SampleClass2>(new SampleClass(), new SampleClass2());

            GenericClass_Example3.GenericClass<string> test3 = new GenericClass_Example3.GenericClass<string>("1234");
            test3.Add(5);



            GenericInterface_Example.GenericInterface<string> test4 = new GenericInterface_Example.ClassExample1<string> { data = "aaaa" };
            GenericInterface_Example.ClassExample2 test5 = new GenericInterface_Example.ClassExample2 { data = "aaaa" };
            GenericInterface_Example.GenericInterface<string> test5_1 = new GenericInterface_Example.ClassExample2 { data = "aaaa" };
            //GenericInterface_Example.GenericInterface<int> test5_2 = new GenericInterface_Example.ClassExample2 { data = "aaaa" };    //Error
            GenericInterface_Example.GenericInterface<string> test6 = new GenericInterface_Example.ClassExample3<int> { data = "aaaa", data2 = 10 };
            GenericInterface_Example.ClassExample3<int> test6_1 = new GenericInterface_Example.ClassExample3<int> { data = "aaaa", data2 = 10 };



            test7 = GenericDelegate_Example.ExampleMethod1;
            test7(10);
        }
    }

    class SampleClass
    {
    }

    class SampleClass2
    {
    }

    class GenericClass_Example1
    {
        public class GenericClass<T>
        {
            public T Data;

            public GenericClass(T data)
            {
                Data = data;
            }
        }
    }

    class GenericClass_Example2
    {
        public class GenericClass<T1, T2>
            where T1 : SampleClass
            where T2 : SampleClass2
        {
            public T1 Data1;
            public T2 Data2;

            public GenericClass(T1 data1, T2 data2)
            {
                Data1 = data1;
                Data2 = data2;
            }
        }
    }

    class GenericClass_Example3
    {
        //อันนี้เรียกว่า closed constructed type
        //สิ่งที่เกิดขึ้นคือ GenericClass จะเป็น List ของ int แต่สามารถ hold Generic type มาเก็บใน Data ได้ โดยส่ง Generic type ผ่าน constructor เข้ามา
        //คือจะเป็นทั้ง Class ที่ hold Generic type และเป็น List ของ int ไปพร้อมๆกัน
        public class GenericClass<T> : List<int>
        {
            public T Data;

            public GenericClass(T data)
            {
                Data = data;
            }
        }
    }

    class GenericClass_Example4
    {
        //อันนี้เรียกว่า open constructed type
        public class GenericClass<T> : List<T>
        {
        }
    }

    class GenericClass_Example5
    {
        //อันนี้เรียกว่า concrete type
        public class GenericClass<T> : SampleClass
        {
        }
    }

    class GenericClass_Example6
    {
        //แบบนี้จะ Error
        //public class GenericClass : List<T>
        //{
        //}
    }

    class GenericInterface_Example
    {
        public interface GenericInterface<T>
        {
            T data { get; }
        }

        public class ClassExample1<T> : GenericInterface<T>
        {
            public T data { get; set; }
        }

        public class ClassExample2 : GenericInterface<string>
        {
            public string data { get; set; }
        }

        public class ClassExample3<T> : GenericInterface<string>
        {
            public string data { get; set; }
            public T data2 { get; set; }
        }
    }

    class GenericMethod_Example
    {
        public static void Example1<T>(T t)
        {
            return;
        }

        public static T Example2<T>(T t)
        {
            return t;
        }

        public static void Example3<T1,T2>(T1 t, T2 t2)
        {
            return;
        }

        public static void Example4<T1, T2>(T1 t, T2 t2)
            where T1 : SampleClass
            where T2 : SampleClass2
        {
            return;
        }
    }

    class GenericDelegate_Example
    {
        public delegate void Example1<T>(T t);

        public static void ExampleMethod1(int i)
        {
            return;
        }
    }
}
