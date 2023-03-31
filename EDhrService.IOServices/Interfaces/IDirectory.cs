using System.IO;

namespace EDhrService.IOServices.Interfaces
{
    public interface IDirectory
    {
        bool Exists(string path);
        string[] GetFiles(string path);
        string[] GetFiles(string path, string searchPattern);
        string[] GetFiles(string path, string searchPattern, SearchOption searchOption);
    }
}
