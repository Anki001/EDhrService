namespace EDhrService.IOServices.Interfaces.Wrappers
{
    public interface IFileSystemServices
    {
        IDirectory Directory { get; set; }
        IFile File { get; set; }
        IFileStream FileStream { get; set; }
    }
}
