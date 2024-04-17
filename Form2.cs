﻿using System;
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

    public partial class Form2 : Form
    {

        string SelectedAssetSN, SelectedAssetName;
        public Form2()
        {
            InitializeComponent();
            FillData();
            if (dataGridView1.Rows[0] != null)
            {
                dataGridView1.Rows[0].Selected = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void FillData()
        {
            string connectionString = "Data Source=DESKTOP-400BU96\\SQLEXPRESS;Initial Catalog=Session1;Integrated Security=True";
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string commandText = "SELECT A.AssetSN,A.AssetName, CONVERT(VARCHAR(10), MAX(EM.EMEndDate), 104) AS LastEMDate, COUNT(EM.ID) AS NumberofEMs FROM Assets A LEFT JOIN EmergencyMaintenances EM ON A.ID = EM.AssetID GROUP BY A.AssetSN, A.AssetName";
                    SqlCommand sqlCommand = new SqlCommand(commandText, connection);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            Console.WriteLine("OK");
                            while (reader.Read())
                            {
                               
                                dataGridView1.Rows.Add(reader["AssetSN"], reader["AssetName"], reader["LastEMDate"].ToString().Length <= 0 ?  "-" : reader["LastEMDate"], reader["NumberofEMs"]);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

            }

            int index = dataGridView1.Columns["LastClosedEM"].Index;


           foreach(DataGridViewRow row in dataGridView1.Rows)
            {
               
                if(row.Cells[index].Value != null)
                {
                    bool check = row.Cells[index].Value.ToString().Contains("-");
                    if (check)  {
                        
                        row.Cells[index].Style.BackColor = Color.Red;
                        row.Cells[0].Style.BackColor = Color.Red;
                        row.Cells[1].Style.BackColor = Color.Red;
                        row.Cells[3].Style.BackColor = Color.Red;


                    }
                }
            }
        }


        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tableUpdateStatementBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                
                dataGridView1.Rows[e.RowIndex].Selected = true;
                SelectedAssetSN = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                SelectedAssetName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-400BU96\\SQLEXPRESS;Initial Catalog=Session1;Integrated Security=True";
            string departamentName = null;
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                string command = "SELECT * FROM Assets WHERE AssetSN = @AssetSN AND AssetName = @AssetName";
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                sqlCommand.Parameters.AddWithValue("@AssetSN", SelectedAssetSN);
                sqlCommand.Parameters.AddWithValue("@AssetName", SelectedAssetName);
                int DepartamentID = -1;
                using (SqlDataReader data = sqlCommand.ExecuteReader())
                {
                    if (data.HasRows)
                    {

                        while (data.Read())
                        {
                            DepartamentID = (int)data["DepartmentLocationID"];

                        }
                    }
                }
                string command2 = "SELECT d.Name FROM Department d JOIN DepartmentLocation dl ON d.id = dl.Department JOIN Assets a ON dl.id = a.DepartmentLocation WHERE a.DepartmentLocationID = " + DepartamentID;
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if(reader.HasRows)
                    {
                        while(reader.Read())
                        {
                            departamentName = reader["Name"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)  {
                connection.Close();
            } 
            Close();
            Form3 from3 = new Form3(SelectedAssetSN, SelectedAssetName, departamentName);
            from3.Show();
        }
    }
}
