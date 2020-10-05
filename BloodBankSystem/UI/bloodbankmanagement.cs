using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using BloodBankSystem;
using BloodBankSystem.UI;

namespace BloodBankManagementSystem
{
    public partial class Bloodbank : Form
    {
        public Bloodbank()
        {
            InitializeComponent();
            Control.SetInitial(this);
           
            br.Hide();
        }


        private void Btn_max_Click(object sender, EventArgs e)
        {
            Control.DoMaximize(this);
            btn_max1.BringToFront();
        }

        private void Btn_max1_Click(object sender, EventArgs e)
        {
            Control.DoMaximize(this);
            btn_max.BringToFront();

        }

        private void Su_field_Click(object sender, EventArgs e)
        {
           // this.Hide();
            //signinform sign = new signinform();
            //  sign.Show();
        }


        private void Su_field_Click_1(object sender, EventArgs e)
        {
          //  this.Hide();
            // signinform sign = new signinform();
            // sign.Show();
        }


        private void CLose_Click(object sender, EventArgs e)
        {
            Control.Exit();
        }

        private void Min_Click(object sender, EventArgs e)
        {
            Control.Minimized(this);
        }

        private void FullScrn_Click(object sender, EventArgs e)
        {
            Control.DoFullScreen(this);
        }

        private void su_field_Click_3(object sender, EventArgs e)
        {
            this.Hide();
            signinform signinform = new signinform();
            signinform.Show();
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

        private void sbfield_Click(object sender, EventArgs e)
        {
            mainpanel.Controls.Clear();
            SearchBlood searchBlood = new SearchBlood();
            searchBlood.TopLevel = false;
            mainpanel.Controls.Add(searchBlood);
            searchBlood.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            searchBlood.Dock = DockStyle.Fill;
            searchBlood.Show();
        }

        private void cufield_Click(object sender, EventArgs e)
        {
            mainpanel.Controls.Clear();
            ContactU contactU = new ContactU();
            contactU.TopLevel = false;
            mainpanel.Controls.Add(contactU);
            contactU.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            contactU.Dock = DockStyle.Fill;
            contactU.Show();
        }
    }
}

