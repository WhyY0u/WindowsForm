using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        int assetID;


        public Form3(string assetsSN, string assetName, string departament, int assetID)
        {
            InitializeComponent();
            InitComboBox();
            label7.Text = assetsSN;
            label8.Text = assetName;
            label10.Text = departament;
            this.assetID = assetID;

        }

  
        public void InitComboBox()
        {
            comboBox1.Items.Add("Low");
            comboBox1.Items.Add("Medium");
            comboBox1.Items.Add("Height");
            comboBox1.SelectedIndex = 1;
        }



        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            Form2 from = new Form2();
            from.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (comboBox1.SelectedIndex == -1)
            {
                label14.Visible = true;
                return;
            }

            if (textBox1.Text.Length <= 0)
            {
                label13.Visible = true;
                return;
            }

            if(textBox2.Text.Length <= 0)
            {
                label12.Visible = true;
                return;
            }


            SqlConnection sqlConnection = new SqlConnection(Program.connectionString);
            try
            {
                sqlConnection.Open();
                string commandstr = "INSERT INTO Priorities (Name) OUTPUT INSERTED.ID VALUES (@Name)";
                int pId = -1;

                using (SqlCommand command = new SqlCommand(commandstr, sqlConnection))
                {

                    command.Parameters.AddWithValue("@Name", comboBox1.SelectedItem.ToString());
                    pId = (int)command.ExecuteScalar();
                }

                string commandsstr = "INSERT INTO EmergencyMaintenances (AssetID, PriorityID, DescriptionEmergency, OtherConsiderations, EMReportDate) VALUES (@AssetID ,@PriorityID, @DescriptionEmergency, @OtherConsiderations, @EMReportDate)";
                using (SqlCommand command = new SqlCommand(commandsstr, sqlConnection))
                {

                    command.Parameters.AddWithValue("@AssetID", assetID);
                    command.Parameters.AddWithValue("@PriorityID", pId);
                    command.Parameters.AddWithValue("@DescriptionEmergency", textBox1.Text);
                    command.Parameters.AddWithValue("@OtherConsiderations", textBox2.Text);
                    command.Parameters.AddWithValue("@EMReportDate", DateTime.Now.ToString("yyyy-MM-dd"));
                    int rowsAffected = command.ExecuteNonQuery();

                }

                    Close();
                    Form2 form2 = new Form2();
                    form2.Show();
                

            } catch (Exception )
            {
                sqlConnection.Close();
            }
           


        }



        
        


        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length >= 1 && label12.Visible)
            {
                label12.Visible = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length >= 1 && label13.Visible)
            {
                label13.Visible = false;
            }
        }
    }
}
