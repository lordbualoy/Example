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
using System.Data;

namespace DataTableToWPFUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataTable dt = new DataTable();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            dt.Reset();

            dt.Columns.Add("A", typeof(int));
            dt.Columns.Add("B", typeof(int));
            dt.Columns.Add("C", typeof(int));
            DataRow dr;
            dr = dt.NewRow();
            dt.Rows.Add(dr);
            dr[0] = 1;
            dr[1] = 1;
            dr[2] = 1;

            dr = dt.NewRow();
            dt.Rows.Add(dr);
            dr[0] = 2;
            dr[1] = 2;
            dr[2] = 2;

            dataGrid1.ItemsSource = dt.AsDataView();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            dt.Reset();

            dt.Columns.Add("A", typeof(int));
            dt.Columns.Add("B", typeof(int));
            dt.Columns.Add("C", typeof(int));
            dt.Columns.Add("D", typeof(int));
            dt.Columns.Add("E", typeof(int));
            dt.Columns.Add("F", typeof(int));
            DataRow dr;
            dr = dt.NewRow();
            dt.Rows.Add(dr);
            dr[0] = 1;
            dr[1] = 1;
            dr[2] = 1;
            dr[3] = 1;
            dr[4] = 1;
            dr[5] = 1;

            dr = dt.NewRow();
            dt.Rows.Add(dr);
            dr[0] = 2;
            dr[1] = 2;
            dr[2] = 2;
            dr[3] = 2;
            dr[4] = 2;
            dr[5] = 2;

            dataGrid1.ItemsSource = dt.AsDataView();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            dt.Reset();

            dt.Columns.Add("A", typeof(int));
            DataRow dr;
            dr = dt.NewRow();
            dt.Rows.Add(dr);
            dr[0] = 1;

            dr = dt.NewRow();
            dt.Rows.Add(dr);
            dr[0] = 2;

            dataGrid1.ItemsSource = dt.AsDataView();
        }
    }
}
