using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StackTraceException
{
    /// <summary>
    /// ตัวอย่างการ Catch แล้ว Rethrow แบบไม่เสีย StackTrace
    /// </summary>
    class Demo
    {
        public static void work()
        {
            try
            {
                lv1 _lv1 = new lv1();
                _lv1.work1();

                throw new Exception("main");
            }
            catch (Exception e)
            {
                throw;
            }
        }

        class lv1
        {
            public void work1()
            {
                try
                {
                    lv2 _lv2 = new lv2();
                    _lv2.work2();

                    throw new Exception("work1");
                }
                catch (Exception e)
                {
                    throw;
                }
            }

            class lv2
            {
                public void work2()
                {
                    try
                    {
                        lv3 _lv3 = new lv3();
                        _lv3.work3();

                        throw new Exception("work2");
                    }
                    catch (Exception e)
                    {
                        throw;
                    }
                }

                class lv3
                {
                    public void work3()
                    {
                        try
                        {
                            lv4 _lv4 = new lv4();
                            _lv4.work4();

                            throw new Exception("work3");
                        }
                        catch (Exception e)
                        {
                            throw;
                        }
                    }

                    class lv4
                    {
                        public void work4()
                        {
                            try
                            {
                                throw new Exception("work4");
                            }
                            catch (Exception e)
                            {
                                throw;
                            }
                        }
                    }
                }
            }
        }
    }
}
