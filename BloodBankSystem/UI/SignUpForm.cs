using BloodBankManagementSystem;
using BloodBankSystem.DAL;
using BloodBankSystem.UI;
using BloodBankSystem.userBLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodBankSystem
{
    public partial class SignUpForm : Form
    {
        public SignUpForm()
        {
            InitializeComponent();
        }
        //create objects of userDAL and userBLL
        UserbLL u = new UserbLL();
        UserDAL dal = new UserDAL();

        
        string imgSouece = "No-Image.png";
       protected string Gender;
        private void Cmdsignup_Click(object sender, EventArgs e)
        {
            //get the values from UI
            u.UserName = fnamefield.Text;
            u.UserEmail = efield.Text;
            u.UserConatct = mblfield.Text;
            u.UserAddress = addfield.Text;
            u.UserPassword = pfield.Text;
            u.UserCfrmPassword = cpfield.Text;
            u.UserRole = comboBox1.Text;
            u.Gender = Gender;
            u.AddDate = DateTime.Now;
            u.ImageSource = imgSouece;

            //adding the value from UI to Database
            //create a boolean variable to check if the data is inserted successfully
            bool success = dal.Insert(u);
            

            //check if the data is inserted successfully
            if (success == true )
            {
                
                //data or user added successfully
                this.Hide();
                SignUpPOPUP f1 = new SignUpPOPUP(fnamefield.Text);
                f1.Show();
            }
            else
            {
                //failed to add user
                MessageBox.Show("Failed to Sign UP Try Again!");
            }

           
            //clear text boxes
            Clear();
        }

        private void maleradiobtn_CheckedChanged(object sender, EventArgs e)
        {
            Gender = "Male";
        }

        private void femaleradiobtn_CheckedChanged(object sender, EventArgs e)
        {
            Gender = "Female";
        }

        //method or function to clear text boxes

        public void Clear()
        {
            fnamefield.Text = "";
            pfield.Text = "";
            cpfield.Text = "";
            efield.Text = "";
            mblfield.Text = "";
            addfield.Text = "";
            string paths = Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);
        }

        private void SelectImg_Click(object sender, EventArgs e)
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
                    profileImgfield.Image = new Bitmap(open.FileName);

                    //rename the image we selected
                    //get the extension of image
                    string ext = Path.GetExtension(open.FileName);

                    //generate random integer
                    Random random = new Random();
                    int randomint = random.Next(0, 1000);

                    //rename the image name
                    imgSouece = "BBMS" + randomint + ext;

                    //get the path of the selected image 
                    string sourcepath = open.FileName;

                    //get the path of destination
                    string paths = Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);

                    //paths to destination folder
                    string destinationpath = paths + "\\Images\\" + imgSouece;

                    //copy image to destination folder
                    File.Copy(sourcepath, destinationpath);

                    //display message
                    MessageBox.Show("Image Successfully Added!");
                }
            }
        }

        private void profileImgfield_Click(object sender, EventArgs e)
        {

        }

        private void BloodBankManagementSystem_Load(object sender, EventArgs e)
        {
           
        }

        private void cpfield_TextChanged(object sender, EventArgs e)
        {
            if(pfield.Text!="" &&cpfield.Text == pfield.Text)
            {
                errorProvider1.SetError(cpfield, "");
            }
            else
            {
                errorProvider1.SetError(cpfield, "Password doesn't match!");
            }
        }
        private bool ValidatePass(string password, out string ErrorMessage) {
            //password validation
            var input = password;
            ErrorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Password should not be empty");
               // throw new Exception("Password should not be empty");
            }

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{8,15}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (!hasLowerChar.IsMatch(input))
            {
                ErrorMessage = "Password should contain at least one lower case letter.";
                return false;
            }
            else if (!hasUpperChar.IsMatch(input))
            {
                ErrorMessage = "Password should contain at least one upper case letter.";
                return false;
            }
            else if (!hasMiniMaxChars.IsMatch(input))
            {
                ErrorMessage = "Password should not be lesser than 8 or greater than 15 characters.";
                return false;
            }
            else if (!hasNumber.IsMatch(input))
            {
                ErrorMessage = "Password should contain at least one numeric value.";
                return false;
            }

            else if (!hasSymbols.IsMatch(input))
            {
                ErrorMessage = "Password should contain at least one special case character.";
                return false;
            }
            else
            {
                return true;
            }
        }
        private void pfield_TextChanged(object sender, EventArgs e)
        {
          

        }

        private void pfield_Leave(object sender, EventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

            this.Hide();
            signinform signinform = new signinform();
            signinform.Show();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
