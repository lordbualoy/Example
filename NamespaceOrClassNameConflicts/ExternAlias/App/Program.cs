extern alias V1;
extern alias V2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExternAlias
{
    class Program
    {
        static void Main(string[] args)
        {
            //สมมติ project นึงจำเป็นต้องใช้ assembly ชื่อ newtonsoft.json มากกว่า 1 version ใน project เดียว
            //เช่น ต้องการ add newtonsoft.json100.dll, newtonsoft.json200.dll เข้ามาพร้อมๆกัน
            //ซึ่งการทำแบบนี้จะทำให้ compile ไม่ได้เนื่องจาก assembly ชื่อ newtonsoft.json ทั้ง 2 version มี namespace เดียวกัน
            //และใน namespace นี้ของแต่ละตัวจะมี class ชื่อเดียวกันเต็มไปหมด ส่งผลให้ชื่อ class ชนกันเละเทะไปหมด

            //วิธีแก้คือหลังจาก add reference ของแต่ละตัวมาแล้วให้ไปแก้ property ของ reference newtonsoft.json100.dll และ newtonsoft.json200.dll
            //ที่ค่า alias จากมีค่า default เป็น  global ให้เปลี่ยนเป็น เช่น V100 และ V200
            //และในแต่ละ file .cs ให้เพิ่ม
            //extern alias V100;
            //extern alias V200;
            //จากนั้นเวลาจะใช้ class ก็อ้างด้วย
            //V100.classname.blabla
            //หรือ
            //V100::classname.blabla
            //ก็ได้
            //เช่น ดังตัวอย่างข้างล่าง

            V1::ExternAlias.Class1 class1V1 = new V1.ExternAlias.Class1();
            int version = class1V1.Version;
            int data = class1V1.data;

            V2.ExternAlias.Class1 class1V2 = new V2.ExternAlias.Class1();
            version = class1V2.Version;
            data = class1V2.data;
        }
    }
}
