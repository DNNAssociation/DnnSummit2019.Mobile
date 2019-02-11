using System.IO;
using System.Reflection;
using DnnSummit.Manager.Interfaces;

namespace DnnSummit.Droid.Managers
{
    internal class FileManager : IFileManager
    {
        public Stream GetFileStream(string file)
        {
            var path = $"DnnSummit.Droid.{file}";
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(FileManager)).Assembly;

            return assembly.GetManifestResourceStream(path);
        }
    }
}
