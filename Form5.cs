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
    public partial class Form5 : Form
    {
        string AssetSN, AssetName, Department;
        public Form5(string AssetSN, string AssetName, string Department)
        {
            this.AssetName = AssetName;
            this.AssetSN = AssetSN;
            this.Department = Department;
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            if(textBox1.Text.Length != 0)
            {
                Hide();
                Form4 from = new Form4();
                from.Show();
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 form = new Form4();
            Hide();
            form.Show();

        }
    }
}
