using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceTypeCopying
{
    class Program
    {
        static void Main(string[] args)
        {
            Foo f1 = new Foo { A = 1, B = 2, Bar = new Bar { C = 3 } };
            Foo f2 = f1.ShallowCopy();
            bool valueTypeTest = f1.A == f2.A && f1.B == f2.B && f1.Bar.C == f2.Bar.C;
            bool referenceTypeTest = f1.Bar != f2.Bar;

            Foo f3 = f1.DeepCopy();
            valueTypeTest = f1.A == f3.A && f1.B == f3.B && f1.Bar.C == f3.Bar.C;
            referenceTypeTest = f1.Bar != f3.Bar;
        }
    }

    class Bar
    {
        public int C { get; set; }
    }

    class Foo
    {
        public int A { get; set; }
        public int B { get; set; }
        public Bar Bar { get; set; }

        public Foo ShallowCopy() => (Foo)MemberwiseClone();
        public Foo DeepCopy()
        {
            Foo foo = ShallowCopy();
            foo.Bar = new Bar { C = Bar.C };
            return foo;
        }
    }

    abstract class AbstractCloneable : ICloneable
    {
        public object Clone()
        {
            AbstractCloneable clone = (AbstractCloneable)MemberwiseClone();
            HandleCloned(clone);
            return clone;
        }

        protected virtual void HandleCloned(AbstractCloneable clone)
        {
            //Nothing particular in the base class, but maybe usefull for childs.
            //Not abstract so childs may not implement this if they don't need to.
        }

    }
    
    class ConcreteCloneable : AbstractCloneable
    {
        public Bar Bar { get; set; }

        protected override void HandleCloned(AbstractCloneable clone)
        {
            //Get wathever magic a base class could have implemented.
            base.HandleCloned(clone);

            //Clone is of the current type.
            ConcreteCloneable obj = (ConcreteCloneable)clone;

            //Copy Reference Types
            obj.Bar = new Bar { C = Bar.C };
        }
    }
}
