
using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class CompanyEntity
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }

    public IEnumerable<SearchEntity>? SearchEntity { get; set; }
}
