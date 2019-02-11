using System.IO;

namespace DnnSummit.Manager.Interfaces
{
    public interface IFileManager
    {
        Stream GetFileStream(string file);
    }
}
