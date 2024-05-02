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
        
        public Form5(string AssetSN, string AssetName, string Department, int id)
        {
            this.AssetName = AssetName;
            this.AssetSN = AssetSN;
            this.Department = Department;
            this.id = id;
           
            InitializeComponent();
            initall();
            label3.Text = AssetSN;
            label4.Text = AssetName;
            label6.Text = Department;
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
                string comand = @"SELECT Chp.Amount, Pa.Name, eme.EMReportDate 
                   FROM Assets a JOIN EmergencyMaintenances eme ON a.id = eme.AssetID JOIN ChangedParts Chp ON Chp.EmergencyMaintenanceID = eme.id JOIN Parts Pa ON Pa.id = Chp.PartID WHERE a.id = " + id;

                SqlCommand command = new SqlCommand(comand, sql);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            string report = reader["EMReportDate"].ToString();
                            DateTime parsedDateTime = DateTime.ParseExact(report, "dd.MM.yyyy H:mm:ss", CultureInfo.InvariantCulture);
                            dateTimePicker1.MinDate = parsedDateTime;
                            comboBox1.Items.Add(reader[Name]);

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
