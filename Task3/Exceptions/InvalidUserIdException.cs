using System;
using System.Runtime.Serialization;

namespace Task3.Exceptions
{
    /// <summary>
    /// Invalid user id exception to throw when user id is not valid.
    /// </summary>
    public class InvalidUserIdException : Exception
    {
        public InvalidUserIdException()
        {
        }

        public InvalidUserIdException(string message)
            : base(message)
        {
        }

        public InvalidUserIdException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected InvalidUserIdException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
