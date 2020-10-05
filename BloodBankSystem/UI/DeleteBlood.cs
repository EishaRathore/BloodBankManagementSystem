using BloodBankSystem.BLL;
using BloodBankSystem.DAL;
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
    public partial class DeleteBlood : Form
    {
        public DeleteBlood()
        {
            InitializeComponent();
        }
        DonorDAL d = new DonorDAL();
        DonorBLL b = new DonorBLL();

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void DeleteBlood_Load(object sender, EventArgs e)
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

        private void circularBtn1_Click(object sender, EventArgs e)
        {
            if ( textBox1 != null)
            {

                int x = 0;

                Int32.TryParse(textBox1.Text, out x);
                //get the values from UI
                b.donorId = x;
                //adding the value from UI to Database

                //create a boolean variable to check if the data is inserted successfully
                bool success = d.Delete(b);


                //check if the data is inserted successfully
                if (success == true)
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
                else
                {
                    //failed to add user
                    MessageBox.Show("this donor id is not existed Try Again!");
                }

            }
            else
                MessageBox.Show("Fill Out All fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //clear text boxes
            Clear();

        }
        //method or function to clear text boxes

        public void Clear()
        {
            textBox1.Text = "";
        }
    }

}
