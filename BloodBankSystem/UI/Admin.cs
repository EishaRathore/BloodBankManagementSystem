using BloodBankManagementSystem;
using BloodBankSystem.Classes;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Deployment.Application;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace BloodBankSystem.UI
{
    public partial class Admin : Form
    {
        //fields
        private IconButton currentButton;
        private GradientPanel leftborderBtn;
        private Form currentChildForm;

        //constructor
        public Admin(string img)
        {
            InitializeComponent();
            AControl.SetInitial(this);
            leftborderBtn = new GradientPanel();
            leftborderBtn.Size = new Size(4, 45);
            gradientPanel1.Controls.Add(leftborderBtn);
            br.Text = img;
            br.Hide();
        }
        //structs
        private struct RGBColor
        {
            public static Color color1 = Color.FromArgb(234, 250, 250);
        }


        //methods
        private void ActivateButton(object senderBtn, Color color)
        {

            if (senderBtn != null)
            {
                disableButton();
                //button
                currentButton = (IconButton)senderBtn;
                currentButton.BackColor = Color.Transparent;
                currentButton.ForeColor = color;
                currentButton.TextAlign = ContentAlignment.MiddleCenter;
                currentButton.IconColor = color;
                currentButton.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentButton.ImageAlign = ContentAlignment.MiddleRight;
                //left border button
                leftborderBtn.BackColor = color;
                leftborderBtn.Location = new Point(0, currentButton.Location.Y);
                leftborderBtn.Visible = true;
                leftborderBtn.BringToFront();
                //icon current child form
                iconCurrentChild.IconChar = currentButton.IconChar;
                iconCurrentChild.IconColor = color;
            }
        }

        private void disableButton()
        {
            if (currentButton != null)
            {
                currentButton.BackColor = Color.Transparent;
                currentButton.ForeColor = Color.Maroon;
                currentButton.TextAlign = ContentAlignment.MiddleCenter;
                currentButton.IconColor = Color.Maroon;
                currentButton.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentButton.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void CLose_Click(object sender, EventArgs e)
        {
            AControl.Exit();
        }

        private void btn_max_Click(object sender, EventArgs e)
        {
            AControl.DoMaximize(this);
            btn_max1.BringToFront();
        }

        private void btn_max1_Click(object sender, EventArgs e)
        {
            AControl.DoMaximize(this);
            btn_max.BringToFront();
        }

        private void Min_Click(object sender, EventArgs e)
        {
            
        }

        private void FullScrn_Click(object sender, EventArgs e)
        {
            AControl.DoFullScreen(this);
        }

        private void DashBoard_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColor.color1);
            this.label1.Text = "DashBoard";
            DashBoard db = new DashBoard();
            db.TopLevel = false;
            panelchanger.Controls.Add(db);
            db.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            db.Dock = DockStyle.Fill;
            db.BringToFront();
            db.Show();
        }

       
        private void iconButton2_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColor.color1);
            ActivateButton(sender, RGBColor.color1);
            this.label1.Text = "Manage Blood Group";
            ManageBloodG db = new ManageBloodG();
            db.TopLevel = false;
            panelchanger.Controls.Add(db);
            db.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            db.Dock = DockStyle.Fill;
            db.BringToFront();
            db.Show();
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColor.color1);
            ActivateButton(sender, RGBColor.color1);
            this.label1.Text = "Add Donor";
            AddDonor db = new AddDonor();
            db.TopLevel = false;
            panelchanger.Controls.Add(db);
            db.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            db.Dock = DockStyle.Fill;
            db.BringToFront();
            db.Show();
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColor.color1);
            ActivateButton(sender, RGBColor.color1);
            this.label1.Text = "Donor List";
            DonorList db = new DonorList();
            db.TopLevel = false;
            panelchanger.Controls.Add(db);
            db.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            db.Dock = DockStyle.Fill;
            db.BringToFront();
            db.Show();
        }


      

        private void reset()
        {
            iconCurrentChild.IconChar = IconChar.Home;
            iconCurrentChild.IconColor = Color.Maroon;
            label1.Text = "Home";
        }
      
        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            currentChildForm.Close();

            reset();
        }

        private void openChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                //open only form
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            //panelDesktop.Controls.Add(childForm);
            //panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            label1.Text = childForm.Text;
        }

        private void iconPictureBox1_DoubleClick(object sender, EventArgs e)
        {
            reset();
        }

        private void iconPictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            reset();
        }

        private void Home_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColor.color1);
            ActivateButton(sender, RGBColor.color1);
            this.label1.Text = "Home";
            mainhome db = new mainhome();
            db.TopLevel = false;
            panelchanger.Controls.Add(db);
            db.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            db.Dock = DockStyle.Fill;
            db.BringToFront();
            db.Show();
        }

        private void Admin_Load(object sender, EventArgs e)
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

        private void circularProfilePic_Click(object sender, EventArgs e)
        {

        }

        private void iconPictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Logout(object sender, EventArgs e)
        {
            this.Hide();
            signinform sgn = new signinform();
            sgn.BringToFront();
            sgn.Show();
        }
    }
}
