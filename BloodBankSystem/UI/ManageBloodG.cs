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
    public partial class ManageBloodG : Form
    {
        public ManageBloodG()
        {
            InitializeComponent();
        }

        private void circularBtn1_Click(object sender, EventArgs e)
        {
           
            Upate db = new Upate();
            
           
            db.BringToFront();
            db.Show();
        }

        private void circularBtn2_Click(object sender, EventArgs e)
        {
            DeleteBlood db = new DeleteBlood();


            db.BringToFront();
            db.Show();
        }
    }
}
