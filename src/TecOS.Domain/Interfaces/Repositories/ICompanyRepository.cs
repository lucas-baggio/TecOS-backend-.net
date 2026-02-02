using TecOS.Domain.Entities;

namespace TecOS.Domain.Interfaces.Repositories;

public interface ICompanyRepository
{
    Task<(IEnumerable<Company> Items, int TotalCount)> GetPagedAsync(int pageNumber, int pageSize, CancellationToken ct);
    Task<Company?> GetByIdAsync(Guid id, CancellationToken ct);
    Task AddAsync(Company company, CancellationToken ct);
    Task UpdateAsync(Company company, CancellationToken ct);
    Task DeleteAsync(Company company, CancellationToken ct);
}