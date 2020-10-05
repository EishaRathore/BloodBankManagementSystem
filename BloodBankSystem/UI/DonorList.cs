using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodBankSystem.UI
{
    public partial class DonorList : Form
    {
        public DonorList()
        {
            InitializeComponent();
        }

        private void DonorList_Load(object sender, EventArgs e)
        {
            //create a static string method to connect database
            string myconstn = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;

            ///create an object to connect database
            SqlConnection conn = new SqlConnection(myconstn);
            //open database connection
            conn.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM DonorTbl", conn);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);

            //method 1 - direct method
            dataGridView1.DataSource = dtbl;

            //method 2 : DG Columns
          //  dataGridView1.AutoGenerateColumns = false;
           // dataGridView1.DataSource = dtbl;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
           
        }
    }
}
