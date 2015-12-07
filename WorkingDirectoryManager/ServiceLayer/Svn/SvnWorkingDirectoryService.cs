using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpSvn;
using SharpSvn.UI;
using WorkingDirectoryManager.Core.Models;
using WorkingDirectoryManager.Interfaces.ServiceLayer;

namespace WorkingDirectoryManager.ServiceLayer.Svn
{
    public class SvnWorkingDirectoryService : IWorkingDirectoryService, IDisposable
    {
        private SvnClient Client { get; set; }

        public SvnWorkingDirectoryService(IWin32Window window)
        {
            Client = new SvnClient();
            SvnUI.Bind(Client, window);
        }

        public WorkingDirectory GetWorkingDirectory(string path)
        {
            throw new NotImplementedException();
        }

        public List<WorkingDirectory> GetWorkingDirectories(IEnumerable<string> paths)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Client.Dispose();
        }
    }
}
