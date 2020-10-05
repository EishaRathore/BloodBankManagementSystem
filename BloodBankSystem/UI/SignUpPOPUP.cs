using BloodBankManagementSystem;
using BloodBankSystem.Classes;
using BloodBankSystem.DAL;
using BloodBankSystem.userBLL;
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
    public partial class SignUpPOPUP : Form
    {
        public SignUpPOPUP(string img)
        {
            InitializeComponent();
            Control1.SetInitial(this);
            br.Text = img;
            br.Hide();
          
        }
        UserbLL u = new UserbLL();
        UserDAL dal = new UserDAL();
        
        private void FullScrn_Click_1(object sender, EventArgs e)
        {
            Control1.DoFullScreen(this);
        }

        private void Min_Click_1(object sender, EventArgs e)
        {
            Control1.Minimized(this);
        }

        private void CLose_Click(object sender, EventArgs e)
        {
            Control1.Exit();
        }

        private void btn_max_Click(object sender, EventArgs e)
        {
            Control1.DoMaximize(this);
            btn_max1.BringToFront();
        }

        private void btn_max1_Click(object sender, EventArgs e)
        {
            Control1.DoMaximize(this);
            btn_max.BringToFront();
        }

        private void SignUpPOPUP_Load(object sender, EventArgs e)
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
                SqlCommand cmd = new SqlCommand("select imSource From UserTbl where userName='" + br.Text + "'", conn);

                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {

                    String welcomeUImg = (sdr["imSource"].ToString());
                    if (welcomeUImg != null)
                    {
                        string paths = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));


                        // paths to destination folder
                        string imagePath = paths + "\\Images\\" + welcomeUImg;

                        //display in picture box
                        circularProfilePic.Image = new Bitmap(imagePath);
                    }
                }
                else
                {
                  
                    string paths = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                    MessageBox.Show("No Result Found");
                    // paths to destination folder
                    string imagePath = paths + "\\images\\No-user.png";
                    //display in picture box
                    circularProfilePic.Image = new Bitmap(imagePath);
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
      
        public void Clear()
        {
            string paths = Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);
            string imagePath = paths + "\\images\\No-Image.png";
            circularProfilePic.Image = new Bitmap(imagePath);
        }

   
     
        private void cufield_Click_1(object sender, EventArgs e)
        {
            mainpanel.Controls.Clear();
            ContactU contactU = new ContactU();
            contactU.TopLevel = false;
            mainpanel.Controls.Add(contactU);
            contactU.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            contactU.Dock = DockStyle.Fill;
            contactU.Show();
        }

        private void sbfield_Click_1(object sender, EventArgs e)
        {
            mainpanel.Controls.Clear();
            SearchBlood searchBlood = new SearchBlood();
            searchBlood.TopLevel = false;
            mainpanel.Controls.Add(searchBlood);
            searchBlood.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            searchBlood.Dock = DockStyle.Fill;
            searchBlood.Show();
        }

        private void wbdfield_Click(object sender, EventArgs e)
        {

            mainpanel.Controls.Clear();
            WBDonor wBDonor = new WBDonor();
            wBDonor.TopLevel = false;
            mainpanel.Controls.Add(wBDonor);
            wBDonor.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            wBDonor.Dock = DockStyle.Fill;
            wBDonor.Show();
        }

        private void bdfield_Click(object sender, EventArgs e)
        {
            mainpanel.Controls.Clear();
            BecomeDonor becomeDonor = new BecomeDonor();
            becomeDonor.TopLevel = false;
            mainpanel.Controls.Add(becomeDonor);
            becomeDonor.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            becomeDonor.Dock = DockStyle.Fill;
            becomeDonor.Show();
        }

        private void Aboutfield_Click(object sender, EventArgs e)
        {
            mainpanel.Controls.Clear();
            About aboutUs = new About();
            aboutUs.TopLevel = false;
            mainpanel.Controls.Add(aboutUs);
            aboutUs.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            aboutUs.Dock = DockStyle.Fill;
            aboutUs.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Hide();
            signinform sgn = new signinform();
            sgn.BringToFront();
            sgn.Show();
        }

        private void mainpanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
