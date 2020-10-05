using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace BloodBankManagementSystem
{
  static class Control
    {
        static bool ismax = false, isfull = false;
        static Point oldloc, defaultloc;
        static Size oldSize, defaultSize;

        public static void SetInitial(Bloodbank bloodbank)  //this method should fire when starts
        {
            oldloc = bloodbank.Location;
            oldSize = bloodbank.Size;
            defaultloc = bloodbank.Location;
            defaultSize = bloodbank.Size;
        }
        public static void DoMaximize(Bloodbank bloodbank)
        {
            if(ismax==false)   //app not maximize, then maximized it
            {
                oldloc = new Point(bloodbank.Location.X, bloodbank.Location.Y);
                oldSize = new Size(bloodbank.Size.Width, bloodbank.Size.Height);
                Maximized(bloodbank);
                ismax = true;
                isfull = false;
            }
            else //app is currently maximized so make it normal
            {
                if(oldSize.Width >=SystemInformation.WorkingArea.Width|| oldSize.Height >=SystemInformation.WorkingArea.Height)
                {
                    bloodbank.Location = defaultloc;
                    bloodbank.Size = defaultSize;
                }
                else
                {
                    bloodbank.Location =oldloc;
                    bloodbank.Size = oldSize;
                }
                   
                ismax = false;
                isfull = false;
            }
        }
        public static void DoFullScreen(Bloodbank bloodbank)
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
        static void FullScreen(Bloodbank bloodbank)
        {
            if (bloodbank.WindowState == FormWindowState.Maximized)
                bloodbank.WindowState = FormWindowState.Normal;
            else if (bloodbank.WindowState == FormWindowState.Normal)
                bloodbank.WindowState = FormWindowState.Maximized;
        }
    public static void Maximized(Bloodbank bloodbank)
        {
            int x = SystemInformation.WorkingArea.Width;
            int y = SystemInformation.WorkingArea.Height;
            bloodbank.WindowState = FormWindowState.Normal;
            bloodbank.Location = new Point(0, 0);
           bloodbank.Size = new Size(x, y);

        }
        public static void Minimized(Bloodbank bloodbank)
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
