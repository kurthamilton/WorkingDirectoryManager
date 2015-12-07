using System;
using System.Drawing;
using System.Windows.Forms;
using WorkingDirectoryManager.Interfaces.ServiceLayer;

namespace WorkingDirectoryManager.PresentationLayer
{
    public class TrayIcon : IDisposable
    {
        private NotifyIcon NotifyIcon { get; set; }
        private IWorkingDirectoryService WorkingDirectoryService { get; set; }

        public TrayIcon(IWorkingDirectoryService workingDirectoryService, Form managerForm)
        {
            WorkingDirectoryService = workingDirectoryService;

            NotifyIcon = new NotifyIcon
            {
                ContextMenu = GetTrayIconContextMenu(managerForm),
                Icon = new Icon(SystemIcons.Application, new Size(40, 40)),
                Text = "Working Directory Manager",
                Visible = true
            };
            NotifyIcon.DoubleClick += (sender, e) => managerForm.Show();
        }

        public void Dispose()
        {
            NotifyIcon.Dispose();
        }

        static ContextMenu GetTrayIconContextMenu(Form managerForm)
        {
            var contextMenu = new ContextMenu();
            contextMenu.MenuItems.Add("Show", (sender, e) => managerForm.Show());
            contextMenu.MenuItems.Add("Exit", (sender, e) => Application.Exit());
            return contextMenu;
        }
    }
}
