using Data.Context;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class CompanyRepository(DataContext context)
{
    private readonly DataContext _context = context;

    public async Task<IEnumerable<CompanyEntity>> GetCompanies()
    {
        var result = await _context.Companies
                            .Include(x => x.SearchEntity)
                            .ThenInclude(x => x.ResponseEntity)
                            .ThenInclude(x => x.ContactType)
                            .ToListAsync();



        return result ?? [];
    }
    public async Task<CompanyEntity> GetCompany(Guid id)
    {
        return await _context.Companies
            .Include(x => x.SearchEntity)
            .ThenInclude(x => x.ResponseEntity)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
    public async Task<CompanyEntity> CreateCompany(CompanyEntity company)
    {
        _context.Companies.Add(company);
        await _context.SaveChangesAsync();
        return company;
    }
    public async Task<CompanyEntity> UpdateCompany(CompanyEntity company)
    {
        _context.Companies.Update(company);
        await _context.SaveChangesAsync();
        return company;
    }
    public async Task<bool> DeleteCompany(Guid id)
    {
        var company = await _context.Companies.FirstOrDefaultAsync(x => x.Id == id);
        if(company == null)
        {
            return false;
        }
        _context.Companies.Remove(company);
        await _context.SaveChangesAsync();
        return true;
    }
}
