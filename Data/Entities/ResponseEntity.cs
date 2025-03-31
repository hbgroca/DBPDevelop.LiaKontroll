using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class ResponseEntity
{
    [Key]
    public Guid Id { get; set; }

    public string Response { get; set; } = null!;
    public bool IsAnswer { get; set; }

    public string? ResponsePerson { get; set; }
    public string? ResponseContactInfo { get; set; }
    public DateTime? ResponseDate { get; set; }

    public Guid SearchEntityId { get; set; }

    public int ContactTypeId { get; set; }
    public ContactTypeEntity ContactType { get; set; } = null!;
}
