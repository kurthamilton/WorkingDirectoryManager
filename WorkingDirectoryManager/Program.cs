using System;
using System.Drawing;
using System.Windows.Forms;
using WorkingDirectoryManager.Forms;

namespace WorkingDirectoryManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            RunApplication();
        }

        static void RunApplication()
        {
            using (var managerForm = GetManagerForm())
            {
                using (var trayIcon = GetTrayIcon(managerForm))
                {
                    Application.Run();
                }
            }
        }

        static ManagerForm GetManagerForm()
        {
            var managerForm = new ManagerForm { ShowInTaskbar = false, Visible = false };

            managerForm.FormClosing += (sender, e) =>
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    e.Cancel = true;
                    managerForm.Hide();
                }
            };

            return managerForm;
        }

        static NotifyIcon GetTrayIcon(ManagerForm managerForm)
        {
            var trayIcon = new NotifyIcon
            {
                ContextMenu = GetTrayIconContextMenu(managerForm),
                Icon = new Icon(SystemIcons.Application, new Size(40, 40)),
                Text = "Working Directory Manager",
                Visible = true
            };

            trayIcon.DoubleClick += (sender, e) => managerForm.Show();

            return trayIcon;
        }

        static ContextMenu GetTrayIconContextMenu(ManagerForm managerForm)
        {
            var contextMenu = new ContextMenu();
            contextMenu.MenuItems.Add("Show", (sender, e) => managerForm.Show());
            contextMenu.MenuItems.Add("Exit", (sender, e) => Application.Exit());
            return contextMenu;
        }
    }
}
