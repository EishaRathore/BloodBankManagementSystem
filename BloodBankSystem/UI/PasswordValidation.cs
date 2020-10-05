using BloodBankSystem.Classes;
using BloodBankSystem.DAL;
using BloodBankSystem.userBLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodBankSystem.UI
{
    public partial class PasswordValidation : Form
    {
        public PasswordValidation()
        {
            InitializeComponent();
            pasvalidcontrol.SetInitial(this);
            cnfrmpaspanel.Hide();
        }

        //create objects of userDAL and userBLL
        UserbLL u = new UserbLL();
        UserDAL dal = new UserDAL();
        private void CLose_Click(object sender, EventArgs e)
        {
            pasvalidcontrol.Exit();
        }

        private void FullScrn_Click(object sender, EventArgs e)
        {
            pasvalidcontrol.DoFullScreen(this);
        }

        private void Min_Click(object sender, EventArgs e)
        {
            pasvalidcontrol.Minimized(this);
        }

        private void btn_max_Click(object sender, EventArgs e)
        {
            pasvalidcontrol.DoMaximize(this);
            btn_max1.BringToFront();
        }

        private void btn_max1_Click(object sender, EventArgs e)
        {
            pasvalidcontrol.DoMaximize(this);
            btn_max1.BringToFront();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {


            if (UserDAL.welcomeUPass == psdfield.Text)
            {
                cnfrmpaspanel.Show();
            }
            else
            {
                errormsglbl.ForeColor = Color.Red;
                errormsglbl.Text = "Password Enter Correct Password.";
            }
        }

        private void roundBtn1_Click(object sender, EventArgs e)
        {
           
            if (dal.Query("UPDATE [dbo].[UserTbl] SET upassword='" + newpfield.Text + "',ucpassword='" + newcpfield.Text + "' WHERE userName='" + UserDAL.welcomeUser + "'").Rows.Count > 0)
            {
                MessageBox.Show("Your Password Has been Changed Successfully..!");
            }
            else
            {
                MessageBox.Show("Your Password Has not changed"+"\n"+"Please Try Again..!");   
            }
        }

        private void newcpfield_TextChanged(object sender, EventArgs e)
        {
            if (newpfield.Text != "" && newcpfield.Text == newpfield.Text)
            {
                errorProvider1.SetError(newcpfield, "");
            }
            else
            {
                errorProvider1.SetError(newcpfield, "Password doesn't match!");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
