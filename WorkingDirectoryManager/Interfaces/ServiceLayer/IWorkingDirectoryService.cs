using System.Collections.Generic;
using WorkingDirectoryManager.Core.Models;

namespace WorkingDirectoryManager.Interfaces.ServiceLayer
{
    public interface IWorkingDirectoryService
    {
        WorkingDirectory GetWorkingDirectory(string path);
        List<WorkingDirectory> GetWorkingDirectories(IEnumerable<string> paths);
    }
}
