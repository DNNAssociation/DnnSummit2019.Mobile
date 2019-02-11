using System.IO;
using Android.App;
using DnnSummit.Manager.Interfaces;

namespace DnnSummit.Droid.Managers
{
    internal class FileManager : IFileManager
    {
        public Stream GetFileStream(string file)
        {
            return Application.Context.Assets.Open(file);
        }
    }
}
