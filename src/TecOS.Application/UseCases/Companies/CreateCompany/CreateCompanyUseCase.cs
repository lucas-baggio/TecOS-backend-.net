using TecOS.Domain.Entities;
using TecOS.Domain.Interfaces.Repositories;

namespace TecOS.Application.UseCases.Companies.CreateCompany;

public class CreateCompanyUseCase
{
    private readonly ICompanyRepository _repository;

    public CreateCompanyUseCase(ICompanyRepository repository)
    {
        this._repository = repository;
    }

    public async Task<Guid> ExecuteAsync(CreateCompanyRequest request, CancellationToken ct)
    {
        var company = new Company(
            request.Name,
            request.Email,
            request.Phone,
            request.LogoUrl
        );
        
        await _repository.AddAsync(company, ct);
        return company.Id;
    }
}