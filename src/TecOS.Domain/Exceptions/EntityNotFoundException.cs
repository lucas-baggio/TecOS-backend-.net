namespace TecOS.Domain.Exceptions;

public class EntityNotFoundException : DomainException
{
    public EntityNotFoundException(string entityName, object id) : base($"{entityName} with ID {id} was not found.")
    {
        
    }
}