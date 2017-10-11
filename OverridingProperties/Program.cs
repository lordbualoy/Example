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

            Sample1 sample1 = new Sample1 { Data = 5 };
            int get3 = sample1.Data;

            Sample2 sample2 = new Sample2 { Data = 5 };
            int get4 = sample2.Data;

            AbstractSample1 sample3 = new AbstractSample1 { Data = 5 };
            int get5 = sample3.Data;

            AbstractSample2 sample4 = new AbstractSample2 { Data = 5 };
            int get6 = sample4.Data;
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

    public interface ISample
    {
        int Data { get; }
    }

    public class Sample1 : ISample
    {
        public int Data { get; set; }
    }

    public class Sample2 : ISample
    {
        int data;
        public int Data
        {
            get
            {
                return data * 2;
            }
            set
            {
                data = value * 2;
            }
        }
    }

    public abstract class BaseSample1
    {
        protected int data;
        int Data
        {
            get
            {
                return data;
            }
        }
    }

    public class AbstractSample1 : BaseSample1
    {
        public int Data
        {
            get
            {
                return data * 2;
            }
            set
            {
                data = value * 2;
            }
        }
    }

    public abstract class BaseSample2
    {
        protected int data;
        public abstract int Data
        {
            get;
            set;
        }
    }

    public class AbstractSample2 : BaseSample2
    {
        public override int Data
        {
            get
            {
                return data * 2;
            }
            set
            {
                data = value * 2;
            }
        }
    }
}
