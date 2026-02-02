using Microsoft.EntityFrameworkCore;
using TecOS.Application.Common;
using TecOS.Domain.Entities;
using TecOS.Domain.Interfaces.Repositories;
using TecOS.Infrastructure.Data.Context;

namespace TecOS.Infrastructure.Data;

public class CompanyRepository : ICompanyRepository
{
    private readonly ApplicationDbContext _context;
    
    public CompanyRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<(IEnumerable<Company> Items, int TotalCount)> GetPagedAsync(int pageNumber, int pageSize, CancellationToken ct)
    {
        var query = _context.Companies.AsNoTracking();
        
        var totalCount = await query.CountAsync(ct);
        
        var items = await query
            .OrderBy(c => c.Name)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(ct);

        return (items, totalCount);
    }

    public async Task AddAsync(Company company, CancellationToken ct)
    {
        await _context.Companies.AddAsync(company, ct);
        await _context.SaveChangesAsync(ct);
    }

    public async Task<Company?> GetByIdAsync(Guid id, CancellationToken ct)
    {
        return await _context.Companies.FirstOrDefaultAsync(x => x.Id == id, ct);
    }

    public async Task DeleteAsync(Company company, CancellationToken ct)
    {
        _context.Companies.Remove(company);
        await _context.SaveChangesAsync(ct);
    }

    public async Task UpdateAsync(Company company, CancellationToken ct)
    {
        _context.Companies.Update(company);
        await _context.SaveChangesAsync(ct);
    }
}