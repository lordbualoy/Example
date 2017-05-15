using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppSettings
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //ถ้าตั้ง Settings.settings เป็นระดับ Application โปรแกรมจะ Read ได้อย่างเดียว
            //ถ้าตั้งเป็นระดับ User จะไป save ที่ C:\Users\_USERNAME_\AppData\Local\_APPNAME_ แล้วสามารถ Read / Write ได้

            string get = Properties.Settings.Default.HelloWorld;
            TimeSpan gets = Properties.Settings.Default.Setting;
            int New = Properties.Settings.Default.New;
            textBlock1.Text = get;

            Properties.Settings.Default.HelloWorld = "NEW SETTING";
            Properties.Settings.Default.Save();
        }
    }
}
