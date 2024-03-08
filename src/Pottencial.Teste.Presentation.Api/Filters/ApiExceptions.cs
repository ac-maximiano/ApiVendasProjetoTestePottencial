namespace Pottencial.Teste.Presentation.Api.Filters
{
    public class NotFoundException : Exception
    {
        public NotFoundException() { }
        public NotFoundException(string message) : base(message) { }
        public NotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class InvalidRequestDataException : Exception
    {
        public InvalidRequestDataException() { }
        public InvalidRequestDataException(string message) : base(message) { }
        public InvalidRequestDataException(string message, Exception innerException) : base(message, innerException) { }
    }
}
