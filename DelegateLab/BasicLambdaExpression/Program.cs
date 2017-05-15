using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LambdaExpression
{
    class Program
    {
        //Declaration of Delegate ::= delegate <returnType> <delegateName> ([<argument>{,<argument>}]);
        //<returnType> ::= <type>
        delegate int DelegateDemo1(int i);
        delegate string[] DelegateDemo2(int i);
        delegate int DelegateDemo3(int i, int j, int k);
        delegate void DelegateDemo4();
        delegate void DelegateDemo5(int i);
        delegate int DelegateDemo6();
        delegate bool DelegateDemo7(int i, int j);
        //จากตัวอย่างข้างบน DelegateDemo1 และ DelegateDemo2 จะกลายเป็น type ไว้ประกาศแบบตัวแปร
        //โดยที่การประกาศ delegate ถือเป็น Type (ไม่ได้เป็นแค่่ Instance ของ Type) จึงไม่สามารถประกาศใน method ได้ (เหมือนเราไม่สามารถประกาศ class event struct enum ต่างๆใน method ได้)

        static void Main(string[] args)
        {
            //Initialization of Delegate ::= <delegateName> = <inputParameters> => <code>;
            //<delegateName> ::= ชื่อ Delegate ที่จะถูกใช้เหมือนเป็น <type> <type> หนึ่ง
            //<inputParameters> ::= <argument> | (<argument>{,<argument>})
            //<argument> ::= [<type>] ชื่อตัวแปร
            //<type> ::= ชนิดของตัวแปร
            //<code> ::= \{ code หลายๆบรรทัด \} | code บรรทัดเดียว
            DelegateDemo1 demo1 = i => i * 2;
            int resultInt=demo1(10);
            //จากตัวอย่างข้างบน demo1 คือ instance หนึ่งของ Type DelegateDemo1 ที่เราได้ประกาศไปนอก method
            //โดยจะมี input เป็น i โดยเอา i ไป *2 แล้ว return กลับมาผ่าน demo1

            DelegateDemo2 demo2 = input =>
            {
                string data = input.ToString();
                string[] output = new string[3] { data, data, data };
                return output;
            };
            string[] resultStringArr = demo2(4);
            //จากตัวอย่างข้างบน demo2 คือ instance หนึ่งของ Type DelegateDemo2 ที่เราได้ประกาศไปนอก method
            //โดยจะมี input เป็นตัวแปรชื่อ input โดยจะเอา input ไปแปลงเป็น string[] แล้ว return กลับออกมา
            //จะเห็นว่าสิ่งที่ return จะไม่เกี่ยวกับ input => code , ค่า return ไม่ได้กลับมายุ่งกับตัว input


            //multiple inputs
            DelegateDemo3 demo3 = (a, b, c) => a + b + c;
            resultInt = demo3(100, 10, 1);

            //explicitly typed input
            demo3 = (int a, int b, int c) => a*2 + b*2 + c*2;
            resultInt = demo3(100, 10, 1);

            //void parameter void return
            DelegateDemo4 demo4 = () => Console.WriteLine("This is Void Parameter and Void Return");
            demo4();

            //int parameter void return
            DelegateDemo5 demo5 = (int i) => Console.WriteLine("This is Int32 Parameter and Void Return > Int32 parameter = " + i);
            demo5(10);

            //void parameter int return
            DelegateDemo6 demo6 = () => 1234;
            resultInt = demo6();
            //void parameter int return alternate
            demo6 = () => { return 5678; };
            resultInt = demo6();

            //bool return (Comparison)
            DelegateDemo7 demo7 = (i, j) => i > j;
            bool resultBool=demo7(1, 2);
            resultBool = demo7(2, 1);
        }
    }
}
