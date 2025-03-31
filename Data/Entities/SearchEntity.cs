using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class SearchEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Headline { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime SearchTime { get; set; }

        public Guid CompanyEntityId { get; set; }
        public IEnumerable<ResponseEntity>? ResponseEntity { get; set; }
    }
}
