using TecOS.Domain.Interfaces.Repositories;

namespace TecOS.Application.UseCases.Companies.DeleteCompany;

public class DeleteCompanyUseCase
{
    private readonly ICompanyRepository _repository;
    
    public DeleteCompanyUseCase(ICompanyRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(DeleteCompanyRequest request, CancellationToken ct)
    {
        var company = await _repository.GetByIdAsync(request.Id, ct);
        
        if (company == null)
            throw new ArgumentException($"Company with id {request.Id} not found");
        
        company.Deactivate();
        await _repository.UpdateAsync(company, ct);
    }
}