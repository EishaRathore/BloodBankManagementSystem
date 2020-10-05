using BloodBankSystem.BLL;
using BloodBankSystem.DAL;
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
    public partial class Upate : Form
    {
        public Upate()
        {
            InitializeComponent();
        }
        DonorDAL d = new DonorDAL();
        DonorBLL b = new DonorBLL();

        //variable for storage of gender value
        string gender;
        String imgName;
        private void circularBtn1_Click(object sender, EventArgs e)
        {
            string data = textBox1.Text;
            //create a static string method to connect database
            string myconstn = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;

            ///create an object to connect database
            SqlConnection conn = new SqlConnection(myconstn);

            try
            {
                SqlCommand cmd = new SqlCommand("select * from DonorTbl where donorId='"+data+"'", conn);

                conn.Open();
                SqlDataReader DR1 = cmd.ExecuteReader();
                if (DR1.Read())
                {
                    labelID.Text = DR1.GetValue(0).ToString();
                    fulln.Text = DR1.GetValue(1).ToString();
                    email.Text = DR1.GetValue(2).ToString();
                    mbl.Text = DR1.GetValue(3).ToString();
                    add.Text = DR1.GetValue(4).ToString();
                    dateTimePicker1.Text = DR1.GetValue(5).ToString();
                    bloodg.Text = DR1.GetValue(6).ToString();
                    ellig.Text = DR1.GetValue(7).ToString();
                    string gend = DR1.GetValue(8).ToString();
                    if (DR1.GetValue(8).ToString() == "Male")
                    {
                        radioButton1.Checked = true;
                    }
                    else
                    {
                        radioButton2.Checked = true;
                    }
                    String welcomeUImg = DR1.GetValue(9).ToString();
                    imgName = welcomeUImg;
                    if (welcomeUImg != null)
                    {
                        string paths = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));


                        // paths to destination folder
                        string imagePath = paths + "\\Images\\" + welcomeUImg;
                       
                        //display in picture box
                        pictureBox1.Image = new Bitmap(imagePath);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Donor Id Try Again!");
                }
                Clear();
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

        //method or function to clear text boxes

        public void Clear()
        {
            textBox1.Text = "";
             }

        private void button3_Click(object sender, EventArgs e)
        {
            if (fulln != null && email != null && add != null && gender != null && mbl != null && dateTimePicker1 != null && bloodg != null && ellig != null)
            {


                //get the values from UI
                b.DFullName = fulln.Text;
                b.dEmail = email.Text;
                b.DGender = gender;
                b.DAddress = add.Text;
                b.DConatct = mbl.Text;
                b.AddDate = DateTime.Now;
                b.DBloodG = bloodg.Text;
                b.DEllig = ellig.Text;
                b.DImageSource = imgName;
                int x = 0;

                Int32.TryParse(labelID.Text, out x);
                b.donorId = x;

                //adding the value from UI to Database

                //create a boolean variable to check if the data is inserted successfully
                bool success = d.Update(b);


                //check if the data is inserted successfully
                if (success == true)
                {
                    MessageBox.Show("Data Successfully Updated!");
                }
                else
                {
                    //failed to add user
                    MessageBox.Show("Failed to Update Data Try Again!");
                }

            }
            else
                MessageBox.Show("Fill Out All fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //clear text boxes
            Clear1();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Male";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            gender = "FeMale";
        }
        public void Clear1()
        {
            fulln.Text = "";

            email.Text = "";
            mbl.Text = "";
            add.Text = "";
            bloodg.Text = "--Select--";
            ellig.Text = "--Select--";
            radioButton1.Checked = false;
            radioButton1.Checked = false;
            //clear the picture box
            //first we need to get the image path
            string paths = Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);

            string imgPath = paths + "\\Images\\No-Image.png";

            //display image in picture box
            pictureBox1.Image = new Bitmap(imgPath);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //write code to upload the image of user
            //open dialogue box to select image
            OpenFileDialog open = new OpenFileDialog();

            //filter the file type to aloow image of specified  file type
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.PNG;)|*.jpg; *.jpeg; *.gif; *.PNG;";

            //check if the file is selected or not
            if (open.ShowDialog() == DialogResult.OK)
            {
                //check if the file exists or not
                if (open.CheckFileExists)
                {
                    //Display the selected file on picture box
                    pictureBox1.Image = new Bitmap(open.FileName);

                    //rename the image we selected
                    //get the extension of image
                    string ext = Path.GetExtension(open.FileName);

                    //generate random integer
                    Random random = new Random();
                    int randomint = random.Next(0, 1000);

                    //rename the image name
                    imgName = "BBMS" + randomint + ext;

                    //get the path of the selected image 
                    string sourcepath = open.FileName;

                    //get the path of destination
                    string paths = Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);

                    //paths to destination folder
                    string destinationpath = paths + "\\Images\\" + imgName;

                    //copy image to destination folder
                    File.Copy(sourcepath, destinationpath);

                    //display message
                    MessageBox.Show("Image Successfully Added!");
                }
            }
        }
    }
}
