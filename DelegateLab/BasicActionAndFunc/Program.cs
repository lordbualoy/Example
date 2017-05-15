using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ActionAndFunc
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Func
            //Func<T, TResult> Delegate

            //แบบแรก
            Func<int, string> func1 = delegate(int input)
            {
                return input.ToString();
            };
            //เรียกด้วย invoke หรือ call ชื่อ instance ตรงๆเสมือนเป็น method จริงๆ method หนึ่ง
            string resultString = func1.Invoke(10);
            resultString=func1(11);

            //แบบที่ 2
            Func<int, string> func2 = (int input) => input.ToString();
            resultString = func2.Invoke(20);
            resultString = func2(21);

            //แบบที่ 3
            Func<int, string> func3 = MethodForFunc3;
            resultString = func3.Invoke(30);
            resultString = func3(31);

            //3 input เป็น int 1 return เป็น string
            Func<int, int, int, string> func4 = (a, b, c) => (a + b + c).ToString();
            resultString = func4.Invoke(100, 10, 1);
            resultString = func4(200, 20, 2);

            //0 input เป็น void 1 return เป็น string
            Func<string> func5 = () => "Hello World";
            resultString = func5.Invoke();
            resultString = func5();
            #endregion Func

            #region Action
            //Action<T> Delegate

            //แบบแรก
            Action<int> act1 = delegate(int input)
            {
                Console.WriteLine("This is act1 > input=" + input);
            };
            act1.Invoke(10);
            act1(11);

            //แบบที่ 2
            Action<int> act2 = (int input) => Console.WriteLine("This is act2 > input=" + input);
            act2.Invoke(20);
            act2(21);

            //แบบที่ 3
            Action<int> act3 = MethodForAct3;
            act3.Invoke(30);
            act3(31);

            //3 input เป็น int, return เป็น void
            Action<int, int, int> act4 = (a, b, c) => Console.WriteLine("This is act4 > input=" + a + "," + b + "," + c);
            act4.Invoke(100, 10, 1);
            act4(200, 20, 1);

            //input เป็น void, return เป็น void
            Action act5 = () => Console.WriteLine("This is act5");
            act5.Invoke();
            act5();
            #endregion Action
        }

        static string MethodForFunc3(int input)
        {
            return input.ToString();
        }

        static void MethodForAct3(int input)
        {
            Console.WriteLine("This is MethodForAct3 > input=" + input);
        }
    }
}
