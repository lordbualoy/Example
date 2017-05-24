using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectOrientedProgramming
{
    partial class Program
    {
        class Constructor1
        {
            /// <summary>
            /// การสร้าง constructor ของ class ลูกแบบปกติ
            /// </summary>
            public static void Demo()
            {
                //Bar bar = new Bar();  //'ObjectOrientedProgramming.Program.Constructor1.Bar' does not contain a constructor that takes 0 arguments
                Bar bar2 = new Bar(1);
                Bar bar3 = new Bar(1, 2);
            }

            public class Foo
            {
                public readonly int i;
                public readonly int j;

                public Foo(int i)
                {
                    this.i = i;
                }

                public Foo(int i, int j)
                {
                    this.i = i;
                    this.j = j;
                }
            }

            public class Bar : Foo
            {
                public Bar(int i) : base(i) { }
                public Bar(int i, int j) : base(i, j) { }
            }
        }

        class Constructor2
        {
            /// <summary>
            /// ตัวอย่าง syntax ที่ผิด
            /// </summary>
            public static void Demo()
            {
                //Bar bar = new Bar();    //ไม่ฟ้อง error ที่นี่ก็จริงแต่จะไปฟ้อง error ที่ '###' แทน
                //Bar bar2 = new Bar(1);  //'ObjectOrientedProgramming.Program.Constructor2.Bar' does not contain a constructor that takes 1 arguments
                //Bar bar3 = new Bar(1, 2);   //'ObjectOrientedProgramming.Program.Constructor2.Bar' does not contain a constructor that takes 2 arguments
            }

            public class Foo
            {
                public readonly int i;
                public readonly int j;

                public Foo(int i)
                {
                    this.i = i;
                }

                public Foo(int i, int j)
                {
                    this.i = i;
                    this.j = j;
                }
            }

            //public class Bar : Foo  //'###' 'ObjectOrientedProgramming.Program.Constructor2.Foo' does not contain a constructor that takes 0 arguments
            //{
            //}
        }

        class Constructor2_Fixed
        {
            /// <summary>
            /// ปรับแก้จากตัวอย่างที่ 2 ด้วยการ สร้าง parameterless constructor ไว้ที่ class Foo
            /// </summary>
            public static void Demo()
            {
                Bar bar = new Bar();
                //Bar bar2 = new Bar(1);  //'ObjectOrientedProgramming.Program.Constructor2_Fixed.Bar' does not contain a constructor that takes 1 arguments
                //Bar bar3 = new Bar(1, 2);   //'ObjectOrientedProgramming.Program.Constructor2_Fixed.Bar' does not contain a constructor that takes 2 arguments
            }

            public class Foo
            {
                public readonly int i;
                public readonly int j;

                public Foo()    //เพิ่ม constructor นี้มาที่ class แม่จะทำให้ compile ผ่าน
                {
                }

                public Foo(int i)
                {
                    this.i = i;
                }

                public Foo(int i, int j)
                {
                    this.i = i;
                    this.j = j;
                }
            }

            public class Bar : Foo  //ตอนนี้ได้แล้วเพราะ class Bar สามารถ autogen parameterless constructor 'public Bar() : base () {}' ได้
            {
            }
        }

        class Constructor2_Fixed_Advance
        {
            /// <summary>
            /// Default constructor. If a derived class does not invoke a base-class constructor explicitly, the default constructor is called implicitly. 
            /// </summary>
            public static void Demo()
            {
                Bar bar = new Bar();
                //Bar bar2 = new Bar(1);  //'ObjectOrientedProgramming.Program.Constructor2_Fixed.Bar' does not contain a constructor that takes 1 arguments
                //Bar bar3 = new Bar(1, 2);   //'ObjectOrientedProgramming.Program.Constructor2_Fixed.Bar' does not contain a constructor that takes 2 arguments
            }

            public class Foo
            {
                public readonly bool isInitializedByParameterlessConstructor = false;
                public readonly int i;
                public readonly int j;

                public Foo()    //เพิ่ม constructor นี้มาที่ class แม่จะทำให้ compile ผ่าน
                {
                    isInitializedByParameterlessConstructor = true;
                }

                public Foo(int i)
                {
                    this.i = i;
                }

                public Foo(int i, int j)
                {
                    this.i = i;
                    this.j = j;
                }
            }

            public class Bar : Foo  //ตอนนี้ได้แล้วเพราะ class Bar สามารถ autogen parameterless constructor 'public Bar() : base () {}' ได้
            {
            }
        }

        class Constructor3
        {
            /// <summary>
            /// จากตัวอย่างเมื่อ new Bar(1) สิ่งที่เกิดขึ้นคือโปรแกรมจะไปทำ instruction ใน Foo.Foo(1) ก่อนจากนั้นจะกลับมาทำ instruction ของ Bar(1) : base(1) ต่อ ซึ่งในที่นี้ i ที่ set จาก Foo.Foo(1) จะโดน Bar(1) : base(1) ทับไป
            /// </summary>
            public static void Demo()
            {
                Bar bar = new Bar(1);
                //Bar bar2 = new Bar(1, 2);   //'ObjectOrientedProgramming.Program.Constructor3.Bar' does not contain a constructor that takes 2 arguments
            }

            public class Foo
            {
                public int i { get; protected set; }
                public int j { get; protected set; }

                public Foo(int i)
                {
                    this.i = i;
                }

                public Foo(int i, int j)
                {
                    this.i = i;
                    this.j = j;
                }
            }

            public class Bar : Foo
            {
                public Bar(int i)
                    : base(i)
                {
                    this.i = 10;
                }
            }
        }

        class Constructor4
        {
            /// <summary>
            /// demo การ redirect constructor ให้ invoke Bar.Bar(void) แต่จริงๆจะโดน redirect ไป invoke Foo.Foo(i) แทน
            /// </summary>
            public static void Demo()
            {
                Bar bar = new Bar();
                //Bar bar2 = new Bar(1);  //'ObjectOrientedProgramming.Program.Constructor4.Bar' does not contain a constructor that takes 1 arguments
                //Bar bar3 = new Bar(1, 2);   //'ObjectOrientedProgramming.Program.Constructor4.Bar' does not contain a constructor that takes 2 arguments
            }

            public class Foo
            {
                public readonly int i;
                public readonly int j;

                public Foo(int i)
                {
                    this.i = i;
                }

                public Foo(int i, int j)
                {
                    this.i = i;
                    this.j = j;
                }
            }

            public class Bar : Foo
            {
                public Bar() : base(10) { }
            }
        }

        class Constructor5
        {
            /// <summary>
            /// demo การ redirect parameter ให้ invoke Bar.Bar(int i, int j) โดน redirect parameter ไป invoke Foo.Foo(int j, int i) แทน
            /// </summary>
            public static void Demo()
            {
                Bar bar2 = new Bar(1, 2);
            }

            public class Foo
            {
                public readonly int i;
                public readonly int j;

                public Foo(int i)
                {
                    this.i = i;
                }

                public Foo(int i, int j)
                {
                    this.i = i;
                    this.j = j;
                }
            }

            public class Bar : Foo
            {
                public Bar(int i, int j)
                    : base(j, i)
                {
                }
            }
        }

        class Constructor6
        {
            /// <summary>
            /// Static constructor to initialize the static member, currentID. This constructor is called one time, automatically, before any instance of WorkItem or ChangeRequest is created, or currentID is referenced.
            /// </summary>
            public static void Demo()
            {
                int i = Foo.i;  //เข้า static Foo()
                int j = Foo.i;  //ไม่เข้า static Foo() แล้ว แสดงว่าถูก invoke แค่ครั้งเดียวเท่านั้นตอนครั้งแรกที่ access จากนั้นจะอยู่ยาวจนหมด lifetime ของโปรแกรม
            }

            public class Foo
            {
                public static int i;
                static Foo()
                {
                    i = 10;
                }
            }
        }

        class Constructor7
        {
            /// <summary>
            /// Static constructor ของ class แม่เมื่อ access จาก class ลูก
            /// </summary>
            public static void Demo()
            {
                int i = Bar.i;  //เข้า static Foo()
                int j = Bar.i;  //ไม่เข้า static Foo() แล้ว แสดงว่าถูก invoke แค่ครั้งเดียวเท่านั้นตอนครั้งแรกที่ access จากนั้นจะอยู่ยาวจนหมด lifetime ของโปรแกรม
            }

            public class Foo
            {
                public static int i;
                static Foo()
                {
                    i = 10;
                }
            }

            public class Bar : Foo
            {
            }
        }

        class Constructor8
        {
            /// <summary>
            /// Static constructor เมื่อมี static constructor ของแม่และลูกชนกัน
            /// </summary>
            public static void Demo()
            {
                int i = Bar.i;  //เข้า static Foo() แต่ไม่เข้า static Bar()
                int j = Bar.i;  //ไม่เข้าทั้ง static Foo() และ static Bar() แล้ว แสดงว่าถูก invoke แค่ครั้งเดียวเท่านั้นตอนครั้งแรกที่ access จากนั้นจะอยู่ยาวจนหมด lifetime ของโปรแกรม
            }

            public class Foo
            {
                public static int i;
                static Foo()
                {
                    i = 10;
                }
            }

            public class Bar : Foo
            {
                static Bar()
                {
                    i = 20;
                }
            }
        }
    }
}
