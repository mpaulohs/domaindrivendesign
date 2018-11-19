using System;

namespace demo1.Domain.Exceptions
{
    /// <summary>
    /// Exception type for domain exceptions
    /// </summary>
    public class BookDomainException : Exception
    {
        public BookDomainException()
        { }

        public BookDomainException(string message)
            : base(message)
        { }

        public BookDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
