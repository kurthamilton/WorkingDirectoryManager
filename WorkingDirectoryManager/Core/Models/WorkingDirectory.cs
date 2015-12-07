using System;

namespace WorkingDirectoryManager.Core.Models
{
    public class WorkingDirectory
    {
        public string Path { get; set; }
        public Uri Uri { get; set; }

        public WorkingDirectory(string path, Uri uri)
        {
            Path = path;
            Uri = uri;
        }
    }
}
