using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        const int Duration = 3000;
        int syncCounter = 0;
        int asyncCounter = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void synch_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(Duration);
            output.Text = $"sync counter = {++syncCounter}";
        }

        private async void asynch_Click(object sender, EventArgs e)
        {
            await Task.Delay(Duration);
            output.Text = $"async counter = {++asyncCounter}";
        }
    }
}
