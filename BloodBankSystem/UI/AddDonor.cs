using BloodBankSystem.BLL;
using BloodBankSystem.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodBankSystem.UI
{
    public partial class AddDonor : Form
    {
        public AddDonor()
        {
            InitializeComponent();
        }
        DonorDAL d = new DonorDAL();
        DonorBLL b = new DonorBLL();

        //variable for storage of gender value
        string gender;

        //global variable for image
        string imgName = "No-Image.png";

        private void button3_Click(object sender, EventArgs e)
        {

            if (fulln != null && email != null && add != null && gender != null && mbl != null && dateTimePicker1 != null && bloodg != null && ellig != null && imgName != null)
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

                //adding the value from UI to Database

                //create a boolean variable to check if the data is inserted successfully
                bool success = d.Insert(b);


                //check if the data is inserted successfully
                if (success == true)
                {
                    MessageBox.Show("Data Successfully Entered!");
                }
                else
                {
                    //failed to add user
                    MessageBox.Show("Failed to Sign UP Try Again!");
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
            fulln.Text = "";

            email.Text = "";
            mbl.Text = "";
            add.Text = "";
            bloodg.Text = "--Select--";
            ellig.Text = "--Select--";

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

        private void AddDonor_Load(object sender, EventArgs e)
        {
            //first we need to get the image path
            string paths = Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);

            string imgPath = paths + "\\Images\\No-Image.png";

            //display image in picture box
            pictureBox1.Image = new Bitmap(imgPath);
            try
            {
                String Query = "Select max(donorId) from DonorTbl";
                DataSet ds = d.QuerySelector(Query);
                int count = int.Parse(ds.Tables[0].Rows[0][0].ToString());

                labelID.Text = (count + 1).ToString();
            }
            catch (Exception Ex)
            {
                //dispose error message if there is any exceptional error
                //  MessageBox.Show(Ex.Message);
                labelID.Text = "1";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            gender = "FeMale";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Male";
        }
    }
}
