using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form5 : Form
    {
        string AssetSN, AssetName, Department;
        int id;
        int EmID;
        
        public Form5(string AssetSN, string AssetName, string Department, int id)
        {
            this.AssetName = AssetName;
            this.AssetSN = AssetSN;
            this.Department = Department;
            this.id = id;
           
            InitializeComponent();
            initall();
            initcombo();
            label3.Text = AssetSN;
            label4.Text = AssetName;
            label6.Text = Department;
            numericUpDown1.Controls[0].Visible = false;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void initall()
        {
            SqlConnection sql = new SqlConnection(Program.connectionString);
            try
            {
                sql.Open();
                string comand = @"SELECT eme.ID, eme.EMReportDate 
                   FROM Assets a JOIN EmergencyMaintenances eme ON a.id = eme.AssetID WHERE a.id = " + id;

                SqlCommand command = new SqlCommand(comand, sql);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            EmID = (int)reader["id"];
                            string report = reader["EMReportDate"].ToString();
                            DateTime parsedDateTime = DateTime.ParseExact(report, "dd.MM.yyyy H:mm:ss", CultureInfo.InvariantCulture);
                            dateTimePicker1.MinDate = parsedDateTime;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                sql.Close();
            }
        }


        private int getIndexParts(string name)
        {
            SqlConnection sql = new SqlConnection(Program.connectionString);
            int i = -1;
            try
            {
                sql.Open();
                string comand = @"SELECT * FROM Parts WHERE Name = @Name";

                SqlCommand command = new SqlCommand(comand, sql);
                command.Parameters.AddWithValue("Name", name);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                sql.Close();
            }
            return i;
        }
        private void initcombo()
        {
            SqlConnection sql = new SqlConnection(Program.connectionString);
            try
            {
                sql.Open();
                string comand = @"SELECT * FROM Parts ORDER BY id";

                SqlCommand command = new SqlCommand(comand, sql);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string part = reader["Name"].ToString();
                            comboBox1.Items.Add(part);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                sql.Close();
            }
        }
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {

                Hide();
                Form4 from = new Form4();
                from.Show();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                bool useed = false;
               foreach(DataGridViewRow r in dataGridView1.Rows) {
                    if(r.Cells[0].Value == comboBox1.Items[comboBox1.SelectedIndex])
                    {
                        useed = true;   
                        break;
                    }
                }
               if(useed)
                {
                    DialogResult result = MessageBox.Show("Данный элемент уже есть в списке вы хотите его добавить сонова?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(result == DialogResult.Yes)
                    {
                        dataGridView1.Rows.Add(comboBox1.Items[comboBox1.SelectedIndex], ((int)numericUpDown1.Value), "Remove");
                    }
                } else
                {
                    dataGridView1.Rows.Add(comboBox1.Items[comboBox1.SelectedIndex], ((int)numericUpDown1.Value), "Remove");
                }
               
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Rows.RemoveAt(e.RowIndex);
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
