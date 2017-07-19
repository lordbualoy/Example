using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Registry
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!Environment.Is64BitOperatingSystem)
                throw new Exception("ต้องรันบน 64-bit OS เท่านั้น");

            //A 32-bit application on a 64-bit OS will be looking at the Wow6432Node node by default when reading keys from HKLM\Software. To read the 64-bit version of the key, you'll need to specify the RegistryView

            //ตัวอย่างนี้ เรากำหนดไปว่าให้อ่านที่ HKEY_LOCAL_MACHINE\SOFTWARE\ODBC\ODBC.INI แต่ class RegistryKey จะไปอ่านที่ HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\ODBC\ODBC.INI แทน เพราะ app ถูก compile เป็น 32 bit
            using (Microsoft.Win32.RegistryKey ODBC = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\ODBC\\ODBC.INI"))
            {
                if (ODBC == null)
                    throw new KeyNotFoundException();

                using (Microsoft.Win32.RegistryKey SAuth = ODBC.OpenSubKey("SAuth32"))    //จะอ่านเจอ SAuth32 ทั้งๆที่ SAuth32 ที่จะอยู่ที่ HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\ODBC\ODBC.INI\SAuth32
                {
                    if (SAuth == null)
                        throw new KeyNotFoundException();
                }
            }

            //แต่ถ้าเราต้องการให้ class RegistryKey ไปอ่านค่าแบบ 64 bit ใน app 32 bit ได้ สามารถทำได้แบบนี้
            using (Microsoft.Win32.RegistryKey HKLM64 = Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, Microsoft.Win32.RegistryView.Registry64))
            using (Microsoft.Win32.RegistryKey ODBC = HKLM64.OpenSubKey("SOFTWARE\\ODBC\\ODBC.INI"))
            {
                if (ODBC == null)
                    throw new KeyNotFoundException();

                using (Microsoft.Win32.RegistryKey SAuth = ODBC.OpenSubKey("SAuth"))    //จะอ่านเจอ SAuth32 ทั้งๆที่ SAuth ที่จะอยู่ที่ HKEY_LOCAL_MACHINE\SOFTWARE\ODBC\ODBC.INI\SAuth
                {
                    if (SAuth == null)
                        throw new KeyNotFoundException();
                }
            }

            //Read / Write
            using (Microsoft.Win32.RegistryKey HKLM64 = Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, Microsoft.Win32.RegistryView.Registry64))
            {
                try
                {
                    using (Microsoft.Win32.RegistryKey ODBC = HKLM64.OpenSubKey("SOFTWARE\\ODBC\\ODBC.INI"))    //อันนี้จะเปิดเป็นแบบ Read-Only ไม่สามารถ write ได้
                    {
                        if (ODBC == null)
                            throw new KeyNotFoundException();

                        using (Microsoft.Win32.RegistryKey SAuth = ODBC.OpenSubKey("SAuth"))    //อันนี้จะเปิดเป็นแบบ Read-Only ไม่สามารถ write ได้
                        {
                            if (SAuth == null)
                                throw new KeyNotFoundException();

                            string role = (string)SAuth.GetValue("Role");
                            SAuth.SetValue("Role", role + "a");
                        }
                    }
                }
                catch(UnauthorizedAccessException e)
                {
                    //จะเกิด UnauthorizedAccessException เนื่องจากไม่มีสิทธิ Write
                }

                try
                {
                    using (Microsoft.Win32.RegistryKey ODBC = HKLM64.OpenSubKey("SOFTWARE\\ODBC\\ODBC.INI"))    //อันนี้จะเปิดเป็นแบบ Read-Only ไม่สามารถ write ได้
                    {
                        if (ODBC == null)
                            throw new KeyNotFoundException();

                        using (Microsoft.Win32.RegistryKey SAuth = ODBC.OpenSubKey("SAuth", true))    //อันนี้จะเปิดเป็นแบบ Read | Write สามารถ write ได้
                        {
                            if (SAuth == null)
                                throw new KeyNotFoundException();

                            string role = (string)SAuth.GetValue("Role");
                            SAuth.SetValue("Role", role + "a");
                        }
                    }
                }
                catch (UnauthorizedAccessException e)
                {
                    //จะไม่เกิด UnauthorizedAccessException เนื่องจากมีสิทธิ Write แล้ว (ถ้าไม่ติดเรื่อง run as admin ที่อาจจะติด)
                }
            }

            //Create new SubKey
            using (Microsoft.Win32.RegistryKey HKLM64 = Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, Microsoft.Win32.RegistryView.Registry64))
            using (Microsoft.Win32.RegistryKey ODBC = HKLM64.OpenSubKey("SOFTWARE\\ODBC\\ODBC.INI", true))
            {
                if (ODBC == null)
                    throw new KeyNotFoundException();

                using (Microsoft.Win32.RegistryKey NewKey = ODBC.CreateSubKey("NewKey"))
                {
                    NewKey.SetValue("name", "NewName");
                    NewKey.SetValue("count", 10);
                }
            }

            //Delete SubKey
            using (Microsoft.Win32.RegistryKey HKLM64 = Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, Microsoft.Win32.RegistryView.Registry64))
            using (Microsoft.Win32.RegistryKey ODBC = HKLM64.OpenSubKey("SOFTWARE\\ODBC\\ODBC.INI", true))
            {
                if (ODBC == null)
                    throw new KeyNotFoundException();

                using (Microsoft.Win32.RegistryKey NewKey = ODBC.OpenSubKey("NewKey", true))
                {
                    NewKey.DeleteValue("name");
                }

                ODBC.DeleteSubKey("NewKey");
            }
        }
    }
}
