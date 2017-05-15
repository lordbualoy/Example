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

namespace BasicGUIEvent
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //ประกาศ delegate แบบ anonymous function กับ lambda expression เพื่อทดสอบว่าใช้ได้ไหม
            RoutedEventHandler Delegate1 = (object sender, RoutedEventArgs e) => MessageBox.Show("Custom subscription to Button Click of \"Lambda Expression Delegate1\" is success");
            RoutedEventHandler Delegate2 = delegate(object sender, RoutedEventArgs e) { MessageBox.Show("Custom subscription to Button Click of \"Anonymous Function Delegate2\" is success"); };

            //subscribe delegate เข้าที่ event click ของ button1
            button1.Click += button1_Click_Custom;      //subscribe แบบส่ง named method เข้าไป
            button1.Click += Delegate1;                 //subscribe แบบส่ง delegate เข้าไป
            button1.Click += Delegate2;                 //subscribe แบบส่ง delegate เข้าไป

            //ประกาศ delegate แบบ multicast
            RoutedEventHandler button1_Click_Delegate = button1_Click;                  //ไม่สามารถโยน named method ใส่ multicast delegate ตรงๆได้ ต้องเอาใส่ delegate ก่อน ไม่งั้นจะ error
            RoutedEventHandler button1_Click_Custom_Delegate = button1_Click_Custom;    //ไม่สามารถโยน named method ใส่ multicast delegate ตรงๆได้ ต้องเอาใส่ delegate ก่อน ไม่งั้นจะ error
            RoutedEventHandler MultiCast = button1_Click_Delegate + button1_Click_Custom_Delegate + Delegate1 + Delegate2;  //ทำ multicast delegate

            //subscribe multicast delegate เข้าที่ event click ของ button2
            button2.Click += MultiCast;
        }

        void button1_Click_Custom(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Custom subscription to Button Click of \"button1_Click_Custom\" is success");
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Normal subscription to Button Click of \"button1_Click\" is success");
        }
    }
}
