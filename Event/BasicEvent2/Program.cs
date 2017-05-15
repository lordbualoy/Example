using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicEvent2
{
    class Program
    {
        static void Main(string[] args)
        {
            MyEventClass instance = new MyEventClass();
            //Subscribe method ที่ได้ประกาศไว้
            instance.ThresholdReached += Method1;
            instance.ThresholdReached += Method2;
            instance.ThresholdReached += Method3;

            //call method ที่จะทำ data++ จนกว่าจะถึง threshold
            int currentData;
            currentData = instance.Add();
            currentData = instance.Add();
            currentData = instance.Add();   //จังหวะนี้จะถึง threshold และ trigger event "ThresholdReached" ส่งผลให้ event "ThresholdReached" ไป notify Method1,Method2,Method3 ที่ได้ subscribe ใน event นี้ไว้
        }

        static void Method1(int i)
        {
            Console.WriteLine("This is Method1 argument int i=" + i);
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

    class MyEventClass
    {
        //instance constants
        private const int threshold = 3;

        //instance variables
        public delegate void MyEventSignature(int i);
        public event MyEventSignature ThresholdReached;

        //properties
        public int data
        {
            get;
            private set;
        }

        //constructor
        public MyEventClass()
        {
            data = 0;
        }

        //ทำเป็น protected virtual เพื่อเผื่อเวลาเอาไปใช้งานจริงแล้วต้อง inherit class นี้ไป class ลูกจะได้สามารถ override logic การ trigger event ได้ ว่าจะให้ trigger ตอนไหนยังไง หรือจะไม่ให้ trigger เลย
        protected virtual void OnThresholdReached()
        {
            ThresholdReached(data);
        }

        public int Add()
        {
            data++;
            if (data >= threshold)      //พอถึง threshold แล้วจะ call method "OnThresholdReached" เพื่อให้ "OnThresholdReached" ไป trigger event อีกทีหนึ่ง
            {
                OnThresholdReached();   //จริงๆตรงนี้ใช้ ThresholdReached(data); เพื่อ trigger event เลยก็ได้ แต่จะมี scalability น้อยกว่าตรงที่ class ลูกที่ inherit ไปจะปรับแก้ไข logic การ trigger event ว่าจะไม่เอา event หรือแก้เงื่อนไขอะไรไม่ได้
            }
            return data;                //return data กลับไปเพื่อบอกว่าหลังจาก Add แล้ว data เป็นอะไรเฉยๆ
        }
    }
}
