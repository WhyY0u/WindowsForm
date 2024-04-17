using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
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
                string str = "Data Source=DESKTOP-400BU96\\SQLEXPRESS;Initial Catalog=Session1;Integrated Security=True";

                SqlConnection connection = new SqlConnection(str);
                try
                {


                    connection.Open();
                    string query = "SELECT * FROM employees WHERE UserName = @UserName AND Password = @Password";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserName", textBox1.Text);
                    command.Parameters.AddWithValue("@Password", textBox2.Text);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                if (reader["isAdmin"].ToString() == "1");
                                {
                                    Hide();
                                    Form2 f = new Form2();
                                    f.Show();

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
            } else
            {
                label5.Visible = true;
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

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            if(textBox1.TextLength > 0 && textBox2.TextLength > 0)
            {
                label5.Visible = false;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.TextLength > 0 && textBox1.TextLength > 0)
            {
                label5.Visible = false;
            }
        }
    }
}
