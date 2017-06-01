using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectInitializerAndAlternativeClassInitialization
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass myClass;

            myClass = new MyClass();                                //
            myClass.ID = 0;                                         //Basic Class Initialization
            myClass.Name = "Zero";                                  //

            myClass = new MyClass() { ID = 10, Name = "Ten" };      //Object Initializer

            myClass = new MyClass(id: 20, name: "Twenty");          //Named Arguments
        }

        class MyClass
        {
            public int ID;
            public string Name;

            public MyClass() { }

            public MyClass(int id, string name)
            {
                ID = id;
                Name = name;
            }
        }
    }
}
