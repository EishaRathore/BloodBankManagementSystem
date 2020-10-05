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
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
        }
        DonorDAL d = new DonorDAL();
        DonorBLL b = new DonorBLL();
        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            //create a static string method to connect database
            string myconstn = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;

            ///create an object to connect database
            SqlConnection conn = new SqlConnection(myconstn);
            //open database connection
            conn.Open();

            try
            {

              
                    String Query = "SELECT(SELECT COUNT(*) FROM DonorTbl) AS Total_Employees,(SELECT COUNT(*)FROM   ContactTbl) AS No_Of_Departments";
                    DataSet ds = d.QuerySelector(Query);
              
                    int count = int.Parse(ds.Tables[0].Rows[0][0].ToString());
            
                int count1 = int.Parse(ds.Tables[0].Rows[0][1].ToString());

                label5.Text = (count).ToString();
                    label6.Text = (count1).ToString();

  
            }
            catch (Exception Ex)
            {
                //dispose error message if there is any exceptional error
                MessageBox.Show(Ex.Message);
            }
            finally
            {
                //close database connection
                conn.Close();
            }
        }
    }
}
