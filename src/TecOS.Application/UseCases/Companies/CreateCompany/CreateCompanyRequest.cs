namespace TecOS.Application.UseCases.Companies.CreateCompany;

public record CreateCompanyRequest(
    string Name,
    string? Email,
    string? Phone,
    string? LogoUrl
    );