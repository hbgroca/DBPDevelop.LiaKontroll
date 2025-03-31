using Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace Buisness.Models;

public class AddResponseFormModel
{
    [Display(Name = "Svar", Prompt = "Svars text")]
    [Required(ErrorMessage = " ")]
    public string Response { get; set; } = null!;

    [Display(Name = "Är respons")]
    [Required]
    public bool IsAnswer { get; set; }

    [Required]
    [Display(Name = "Kontaktperson", Prompt = "Namn på kontaktperson")]
    public string? ResponsePerson { get; set; }

    [Display(Name = "Kontaktinfo", Prompt = "Etc url, mail elr telefonnummer")]
    public string? ResponseContactInfo { get; set; }

    [Required]
    [Display(Name = "Kontakt datum")]
    public DateTime ResponseDate { get; set; } = DateTime.Now;

    [Required]
    public Guid SearchEntityId { get; set; }

    [Required]
    [Display(Name = "Kontakt typ")]
    public int ContactTypeId { get; set; }

}
