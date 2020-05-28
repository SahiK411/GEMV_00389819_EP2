using System;
using System.Runtime.Serialization;

namespace SourceCode
{
    [Serializable]
    internal class UserNotInTableException : Exception
    {
        public UserNotInTableException() : base("La entrada referenciada no existe. Por favor intente de nuevo.")
        {
        }

        public UserNotInTableException(string message) : base(message)
        {
        }

        public UserNotInTableException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UserNotInTableException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}