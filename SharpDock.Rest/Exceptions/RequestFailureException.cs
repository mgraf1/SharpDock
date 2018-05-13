using System;

namespace SharpDock.Rest.Exceptions
{
    public class RequestFailureException : Exception
    {
        public RequestFailureException()
        {
        }

        public RequestFailureException(string message)
        : base(message)
        {
        }

        public RequestFailureException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
