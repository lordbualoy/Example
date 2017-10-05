using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtensionMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "1,000";
            int value = input.ParseToInt();

            ConsoleKey
            consoleKey = "A".ParseToEnumConsoleKey();
            consoleKey = "B".ParseToEnumConsoleKey();
            consoleKey = "Backspace".ParseToEnumConsoleKey();
        }
    }

    //ต้องประกาศ static class ไว้ชั้นนอกสุด อยู่ใต้แค่ namespace เท่านั้น
    static class ExtensionMethods
    {
        public static int ParseToInt(this string value)
        //     ^^^^^^                ^^^^^^^^^^^
        //  จุดสำคัญคือตรงนี้           จุดสำคัญคือตรงนี้
        //  ต้องเป็น static          ต้องมีคำว่า this และ type string หลังจาก this หมายถึงว่าจะให้ method นี้ไปเป็น extension method ของ type ไหน
        //เวลาใช้งานจะเป็นแบบนี้
        //    string input = "1,000";
        //    int value = input.ParseToInt();
        //ไม่ใช่แบบนี้
        //    string.ParseToInt("1,000");
        {
            return int.Parse(value, System.Globalization.NumberStyles.AllowThousands);
        }

        public static ConsoleKey ParseToEnumConsoleKey(this string consoleKey)
        {
            switch (consoleKey)
            {
                case "A":
                    return ConsoleKey.A;
                case "B":
                    return ConsoleKey.B;
                default:
                    return (ConsoleKey)Enum.Parse(typeof(ConsoleKey), consoleKey);
            }
        }
    }
}
