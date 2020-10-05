using BloodBankSystem.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodBankSystem.Classes
{
    static  class Control1
    {
        static bool ismax = false, isfull = false;
        static Point oldloc, defaultloc;
        static Size oldSize, defaultSize;

        public static void SetInitial(SignUpPOPUP BloodBankSystem)  //this method should fire when starts
        {
            oldloc = BloodBankSystem.Location;
            oldSize = BloodBankSystem.Size;
            defaultloc = BloodBankSystem.Location;
            defaultSize = BloodBankSystem.Size;
        }
        public static void DoMaximize(SignUpPOPUP bloodbank)
        {
            if (ismax == false)   //app not maximize, then maximized it
            {
                oldloc = new Point(bloodbank.Location.X, bloodbank.Location.Y);
                oldSize = new Size(bloodbank.Size.Width, bloodbank.Size.Height);
                Maximized(bloodbank);
                ismax = true;
                isfull = false;
            }
            else //app is currently maximized so make it normal
            {
                if (oldSize.Width >= SystemInformation.WorkingArea.Width || oldSize.Height >= SystemInformation.WorkingArea.Height)
                {
                    bloodbank.Location = defaultloc;
                    bloodbank.Size = defaultSize;
                }
                else
                {
                    bloodbank.Location = oldloc;
                    bloodbank.Size = oldSize;
                }

                ismax = false;
                isfull = false;
            }
        }
        public static void DoFullScreen(SignUpPOPUP bloodbank)
        {
            if (isfull == false)   //app not fullscreen, then fullscreen it
            {
                oldloc = new Point(bloodbank.Location.X, bloodbank.Location.Y);
                oldSize = new Size(bloodbank.Size.Width, bloodbank.Size.Height);
                FullScreen(bloodbank);
                ismax = false;
                isfull = true;
            }
            else //app is currently fullscreen so make it normal
            {
                if (oldSize.Width >= SystemInformation.WorkingArea.Width || oldSize.Height >= SystemInformation.WorkingArea.Height)
                {
                    bloodbank.Location = defaultloc;
                    bloodbank.Size = defaultSize;
                }
                else
                {
                    bloodbank.Location = oldloc;
                    bloodbank.Size = oldSize;
                }
                FullScreen(bloodbank);
                ismax = false;
                isfull = false;
            }
        }
        static void FullScreen(SignUpPOPUP bloodbank)
        {
            if (bloodbank.WindowState == FormWindowState.Maximized)
                bloodbank.WindowState = FormWindowState.Normal;
            else if (bloodbank.WindowState == FormWindowState.Normal)
                bloodbank.WindowState = FormWindowState.Maximized;
        }
        public static void Maximized(SignUpPOPUP bloodbank)
        {
            int x = SystemInformation.WorkingArea.Width;
            int y = SystemInformation.WorkingArea.Height;
            bloodbank.WindowState = FormWindowState.Normal;
            bloodbank.Location = new Point(0, 0);
            bloodbank.Size = new Size(x, y);

        }
        public static void Minimized(SignUpPOPUP bloodbank)
        {
            if (bloodbank.WindowState == FormWindowState.Minimized)
                bloodbank.WindowState = FormWindowState.Normal;
            else if (bloodbank.WindowState == FormWindowState.Normal)
                bloodbank.WindowState = FormWindowState.Minimized;
        }
        public static void Exit()
        {
            Application.Exit();
        }
    }
}
