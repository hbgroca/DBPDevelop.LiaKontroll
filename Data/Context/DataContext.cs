using Data.Entities;
using Microsoft.EntityFrameworkCore;
namespace Data.Context;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<CompanyEntity> Companies { get; set; }
    public DbSet<SearchEntity> Searches { get; set; }
    public DbSet<ResponseEntity> Responses { get; set; }
    public DbSet<ContactTypeEntity> ContactType { get; set; }
}
