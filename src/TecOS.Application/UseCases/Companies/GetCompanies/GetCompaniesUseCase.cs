using TecOS.Application.Common;
using TecOS.Domain.Entities;
using TecOS.Domain.Interfaces.Repositories;

namespace TecOS.Application.UseCases.Companies.GetCompanies;

public class GetCompaniesUseCase
{
    private readonly ICompanyRepository _repository;
    
    public GetCompaniesUseCase(ICompanyRepository repository)
    {
        _repository = repository;
    }

    public async Task<PagedResult<CompanyResponse>> ExecuteAsync(int page, int size, CancellationToken ct)
    {
        var (items, totalCount) = await _repository.GetPagedAsync(page, size, ct);

        var responseItems = items.Select(c => new CompanyResponse(
            c.Id,
            c.Name,
            c.Email,
            c.Phone, c.LogoUrl,
            c.IsActive
        ));
        
        return new PagedResult<CompanyResponse>(responseItems, totalCount, page, size);
    }
}