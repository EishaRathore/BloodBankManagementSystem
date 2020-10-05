using BloodBankSystem.BLL;
using BloodBankSystem.DAL;
using BloodBankSystem.userBLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodBankSystem.UI
{
    public partial class SearchBlood : Form
    {
        public SearchBlood()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //create a static string method to connect database
            string myconstn = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;

            ///create an object to connect database
            SqlConnection conn = new SqlConnection(myconstn);
            //open database connection
            conn.Open();

            try
            {

                //create sql command to run query
                SqlCommand cmd = new SqlCommand("Select * from DonorTbl where dbloodG = '"+comboBox1.Text+"' ", conn);

                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.Read())
                {

                    wbdfield.Text = (sdr["dFullName"].ToString());
                    label11.Text = (sdr["dcontact"].ToString());
                    label13.Text = (sdr["daddress"].ToString());
                    label9.Text = (sdr["dGender"].ToString());
                    label15.Text = (sdr["dEllig"].ToString());
                    label7.Text = (sdr["demail"].ToString());
                    label6.Text = (sdr["dbloodG"].ToString());

                   String welcomeUImg = (sdr["dimSource"].ToString());
                    if ( welcomeUImg!=null)
                    {
                        string paths = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));

                      
                            // paths to destination folder
                            string imagePath = paths + "\\Images\\" + welcomeUImg;
                          
                            //display in picture box
                            circularPic1.Image = new Bitmap(imagePath);
                    }
                }
                else
                {
                    wbdfield.Text = "";
                    label11.Text = "";
                    label13.Text = "";
                    label9.Text = "";
                    label15.Text = "";
                    label7.Text = "";
                    label6.Text = "";
                    string paths = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                    MessageBox.Show("No Result Found");
                    // paths to destination folder
                    string imagePath = paths + "\\images\\No-user.png";
                    MessageBox.Show(imagePath);

                    //display in picture box
                    circularPic1.Image = new Bitmap(imagePath);

                    paths = null;
                }

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
