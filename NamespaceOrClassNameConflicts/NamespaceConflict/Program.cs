using Test;

namespace Namespace.Test.Conflict
{
    class Program
    {
        public class Class1
        {
            public int i = 0;
        }

        static void Main(string[] args)
        {
            Namespace.Test.Conflict.Program.Class1 Namespace_Test_Conflict_cls = new Namespace.Test.Conflict.Program.Class1();
            Namespace_Test_Conflict_cls.i = 10;

            //Without global keyword > unable to compile
            //Test.Class1 Test_cls = new Test.Class1();

            //With global keyword > able to compile
            global::Test.Class1 Test_cls = new global::Test.Class1();

            Test_cls.a = "Text";
        }
    }
}
