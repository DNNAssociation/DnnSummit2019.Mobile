using System;
using System.Diagnostics;
using System.IO;
using DnnSummit.Manager.Interfaces;
using Newtonsoft.Json.Linq;

namespace DnnSummit.Manager
{
    public class SecretsManager : ISecretsManager
    {
        private const string FileName = "Secrets.json";
        private JObject _secrets;
        public SecretsManager(IFileManager fileManager)
        {
            try
            {
                using (var stream = fileManager.GetFileStream(FileName))
                using (var reader = new StreamReader(stream))
                {
                    var json = reader.ReadToEnd();
                    _secrets = JObject.Parse(json);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Unable to load secrets file");
            }
        }

        public string this[string name]
        {
            get
            {
                try
                {
                    var path = name.Split(':');

                    JToken node = _secrets[path[0]];
                    for (int index = 1; index < path.Length; index++)
                    {
                        node = node[path[index]];
                    }

                    return node.ToString();
                }
                catch (Exception)
                {
                    Debug.WriteLine($"Unable to retrieve secret '{name}'");
                    return string.Empty;
                }
            }
        }
    }
}
