namespace TecOS.Application.UseCases.Companies.GetCompanies;

public record CompanyResponse(
    Guid Id,
    string Name,
    string? Email,
    string? Phone,
    string? LogoUrl,
    bool IsActive
);