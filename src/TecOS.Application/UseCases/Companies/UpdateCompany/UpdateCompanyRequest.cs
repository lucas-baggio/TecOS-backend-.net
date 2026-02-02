namespace TecOS.Application.UseCases.Companies.UpdateCompany;

public record UpdateCompanyRequest(
    Guid Id,
    string Name,
    string? LogoUrl,
    string? Phone,
    string? Email
);