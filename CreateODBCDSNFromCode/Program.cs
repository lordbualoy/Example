using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace CreateODBCDSNFromCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<Microsoft.Win32.RegistryKey> act = (HKLM) =>
            {
                using (Microsoft.Win32.RegistryKey ODBC = HKLM.OpenSubKey("SOFTWARE\\ODBC\\ODBC.INI", true))
                {
                    if (ODBC == null)
                        throw new KeyNotFoundException();

                    using (Microsoft.Win32.RegistryKey FBMAXXTest = ODBC.CreateSubKey("FBMAXXTest"))
                    {
                        FBMAXXTest.SetValue("Driver", "C:\\Windows\\system32\\OdbcFb.dll");
                        FBMAXXTest.SetValue("Description", "");
                        FBMAXXTest.SetValue("Dbname", "D:\\Pro9.DB\\FBMAXX_TH.FDB");
                        FBMAXXTest.SetValue("Client", "");
                        FBMAXXTest.SetValue("User", "SYSDBA");
                        FBMAXXTest.SetValue("Role", "ProMaxx");
                        FBMAXXTest.SetValue("CharacterSet", "UTF8");
                        FBMAXXTest.SetValue("JdbcDriver", "IscDbc");
                        FBMAXXTest.SetValue("ReadOnly", "N");
                        FBMAXXTest.SetValue("NoWait", "N");
                        FBMAXXTest.SetValue("LockTimeoutWaitTransactions", "");
                        FBMAXXTest.SetValue("Dialect", "3");
                        FBMAXXTest.SetValue("QuotedIdentifier", "Y");
                        FBMAXXTest.SetValue("SensitiveIdentifier", "N");
                        FBMAXXTest.SetValue("AutoQuotedIdentifier", "N");
                        FBMAXXTest.SetValue("UseSchemaIdentifier", "0");
                        FBMAXXTest.SetValue("SafeThread", "Y");
                        FBMAXXTest.SetValue("Password", "DCMMFFCKIHAGJDGALAEBNGKEIOICBDGJDPMFFICPIFAPJCGCLNEKNJKJIMILBCGLDMMOFLCEIDAIJBGEFAKGELGLBGFGHCBG");
                    }

                    using (Microsoft.Win32.RegistryKey odbcDataSources = ODBC.OpenSubKey("ODBC Data Sources", true))
                    {
                        if (odbcDataSources == null)
                            throw new KeyNotFoundException();

                        odbcDataSources.SetValue("FBMAXXTest", "Firebird/InterBase(r) driver");
                    }
                }
            };

            if (Environment.Is64BitOperatingSystem)
            {
                using (Microsoft.Win32.RegistryKey HKLM64 = Microsoft.Win32.RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, Microsoft.Win32.RegistryView.Registry64))
                {
                    act(HKLM64);
                }
            }
            else
            {
                using (Microsoft.Win32.RegistryKey HKLM32 = Microsoft.Win32.Registry.LocalMachine)
                {
                    act(HKLM32);
                }
            }
        }
    }
}
