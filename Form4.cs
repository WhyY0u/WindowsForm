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
    public partial class Form4 : Form
    {
        int index = 0;
        public Form4()
        {
            InitializeComponent();
            initTable();
            if (dataGridView1.Rows[0] != null)
            {
                dataGridView1.Rows[0].Selected = true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void initTable() {
            SqlConnection connection = new SqlConnection(Program.connectionString);
            try
            {
                connection.Open();
                string cmd = "SELECT a.AssetSN, a.AssetName, d.Name, emp.FirstName, emp.LastName, CONVERT(VARCHAR(10), eme.EMReportDate) AS EMReportDate FROM Assets a JOIN EmergencyMaintenances eme ON a.id = eme.AssetID JOIN Employees emp ON a.EmployeeID = emp.id JOIN DepartmentLocations dep ON a.DepartmentLocationID = dep.id JOIN Departments d ON dep.id = d.id";
                SqlCommand command = new SqlCommand(cmd,connection);
                using(SqlDataReader reader = command.ExecuteReader())
                {
                    if(reader.HasRows)
                    {
                        while(reader.Read())
                        {
                            dataGridView1.Rows.Add(reader["AssetSN"], reader["AssetName"], reader["EMReportDate"].ToString().Replace('-', '/'), reader["FirstName"] + " " + reader["LastName"], reader["Name"]);
                        }
                    }
                }
            }
            catch
            {
                connection.Close();
            }
          

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (index != -1)
            {
                Form5 from = new Form5(dataGridView1.Rows[index].Cells[0].Value.ToString(), dataGridView1.Rows[index].Cells[1].Value.ToString(), dataGridView1.Rows[index].Cells[4].Value.ToString());
                Hide();
                from.Show();
            }


        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.RowIndex != -1)
            {
                    dataGridView1.Rows[e.RowIndex].Selected = true;
                    index = e.RowIndex;


            }
        }
    }
}
