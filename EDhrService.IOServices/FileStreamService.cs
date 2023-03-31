using FileMonitor.IOServices.Interfaces;
using System.IO;

namespace FileMonitor.IOServices
{
    public class FileStreamService : IFileStream
    {
        public byte[] Read(string path)
        {
            using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                var size = (int)fileStream.Length;
                var data = new byte[size];
                fileStream.Read(data, 0, size);
                return data;
            }
        }
    }
}
