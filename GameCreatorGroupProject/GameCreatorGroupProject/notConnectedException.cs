using System;
using System.Runtime.Serialization;

namespace GameCreatorGroupProject
{
    [Serializable]
    internal class notConnectedException : Exception
    {
        public notConnectedException()
        {
        }

        public notConnectedException(string message) : base(message)
        {
        }

        public notConnectedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected notConnectedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}