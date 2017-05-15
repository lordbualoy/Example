using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StackTrace
{
    class Program
    {
        static void Main(string[] args)
        {
            lv1 _lv1 = new lv1();
            _lv1.work1();

            System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace();
            System.Diagnostics.StackFrame sf = st.GetFrame(0);      //จะได้ Execution Stack ตัวบนสุด คือ ตัวมันเอง Main
            string methodname = sf.GetMethod().Name;
        }

        class lv1
        {
            public void work1()
            {
                lv2 _lv2 = new lv2();
                _lv2.work2();

                System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace();
                System.Diagnostics.StackFrame sf = st.GetFrame(0);      //จะได้ Execution Stack ตัวบนสุด คือ ตัวมันเอง work1
                string methodname = sf.GetMethod().Name;
                sf = st.GetFrame(1);                                    //จะได้ Execution Stack ตัวที่ 2 จากบนสุด คือ Main
                methodname = sf.GetMethod().Name;
            }

            class lv2
            {
                public void work2()
                {
                    lv3 _lv3 = new lv3();
                    _lv3.work3();

                    System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace();
                    System.Diagnostics.StackFrame sf = st.GetFrame(0);      //จะได้ Execution Stack ตัวบนสุด คือ ตัวมันเอง work2
                    string methodname = sf.GetMethod().Name;
                    sf = st.GetFrame(1);                                    //จะได้ Execution Stack ตัวที่ 2 จากบนสุด คือ work1
                    methodname = sf.GetMethod().Name;
                    sf = st.GetFrame(2);                                    //จะได้ Execution Stack ตัวที่ 3 จากบนสุด คือ Main
                    methodname = sf.GetMethod().Name;
                }

                class lv3
                {
                    public void work3()
                    {
                        lv4 _lv4 = new lv4();
                        _lv4.work4();

                        System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace();
                        System.Diagnostics.StackFrame sf = st.GetFrame(0);      //จะได้ Execution Stack ตัวบนสุด คือ ตัวมันเอง work3
                        string methodname = sf.GetMethod().Name;
                        sf = st.GetFrame(1);                                    //จะได้ Execution Stack ตัวที่ 2 จากบนสุด คือ work2
                        methodname = sf.GetMethod().Name;
                        sf = st.GetFrame(2);                                    //จะได้ Execution Stack ตัวที่ 3 จากบนสุด คือ work1
                        methodname = sf.GetMethod().Name;
                        sf = st.GetFrame(3);                                    //จะได้ Execution Stack ตัวที่ 4 จากบนสุด คือ Main
                        methodname = sf.GetMethod().Name;
                    }

                    class lv4
                    {
                        public void work4()
                        {
                            System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace();
                            System.Diagnostics.StackFrame sf = st.GetFrame(0);      //จะได้ Execution Stack ตัวบนสุด คือ ตัวมันเอง work4
                            string methodname=sf.GetMethod().Name;
                            sf = st.GetFrame(1);                                    //จะได้ Execution Stack ตัวที่ 2 จากบนสุด คือ work3
                            methodname = sf.GetMethod().Name;
                            sf = st.GetFrame(2);                                    //จะได้ Execution Stack ตัวที่ 3 จากบนสุด คือ work2
                            methodname = sf.GetMethod().Name;
                            sf = st.GetFrame(3);                                    //จะได้ Execution Stack ตัวที่ 4 จากบนสุด คือ work1
                            methodname = sf.GetMethod().Name;
                            sf = st.GetFrame(4);                                    //จะได้ Execution Stack ตัวที่ 5 จากบนสุด คือ Main
                            methodname = sf.GetMethod().Name;
                        }
                    }
                }
            }
        }
    }
}
