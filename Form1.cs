using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void Login_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.TextLength != 0 && textBox2.TextLength != 0)
            {
                string str = "Server=localhost;Database=session1;Uid=root;Pwd=k23092003;";
                MySqlConnection connection = new MySqlConnection(str);
                try
                {


                    connection.Open();
                    string query = "SELECT * FROM employees WHERE UserName = @UserName AND Password = @Password";

                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserName", textBox1.Text);
                    command.Parameters.AddWithValue("@Password", textBox2.Text);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                if (reader.GetInt32("isAdmin") == 1)
                                {

                                }
                            }
                        } else
                        {
                            label4.Visible = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    connection.Close();
                }
            }

        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (label4.Visible) label4.Visible = false;

        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if(label4.Visible) label4.Visible = false;
        }
    }
}
