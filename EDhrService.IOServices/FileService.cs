using EDhrService.IOServices.Interfaces;
using System.IO;

namespace EDhrService.IOServices
{
    public class FileService : IFile
    {
        public void Copy(string sourceFilePath, string destFilePath, bool overWrite)
        {
            File.Copy(sourceFilePath, destFilePath, overWrite);
        }

        public void Delete(string path)
        {
            if (File.Exists(path))
                File.Delete(path);
        }

        public bool Exists(string path)
        {
            return File.Exists(path);
        }

        public string[] ReadAllLines(string fullFileName)
        {
            if (!Exists(fullFileName)) return null;

            return File.ReadAllLines(fullFileName);
        }

        public string ReadAllText(string fullFileName)
        {
            if (!Exists(fullFileName)) return null;

            return File.ReadAllText(fullFileName);
        }

        public void WriteAllText(string path, string contents)
        {
            File.WriteAllText(path, contents);
        }
    }
}
