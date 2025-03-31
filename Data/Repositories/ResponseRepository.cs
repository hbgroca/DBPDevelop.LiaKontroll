
using Data.Context;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class ResponseRepository(DataContext context)
{
    private readonly DataContext _context = context;

    public async Task<ResponseEntity> Create(ResponseEntity entity)
    {
        _context.Responses.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> Delete(Guid id)
    {
        var entity = await _context.Responses.FirstOrDefaultAsync(x => x.Id == id);
        _context.Responses.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }
}
