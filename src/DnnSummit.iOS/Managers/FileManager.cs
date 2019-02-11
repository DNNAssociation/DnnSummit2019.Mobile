using System.IO;
using DnnSummit.Manager.Interfaces;

namespace DnnSummit.iOS.Managers
{
    internal class FileManager : IFileManager
    {
        public Stream GetFileStream(string file)
        {
            return File.OpenRead(file);
        }
    }
}
