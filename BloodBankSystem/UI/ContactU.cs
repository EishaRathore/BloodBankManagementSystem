using BloodBankSystem.DAL;
using BloodBankSystem.userBLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodBankSystem.UI
{
    public partial class ContactU : Form
    {
        public ContactU()
        {
            InitializeComponent();
        }

        //create objects of userDAL and userBLL
        UserbLL u = new UserbLL();
        UserDAL dal = new UserDAL();


        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1 != null && textBox2 != null && textBox3 != null)
            {
                //get the values from UI
                u.UserName = textBox1.Text;
                u.UserEmail = textBox2.Text;
                u.msg = textBox3.Text;

                //adding the value from UI to Database
                //create a boolean variable to check if the data is inserted successfully
                bool success = dal.InsertC(u);


                //check if the data is inserted successfully
                if (success == true)
                {
                    MessageBox.Show("Successfully deliver message!");

                }
                else
                {
                    //failed to add user
                    MessageBox.Show("Failed to deliver message!");
                }


                //clear text boxes
                Clear();
            }
        }
        public void Clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            }

    }
}

