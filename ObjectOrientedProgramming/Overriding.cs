using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectOrientedProgramming
{
    partial class Program
    {
        class Overriding1
        {
            /// <summary>
            /// overriding แบบปกติ
            /// </summary>
            public static void Demo()
            {
                int i;
                Foo foo = new Foo();
                Bar bar = new Bar();

                i = foo.A();    //Foo.A() is called
                i = bar.A();    //Bar.A() is called
                i = foo.B();    //Foo.B() is called
                i = bar.B();    //Foo.B() is called
            }

            class Foo
            {
                public virtual int A()
                {
                    return 1;
                }

                public virtual int B()
                {
                    return 10;
                }
            }

            class Bar : Foo
            {
                public override int A()
                {
                    return 2;
                }
            }
        }

        class Overriding2
        {
            /// <summary>
            /// Extend ancestor script
            /// </summary>
            public static void Demo()
            {
                int i;
                Bar bar = new Bar();

                i = bar.A();    //Bar.A() is called
                i = bar.B();    //Bar.B() is called then go in to Foo.B() first before resuming Bar.B()
            }

            class Foo
            {
                public virtual int A()
                {
                    return 1;
                }

                public virtual int B()
                {
                    return 10;
                }
            }

            class Bar : Foo
            {
                public override int A()
                {
                    return base.A();
                }

                public override int B()
                {
                    int i = base.B();
                    i *= 2;
                    return i;
                }
            }
        }

        class Overriding3
        {
            /// <summary>
            /// method ของ class ลูก conflict กับ method ของ class แม่
            /// </summary>
            public static void Demo()
            {
                int i;
                Foo foo = new Foo();
                Bar bar = new Bar();

                i = foo.A();    //Foo.A() is called
                i = bar.A();    //Bar.A() is called
                i = foo.B();    //Foo.B() is called
                i = bar.B();    //Bar.B() is called
            }

            class Foo
            {
                public virtual int A()
                {
                    return 1;
                }

                public int B()
                {
                    return 10;
                }
            }

            class Bar : Foo
            {
                public override int A()
                {
                    return 2;
                }

                public int B()  //'ObjectOrientedProgramming.Program.Overriding3.Bar.B()' hides inherited member 'ObjectOrientedProgramming.Program.Overriding3.Foo.B()'. Use the new keyword if hiding was intended.
                {
                    return 20;
                }
            }
        }

        class Overriding3_Fixed
        {
            /// <summary>
            /// method ของ class ลูก conflict กับ method ของ class แม่ แบบแก้ไขให้ถูกต้องแล้ว
            /// </summary>
            public static void Demo()
            {
                int i;
                Foo foo = new Foo();
                Bar bar = new Bar();

                i = foo.A();    //Foo.A() is called
                i = bar.A();    //Bar.A() is called
                i = foo.B();    //Foo.B() is called
                i = bar.B();    //Bar.B() is called
            }

            class Foo
            {
                public virtual int A()
                {
                    return 1;
                }

                public int B()
                {
                    return 10;
                }
            }

            class Bar : Foo
            {
                public override int A()
                {
                    return 2;
                }

                new public int B()  //เพิ่ม keyword new เข้ามาเพื่อให้ compile ไม่ฟ้อง warning
                {
                    return 20;
                }
            }
        }

        class Overriding4
        {
            /// <summary>
            /// virtual vs new behavioral differences
            /// </summary>
            public static void Demo()
            {
                int i;
                Bar bar = new Bar();

                i = bar.A();    //Bar.A() is called
                i = bar.B();    //Bar.B() is called

                Foo foo = bar;
                i = foo.A(); i = ((Foo)bar).A();    //Bar.A() is called
                i = foo.B(); i = ((Foo)bar).B();    //Foo.B() is called
            }

            class Foo
            {
                public virtual int A()
                {
                    return 1;
                }

                public int B()
                {
                    return 10;
                }
            }

            class Bar : Foo
            {
                public override int A()
                {
                    return 2;
                }

                new public int B()
                {
                    return 20;
                }
            }
        }
    }
}
