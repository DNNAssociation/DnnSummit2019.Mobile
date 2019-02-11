using System.IO;
using System.Reflection;
using DnnSummit.Manager.Interfaces;

namespace DnnSummit.iOS.Managers
{
    internal class FileManager : IFileManager
    {
        public Stream GetFileStream(string file)
        {
            var path = $"DnnSummit.iOS.{file}";
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(FileManager)).Assembly;

            return assembly.GetManifestResourceStream(path);
        }
    }
}
