using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicEvent
{
    class Program
    {
        //[<modifiers>] event <delegateType> <name>;
        //<modifiers> ::= <modifier>{ <modifier>}
        //<modifier> ::= abstract | new | override | static | virtual | extern | public | protected | private | internal
        //<delegateType> ::= Type ของ delegate ที่ .Net Framework อาจจะมีอยู่แล้วเช่น EventHandler หรือที่เราประกาศเองเช่น delegate void ExampleDelegate () ตรงนี้ก็จะเป็น EventHandler หรือ ExampleDelegate ก็ได้
        //<name> ::= ชื่อ event

        delegate void MyEventSignature(int i);
        static event MyEventSignature MyEvent;
        static void Main(string[] args)
        {
            //Subscribe method ที่ได้ประกาศไว้
            MyEvent += Method1;
            MyEvent += Method2;
            MyEvent += Method3;

            MyEventSignature subscriberExisted = MyEvent;
            if (subscriberExisted != null)
            {
                MyEvent.Invoke(10);
            }
            else
            {
                Console.WriteLine("Event has no subscribers!");
            }
        }

        static void Method1(int i)
        {
            Console.WriteLine("This is Method1 argument int i="+i);
        }

        static void Method2(int i)
        {
            Console.WriteLine("This is Method2 argument int i=" + i);
        }

        static void Method3(int i)
        {
            Console.WriteLine("This is Method3 argument int i=" + i);
        }
    }
}
