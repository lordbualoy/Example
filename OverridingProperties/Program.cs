using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OverridingProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            DescendantSample sample = new DescendantSample { Data1 = 10, Data2 = 10 };
            int get1 = sample.Data1;
            int get2 = sample.Data2;
        }
    }

    class AncestorSample
    {
        protected int data1;
        public virtual int Data1
        {
            get
            {
                return data1;
            }
            set
            {
                data1 = value;
            }
        }

        protected int data2;
        public virtual int Data2
        {
            get
            {
                return data2;
            }
            set
            {
                data2 = value;
            }
        }
    }

    class DescendantSample : AncestorSample
    {
        public override int Data1
        {
            get
            {
                return base.Data1;
            }
            set
            {
                base.Data1 = value;
            }
        }

        public override int Data2
        {
            get
            {
                return data2*2;
            }
            set
            {
                data2 = value*2;
            }
        }
    }
}
