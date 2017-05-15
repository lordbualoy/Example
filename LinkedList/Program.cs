using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Collections.Generic.LinkedList<Test> linkedList = new LinkedList<Test>();
            linkedList.AddLast(new Test(1));
            linkedList.AddLast(new Test(2));
            linkedList.AddLast(new Test(3));
            linkedList.AddLast(new Test(4));
            linkedList.AddLast(new Test(5));
            linkedList.AddLast(new Test(6));
            linkedList.AddLast(new Test(7));

            System.Collections.Generic.LinkedListNode<Test> node = linkedList.First;
            node = node.Next;
            node = node.Next;
            node = node.Next;
            node = node.Next;
            int result=node.Value.get_a();
        }

        class Test
        {
            private int a;

            public Test(int a)
            {
                this.a = a;
            }

            public int get_a()
            {
                return a;
            }
        }
    }
}
