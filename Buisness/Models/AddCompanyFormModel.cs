using System.ComponentModel.DataAnnotations;

namespace Buisness.Models;

public class AddCompanyFormModel
{
    [Display(Name = "Företagsnamn", Prompt = "Etc. Sogeti AB")]
    [Required(ErrorMessage = " ")]
    [StringLength(50, ErrorMessage = " ", MinimumLength = 2)]
    public string Name { get; set; } = null!;


    [Display(Name = "Beskrivning", Prompt = "Kort beskrivning")]
    public string? Description { get; set; }
}
