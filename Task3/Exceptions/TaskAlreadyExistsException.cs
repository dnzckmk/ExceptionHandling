using System;
using System.Runtime.Serialization;

namespace Task3.Exceptions
{
    /// <summary>
    /// Task already exists exception to throw when the UserTask already exists.
    /// </summary>
    public class TaskAlreadyExistsException : Exception
    {
        public TaskAlreadyExistsException()
        {
        }

        public TaskAlreadyExistsException(string message) : base(message)
        {
        }

        public TaskAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TaskAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
