using FileMonitor.IOServices.Interfaces;
using FileMonitor.IOServices.Interfaces.Wrappers;

namespace FileMonitor.IOServices.Wrappers
{
    public class FileSystemServices : IFileSystemServices
    {
        public IDirectory Directory { get; set; }
        public IFile File { get; set; }
        public IFileStream FileStream { get; set; }
        public FileSystemServices(IDirectory directory, IFile file, IFileStream fileStream)
        {
            Directory = directory;
            File = file;
            FileStream = fileStream;
        }
    }
}
