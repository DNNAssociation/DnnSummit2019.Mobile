using DnnSummit.Exceptions;
using DnnSummit.Manager.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace DnnSummit.Manager
{
    public class SecretsManager : ISecretsManager
    {
        private const string FileName = "Secrets";
        private const string Namespace = "DnnSummit";
        private JObject _secrets;
        public SecretsManager()
        {
            try
            {
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
                var stream = assembly.GetManifestResourceStream($"{Namespace}.{FileName}.json");
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
                catch (Exception e)
                {
                    throw new InvalidSecretException(name, e);
                }
            }
        }
    }
}
