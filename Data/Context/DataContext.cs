using Data.Entities;
using Microsoft.EntityFrameworkCore;
namespace Data.Context;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<CompanyEntity> Companies { get; set; }
    public DbSet<SearchEntity> Searches { get; set; }
    public DbSet<ResponseEntity> Responses { get; set; }
    public DbSet<ContactTypeEntity> ContactType { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ContactTypeEntity>()
            .HasData(
                new ContactTypeEntity { Id = 1, ContactType = "Telefon" },
                new ContactTypeEntity { Id = 2, ContactType = "E-post" },
                new ContactTypeEntity { Id = 3, ContactType = "Personlig möte" },
                new ContactTypeEntity { Id = 4, ContactType = "Video möte" },
                new ContactTypeEntity { Id = 5, ContactType = "Intervju" }
            );
    }
}
