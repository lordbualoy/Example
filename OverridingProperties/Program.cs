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
            bool get6 = sample3.VirtualMethod();

            AbstractSample2 sample4 = new AbstractSample2 { Data = 5 };
            int get7 = sample4.Data;
            bool get8 = sample4.AbstractMethod();
        }
    }

    class AncestorSample
    {
        protected int data1;
        public virtual int Data1
        {
            get => data1;
            set => data1 = value;
        }

        protected int data2;
        public virtual int Data2
        {
            get => data2;
            set => data2 = value;
        }
    }

    class DescendantSample : AncestorSample
    {
        public override int Data1
        {
            get => base.Data1;
            set => base.Data1 = value;
        }

        public override int Data2
        {
            get => data2 * 2;
            set => data2 = value * 2;
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
            get => data * 2;
            set => data = value * 2;
        }
    }

    public abstract class BaseSample1
    {
        protected int data;
        public virtual int Data
        {
            get => data;
            set => data = value;
        }

        public virtual bool VirtualMethod()
        {
            return false;
        }
    }

    public class AbstractSample1 : BaseSample1
    {
        public override int Data
        {
            get => data * 2;
            set => data = value * 2;
        }

        public override bool VirtualMethod()
        {
            return true;
        }
    }

    public abstract class BaseSample2
    {
        public abstract int Data { get; set; }
        public abstract bool AbstractMethod();
    }

    public class AbstractSample2 : BaseSample2
    {
        int data;
        public override int Data
        {
            get => data * 2;
            set => data = value * 2;
        }

        public override bool AbstractMethod()
        {
            return true;
        }
    }
}
