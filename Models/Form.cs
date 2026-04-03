using Humanizer;
using System.ComponentModel.DataAnnotations;

namespace TPLOCAL1.Models;

public class Form
{
    public int ID { get; set; }

    [Required]
    [Display(Name = "Nom")]
    public string? Nom { get; set; }

    [Required]
    [Display(Name = "Prénom")]
    public string? Prenom { get; set; }

    [Required]
    [Display(Name = "Genre")]
    public string? Genre { get; set; }

    [Required]
    [Display(Name = "Adresse")]
    public string? Adresse { get; set; }

    [Required]
    [Display(Name = "Code Postal")]
    [RegularExpression(@"^[0-9]{5}$")]
    public string? CodePostal { get; set; }

    [Required]
    [Display(Name = "Ville")]
    public string? Ville { get; set; }

    [Required]
    [Display(Name = "Adresse E-Mail")]
    [EmailAddress]
    [DataType(DataType.EmailAddress)]
    public string? Email { get; set; }

    [Required]
    [Display(Name = "Date début formation")]
    [DataType(DataType.Date)]
    public DateOnly? DateDebutFormation { get; set;  }

    [Required]
    [Display(Name = "Formation suivie")]
    public string? FormationSuivie { get; set; }

    [Display(Name = "Formation COBOL")]
    public string? AvisFormCobol { get; set; }

    [Display(Name = "Formation C#")]
    public string? AvisFormCSharp { get; set; }

}
