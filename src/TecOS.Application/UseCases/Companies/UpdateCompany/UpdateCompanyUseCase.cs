using TecOS.Application.UseCases.Companies.GetCompanies;
using TecOS.Domain.Interfaces.Repositories;

namespace TecOS.Application.UseCases.Companies.UpdateCompany;

public class UpdateCompanyUseCase
{
    private readonly ICompanyRepository _repository;
    
    public UpdateCompanyUseCase(ICompanyRepository repository)
    {
        this._repository = repository;
    }

    public async Task<CompanyResponse> ExecuteAsync(UpdateCompanyRequest request, CancellationToken ct)
    {
        var company = await _repository.GetByIdAsync(request.Id, ct);
        
        if (company == null)
            throw new ArgumentException($"Company with id {request.Id} not found");
        
        company.Update(request.Name, request.Email, request.Phone, request.LogoUrl);
        
        await _repository.UpdateAsync(company, ct);

        return new CompanyResponse(
            company.Id,
            company.Name,
            company.Email,
            company.Phone,
            company.LogoUrl,
            company.IsActive
        );
    }
}