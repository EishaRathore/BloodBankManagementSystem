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
    class AControl
    {
        static bool ismax = false, isfull = false;
        static Point oldloc, defaultloc;
        static Size oldSize, defaultSize;

        public static void SetInitial(Admin admin)  //this method should fire when starts
        {
            oldloc = admin.Location;
            oldSize = admin.Size;
            defaultloc = admin.Location;
            defaultSize = admin.Size;
        }
        public static void DoMaximize(Admin admin)
        {
            if (ismax == false)   //app not maximize, then maximized it
            {
                oldloc = new Point(admin.Location.X, admin.Location.Y);
                oldSize = new Size(admin.Size.Width, admin.Size.Height);
                Maximized(admin);
                ismax = true;
                isfull = false;
            }
            else //app is currently maximized so make it normal
            {
                if (oldSize.Width >= SystemInformation.WorkingArea.Width || oldSize.Height >= SystemInformation.WorkingArea.Height)
                {
                    admin.Location = defaultloc;
                    admin.Size = defaultSize;
                }
                else
                {
                    admin.Location = oldloc;
                    admin.Size = oldSize;
                }

                ismax = false;
                isfull = false;
            }
        }
        public static void DoFullScreen(Admin admin)
        {
            if (isfull == false)   //app not fullscreen, then fullscreen it
            {
                oldloc = new Point(admin.Location.X, admin.Location.Y);
                oldSize = new Size(admin.Size.Width, admin.Size.Height);
                FullScreen(admin);
                ismax = false;
                isfull = true;
            }
            else //app is currently fullscreen so make it normal
            {
                if (oldSize.Width >= SystemInformation.WorkingArea.Width || oldSize.Height >= SystemInformation.WorkingArea.Height)
                {
                    admin.Location = defaultloc;
                    admin.Size = defaultSize;
                }
                else
                {
                    admin.Location = oldloc;
                    admin.Size = oldSize;
                }
                FullScreen(admin);
                ismax = false;
                isfull = false;
            }
        }
        static void FullScreen(Admin admin)
        {
            if (admin.WindowState == FormWindowState.Maximized)
                admin.WindowState = FormWindowState.Normal;
            else if (admin.WindowState == FormWindowState.Normal)
                admin.WindowState = FormWindowState.Maximized;
        }
        public static void Maximized(Admin admin)
        {
            int x = SystemInformation.WorkingArea.Width;
            int y = SystemInformation.WorkingArea.Height;
            admin.WindowState = FormWindowState.Normal;
            admin.Location = new Point(0, 0);
            admin.Size = new Size(x, y);

        }
        public static void Minimized(Admin admin)
        {
            if (admin.WindowState == FormWindowState.Minimized)
               admin.WindowState = FormWindowState.Normal;
            else //if (admin.WindowState == FormWindowState.Normal)
                admin.WindowState = FormWindowState.Minimized;
        }
        public static void Exit()
        {
            Application.Exit();
        }
    }
}
