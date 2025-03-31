using Data.Context;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class SearchesRepository(DataContext context)
{
    private readonly DataContext _context = context;

    public async Task<SearchEntity> CreateSearch(SearchEntity search)
    {
        _context.Searches.Add(search);
        await _context.SaveChangesAsync();
        return search;
    }

    public async Task<SearchEntity> DeleteSearch(Guid id)
    {
        var search = await _context.Searches.FirstOrDefaultAsync(x => x.Id == id);
        _context.Searches.Remove(search);
        await _context.SaveChangesAsync();
        return search;
    }
}
