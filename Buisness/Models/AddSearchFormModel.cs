using System.ComponentModel.DataAnnotations;

namespace Buisness.Models;

public class AddSearchFormModel
{
    [Display(Name = "Rubrik", Prompt = "Etc. Sökt LIA")]
    [Required(ErrorMessage = " ")]
    [StringLength(50, ErrorMessage = " ", MinimumLength = 2)]
    public string Headline { get; set; } = null!;

    [Display(Name = "Notering", Prompt = "Ev. notering")]
    public string? Description { get; set; }

    [Display(Name ="Datum")]
    [Required(ErrorMessage = " ")]
    public DateTime SearchTime { get; set; } = DateTime.Now;

    public Guid CompanyId { get; set; }
}
