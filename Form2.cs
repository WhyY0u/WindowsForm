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

    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            FillData();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void FillData()
        {
            string connectionString = "Data Source=WIN-0B908PJ6FUC;Initial Catalog=Session1;Integrated Security=True";
            
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
                                Console.WriteLine("AssetSN: {0}, AssetName: {1}, NumberofEMs: {2}, LastEMDate: {3}",
                                    reader["AssetSN"], reader["AssetName"], reader["NumberofEMs"], reader["LastEMDate"]);
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
    }
}
