
using Data.Context;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class ContactTypeRepository(DataContext context)
{
    private readonly DataContext _context = context;

    public async Task<ContactTypeEntity> CreateSearch(ContactTypeEntity entity)
    {
        _context.ContactType.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<List<ContactTypeEntity>> GetContactTypes()
    {
        return await _context.ContactType.ToListAsync() ?? [];
    }
}
