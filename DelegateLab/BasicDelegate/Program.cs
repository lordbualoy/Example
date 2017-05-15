using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegateNameSpace
{
    class DelegateTest
    {
        //Declaration of Delegate ::= delegate <returnType> <delegateName> ([<argument>{,<argument>}]);
        //<returnType> ::= <type>
        //<argument> ::= [<type>] ชื่อตัวแปร
        //<type> ::= ชนิดของตัวแปร
        delegate double MathAction(double num);
        //จากตัวอย่างข้างบน MathAction จะกลายเป็น type ไว้ประกาศแบบตัวแปร
        //โดยที่การประกาศ delegate ถือเป็น Type (ไม่ได้เป็นแค่่ Instance ของ Type) จึงไม่สามารถประกาศใน method ได้ (เหมือนเราไม่สามารถประกาศ class event struct enum ต่างๆใน method ได้)

        // Regular method that matches signature:
        static double Double(double input)
        {
            return input * 2;
        }

        static void Main()
        {
            // Instantiate delegate with named method:
            MathAction ma = Double;

            // Invoke delegate ma:
            double multByTwo = ma(4.5);
            Console.WriteLine("multByTwo: {0}", multByTwo);

            // Instantiate delegate with anonymous method:
            MathAction ma2 = delegate(double input)
            {
                return input * input;
            };

            // Invoke delegate ma:
            double square = ma2(5);
            Console.WriteLine("square: {0}", square);

            // Instantiate delegate with lambda expression
            MathAction ma3 = s => s * s * s;

            // Invoke delegate ma:
            double cube = ma3(4.375);
            Console.WriteLine("cube: {0}", cube);

            //ข้อสังเกตจากการ assign delegate จะพบว่าเราสรุปการ assign delegate ได้ว่า
            //เอา delegate ไว้ฝั่งซ้ายอยู่ก่อน = ฝั่งขวาขอให้ return เป็น delegate มาก็จะ assign ผ่านได้
            //เช่น
            //delegate(...) { ...; }; จะ return เป็น delegate
            //หรือ
            //s => s * s * s; จะ return เป็น delegate
            //หรือ
            //() => { return; }; จะ return เป็น delegate

            //multicast delegate #1 ผลลัพธ์การ return ของตัวแรกจะหายไป
            MathAction ma4 = ma + ma2;
            double multi=ma4(10);

            //multicast delegate #2 ใช้วน foreach call ทีละ function
            Delegate[] maList = ma4.GetInvocationList();
            foreach (MathAction eachMathAction in maList)
            {
                multi = eachMathAction(10);
            }
        }
    }
}
