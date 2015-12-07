using System;
using System.Windows.Forms;
using WorkingDirectoryManager.Interfaces.ServiceLayer;
using WorkingDirectoryManager.PresentationLayer;
using WorkingDirectoryManager.PresentationLayer.Forms;
using WorkingDirectoryManager.ServiceLayer.Svn;

namespace WorkingDirectoryManager
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            RunApplication();
        }

        private static void RunApplication()
        {
            // TODO: resolve
            IWorkingDirectoryService workingDirectoryService = new SvnWorkingDirectoryService(new AuthForm());

            using (var managerForm = GetManagerForm(workingDirectoryService))
            {
                using (GetTrayIcon(workingDirectoryService, managerForm))
                {
                    Application.Run();
                }
            }
        }

        private static Form GetManagerForm(IWorkingDirectoryService workingDirectoryService)
        {
            var managerForm = new ManagerForm(workingDirectoryService) { ShowInTaskbar = false, Visible = false };

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

        private static TrayIcon GetTrayIcon(IWorkingDirectoryService workingDirectoryService, Form managerForm)
        {
            return new TrayIcon(workingDirectoryService, managerForm);
        }
    }
}
