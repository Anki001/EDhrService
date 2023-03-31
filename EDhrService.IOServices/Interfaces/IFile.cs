namespace EDhrService.IOServices.Interfaces
{
    public interface IFile
    {
        bool Exists(string path);
        void WriteAllText(string path, string contents);
        void Delete(string path);
        void Copy(string sourceFilePath, string destFilePath, bool overWrite);
        string ReadAllText(string fullFileName);
        string[] ReadAllLines(string fullFileName);
    }
}
