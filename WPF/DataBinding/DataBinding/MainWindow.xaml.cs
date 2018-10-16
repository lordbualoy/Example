using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace DataBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Without DataContext
            {
                DataContainer data = new DataContainer();

                Binding codeBinding = new Binding();
                codeBinding.Source = data;                              //Source is DataContainer
                codeBinding.Path = new PropertyPath("A");               //Property A is a direct public property of DataContainer so the path is simply A
                codeBinding.Mode = BindingMode.OneWay;
                codeBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                textBox.SetBinding(TextBox.TextProperty, codeBinding);

                Binding codeBinding2 = new Binding();
                codeBinding2.Source = data;
                codeBinding2.Path = new PropertyPath("Inner.InnerA");   //Source is DataContainer; To Access DataContainer.Inner.InnerA Property the path will need to be Inner.InnerA
                codeBinding2.Mode = BindingMode.OneWay;
                codeBinding2.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                textBox2.SetBinding(TextBox.TextProperty, codeBinding2);

                button.Click += (s, e) =>
                {
                    data.A = Counter.Count;
                };
                button2.Click += (s, e) =>
                {
                    data.Inner.InnerA = Counter.Count;
                };
            }

            //With DataContext
            {
                DataContainer data = new DataContainer();
                grid2.DataContext = data;

                Binding codeBinding = new Binding();
                codeBinding.Path = new PropertyPath("A");               //Source is DataContainer despite no codeBinding.Source = data were defined the Source was inherited from grid1's DataContext = data; Property A is a direct public property of DataContainer so the path is simply A
                codeBinding.Mode = BindingMode.OneWay;
                codeBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                textBox3.SetBinding(TextBox.TextProperty, codeBinding);

                Binding codeBinding2 = new Binding();
                codeBinding2.Path = new PropertyPath("Inner.InnerA");   //Source is DataContainer despite no codeBinding.Source = data were defined the Source was inherited from grid1's DataContext = data; To Access DataContainer.Inner.InnerA Property the path will need to be Inner.InnerA
                codeBinding2.Mode = BindingMode.OneWay;
                codeBinding2.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                textBox4.SetBinding(TextBox.TextProperty, codeBinding2);

                button3.Click += (s, e) =>
                {
                    data.A = Counter.Count;
                };
                button4.Click += (s, e) =>
                {
                    data.Inner.InnerA = Counter.Count;
                };
            }

            //With DataContext change in XAML tree
            {
                DataContainer data = new DataContainer();

                grid3.DataContext = data;
                Binding codeBinding = new Binding();
                codeBinding.Path = new PropertyPath("A");               //Source is DataContainer
                codeBinding.Mode = BindingMode.OneWay;
                codeBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                textBox5.SetBinding(TextBox.TextProperty, codeBinding);

                grid3_2.DataContext = data.Inner;
                Binding codeBinding2 = new Binding();
                codeBinding2.Path = new PropertyPath("InnerA");         //Source is DataContainer.Inner
                codeBinding2.Mode = BindingMode.OneWay;
                codeBinding2.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
                textBox6.SetBinding(TextBox.TextProperty, codeBinding2);

                button5.Click += (s, e) =>
                {
                    data.A = Counter.Count;
                };
                button6.Click += (s, e) =>
                {
                    data.Inner.InnerA = Counter.Count;
                };
            }

            //DataBinding in MarkUp
            {
                DataContainer data = new DataContainer();
                grid4.DataContext = data;

                button7.Click += (s, e) =>
                {
                    data.A = Counter.Count;
                };
                button8.Click += (s, e) =>
                {
                    data.Inner.InnerA = Counter.Count;
                };
            }
        }
    }

    static class Counter
    {
        static int count;
        public static string Count { get => (++count).ToString(); }
    }

    public class DataContainer : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        string a;
        public string A
        {
            get => a;
            set
            {
                a = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(A)));
            }
        }

        public DataInnerContainer Inner { get; set; }

        public DataContainer()
        {
            a = "0";
            Inner = new DataInnerContainer { InnerA = a };
        }
    }

    public class DataInnerContainer : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        string innerA;
        public string InnerA
        {
            get => innerA;
            set
            {
                innerA = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(InnerA)));
            }
        }
    }
}
