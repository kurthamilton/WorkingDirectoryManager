using System.Windows.Forms;
using WorkingDirectoryManager.Interfaces.ServiceLayer;

namespace WorkingDirectoryManager.PresentationLayer.Forms
{
    public partial class ManagerForm : Form
    {
        private IWorkingDirectoryService WorkingDirectoryService { get; set; }

        public ManagerForm(IWorkingDirectoryService workingDirectoryService)
        {
            InitializeComponent();

            WorkingDirectoryService = workingDirectoryService;
        }
    }
}
