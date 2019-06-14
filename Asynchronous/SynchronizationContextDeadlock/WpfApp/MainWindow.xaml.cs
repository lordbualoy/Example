using SharedLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly Log log;
        readonly RemoteHelper remoteHelper;

        public MainWindow()
        {
            InitializeComponent();

            log = new Log();
            remoteHelper = new RemoteHelper(log);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            log.Write("MainWindow.Button_Click");
            var resp = remoteHelper.GetResponse();
            log.Write("MainWindow.Button_Click");
        }

        private void Deadlock_Click(object sender, RoutedEventArgs e)
        {
            log.Write("Deadlock_Click");
            var resp = remoteHelper.GetResponseDeadlock();
            log.Write("Deadlock_Click");
        }
    }

    class Log : BaseLog
    {
        protected override void WriteImplementation(string msg)
        {
            Debug.WriteLine(msg);
        }
    }
}
