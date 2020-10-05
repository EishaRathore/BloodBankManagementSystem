using BloodBankSystem;
using BloodBankSystem.DAL;
using BloodBankSystem.UI;
using BloodBankSystem.userBLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodBankManagementSystem
{
    public partial class signinform : Form
    {
        public signinform()
        {
            InitializeComponent();
        }

        //create objects of userDAL and userBLL
        UserbLL u = new UserbLL();
        UserDAL dal = new UserDAL();

       

        private void Login_field_Click(object sender, EventArgs e)
        {
           

//            tick.Show();
  //          tick1.Show();
             //get the values from UI
              u.UserEmail = utextbox.Text;
            u.UserRole = comboBox1.Text;
              u.UserName = utextbox.Text;
              u.UserPassword = uptextbox.Text;
              //adding the value from UI to Database
              //create a boolean variable to check if the data is inserted successfully
              bool issuccess = dal.Valid(u);

              //check if the data is inserted successfully
              if (issuccess == true)
              {
              
                if (comboBox1.Text=="User")
                {
                    //data or user added successfully
                    this.Hide();
                    SignUpPOPUP f1 = new SignUpPOPUP(utextbox.Text);
                    f1.Show();
                }else if(comboBox1.Text == "Admin")
                {
                    //data or user added successfully
                    this.Hide();
                    Admin f1 = new Admin(utextbox.Text);
                    f1.Show();
                }
                 
              }
   
        }

      
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if(utextbox.Text==" USER NAME")
            {
                utextbox.Text = "";
                utextbox.ForeColor = Color.Black;
            }
            
        }

        private void uptextbox_Enter(object sender, EventArgs e)
        {
            if (uptextbox.Text == " PASSWORD")
            {
                uptextbox.Text = "";
                uptextbox.ForeColor = Color.Black;
                uptextbox.UseSystemPasswordChar = true;
              
            }
           
        }

        private void uptextbox_Leave(object sender, EventArgs e)
        {
            if (uptextbox.Text == "")
            {
                uptextbox.Text = " PASSWORD";
                uptextbox.ForeColor = Color.Silver;
                uptextbox.UseSystemPasswordChar = false;
            }
            
        }

        private void utextbox_Leave(object sender, EventArgs e)
        {
           if(utextbox.Text=="")
            {
                utextbox.Text = " USER NAME";
                utextbox.ForeColor = Color.Silver;
                
            }
            
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            if(uptextbox.Text != " PASSWORD")
            {
                uptextbox.UseSystemPasswordChar = true;
                pictureBox9.Visible = false;
                pictureBox10.Visible = true;
            }
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            if (uptextbox.Text != " PASSWORD")
            {
                uptextbox.UseSystemPasswordChar = false;
                pictureBox9.Visible = true;
                pictureBox10.Visible = false;
            }
 
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void signinform_Load(object sender, EventArgs e)
        {
            tick.Hide();
            tick1.Hide();

        }

        private void utextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignUpForm signUpForm = new SignUpForm();
            signUpForm.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        /*  private void PictureBox8_Click(object sender, EventArgs e)
{
//this.Close();
this.Hide();
signin_popup si = new signin_popup();
si.Show();
}*/
    }
}
