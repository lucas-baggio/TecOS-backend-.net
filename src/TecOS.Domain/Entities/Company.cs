using TecOS.Domain.Common;

namespace TecOS.Domain.Entities;

public class Company : BaseEntity
{
    public string Name { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? LogoUrl { get; set; }
    public bool IsActive { get; set; }
    
    protected Company() { }

    public Company(string name, string? email = null, string? phone = null, string? logoUrl = null)
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
        Phone = phone;
        LogoUrl = logoUrl;
        IsActive = true;
    }
    
    public void Deactivate() => IsActive = false;

    public void Update(string name, string email, string phone, string logoUrl)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentNullException("Name Cannot be empty");
        
        Name = name;
        Email = email;
        Phone = phone;
        LogoUrl = logoUrl;
        UpdatedAt = DateTime.UtcNow;
    }
}