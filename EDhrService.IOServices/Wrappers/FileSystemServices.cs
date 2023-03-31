using EDhrService.IOServices.Interfaces;
using EDhrService.IOServices.Interfaces.Wrappers;

namespace EDhrService.IOServices.Wrappers
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
