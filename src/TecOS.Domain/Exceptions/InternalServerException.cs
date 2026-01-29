namespace TecOS.Domain.Exceptions;

public class InternalServerException: DomainException
{
    public InternalServerException(string message) : base(message) {}
}