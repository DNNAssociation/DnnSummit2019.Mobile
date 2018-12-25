using System;

namespace DnnSummit.Exceptions
{
    public class InvalidSecretException : Exception
    {
        private const string MessagePattern = "Unable to find specified key: {0}";
        public InvalidSecretException(string key, Exception ex) : base(string.Format(MessagePattern, key), ex)
        {
        }
    }
}
