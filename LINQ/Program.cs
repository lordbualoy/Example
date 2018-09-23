using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            //ทั้ง Yield1 ถึง Yield6 จะยังไม่เข้า method จริงๆ แต่จะไปเข้าจริงๆตอนที่ถูก iterate ตรง foreach
            //In a query that returns a sequence of values, the query variable itself never holds the query results and only stores the query commands. Execution of the query is deferred until the query variable is iterated over in a foreach loop. This is known as deferred execution
            //var y1 = YieldReturn.Yield1();
            //var y2 = YieldReturn.Yield2();
            var y3 = YieldReturn.Yield3();
            var y4 = YieldReturn.Yield4();
            var y5 = YieldReturn.Yield5();
            var y6 = YieldReturn.Yield6();

            foreach (int i in YieldReturn.Yield3()) { }
            foreach (int i in y3) { }
            foreach (int i in y4) { }
            foreach (int i in y5) { }
            foreach (int i in y6) { }
            
            var y7NonYield = YieldReturn.Yield7NonYield();
            YieldReturn.Double(y7NonYield); //all members in the collection will be doubled as expected
            var y7 = YieldReturn.Yield7();
            YieldReturn.Double(y7);         //all members in the collection won't be doubled as expected
            var y7wrapped = YieldReturn.Yield7Wrapper(y7);
            YieldReturn.Double(y7wrapped);  //all members in the collection will be doubled

            //ข้อสรุปของ yield return คือ เวลาทำใน pattern yield return คือเหมือนหลังจาก call method เช่น YieldReturn.Yield7() ไปแล้วเราจะได้ค่า return ที่ทำตัวเหมือน delegate กลับมา แต่เป็น type IEnumerable อยู่ โดยที่ทุกครั้งที่เรา iterate ผ่าน collection
            //จะเกิดการ invoke delegate นั้นๆ ที่ข้างในเป็น yield return new Sample { Data = something } ซึ่งจะเป็น instance ใหม่เสมอ (value equal กับครั้งก่อนๆ แต่ไม่ reference equal กับครั้งก่อนๆที่อาจจะเคย call YieldReturn.Yield7())
            //เลยทำให้ถ้าไม่มีตัว wrap แบบ YieldReturn.Yield7Wrapper(y7) พอเรา set ค่าแบบ reference ลงไปแล้วกลับหายเมื่อ access ใหม่


            List<int> linqImitation = new List<int> { 1,2,3,4 };
            var filteredLinqImitation = linqImitation.GetAll(x => x % 2 == 0);  //โดย GetAll จะมีปัญหาเมื่อ set ค่าแบบ reference ลงไปแล้วกลับหายเมื่อ access ใหม่ เหมือนตัวอย่างก่อน
            foreach (var f in filteredLinqImitation) { };

            List<int> linq = new List<int> { 1, 2, 3, 4 };
            var filteredLinq = linq.Where(x => x % 2 == 0);  //Where ของ LINQ ก็ทำงานเหมือน GetAll ที่ทำ imitate ไว้ในตัวอย่าง
            foreach (var f in filteredLinq) { };

            //same as linq.Where(x => x % 2 == 0); but written in LINQ expression
            var filteredLinq2 = from x in linq
                                where x % 2 == 0
                                select x;

            List<Sample> linq2 = new List<Sample> {
                new Sample{ Data = 1, Data2 = 5, },
                new Sample{ Data = 2, Data2 = 6, },
                new Sample{ Data = 3, Data2 = 7, },
                new Sample{ Data = 4, Data2 = 8, },
            };
            var filteredLinq3 = from x in linq2
                                where x.Data % 2 == 0
                                select new { x.Data2 };     //select new anonymous type that were derived from Sample
        }
    }
    
    class Sample
    {
        public int Data { get; set; }
        public int Data2 { get; set; }
    }
}
