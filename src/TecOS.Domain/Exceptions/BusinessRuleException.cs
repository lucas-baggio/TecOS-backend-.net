namespace TecOS.Domain.Exceptions;

public class BusinesRuleException :  DomainException
{
    public BusinesRuleException(string message) : base(message) {}
}