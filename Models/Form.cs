using Humanizer;
using System.ComponentModel.DataAnnotations;

namespace TPLOCAL1.Models;

public class Form
{
    public int ID { get; set; }

    [Required(ErrorMessage = "Veuillez renseigner le nom.")]
    [Display(Name = "Nom")]
    public string? Nom { get; set; }

    [Required(ErrorMessage = "Veuillez renseigner le prénom.")]
    [Display(Name = "Prénom")]
    public string? Prenom { get; set; }

    [Required(ErrorMessage = "Veuillez renseigner le genre.")]
    [Display(Name = "Genre")]
    public string? Genre { get; set; }

    [Required(ErrorMessage = "Veuillez renseigner l'adresse'.")]
    [Display(Name = "Adresse")]
    public string? Adresse { get; set; }

    [Required(ErrorMessage = "Veuillez renseigner le code postal.")]
    [Display(Name = "Code Postal")]
    [RegularExpression(@"^[0-9]{5}$", ErrorMessage ="Le code postal doit être composé de 5 chiffres.")]
    public string? CodePostal { get; set; }

    [Required]
    [Display(Name = "Ville")]
    public string? Ville { get; set; }

    [Required(ErrorMessage = "Veuillez renseigner l'adresse e-mail.")]
    [Display(Name = "Adresse E-Mail")]
    [EmailAddress]
    [DataType(DataType.EmailAddress, ErrorMessage = "Veuillez renseigner une adresse e-mail valide.")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Veuillez renseigner la date de début de formation.")]
    [Display(Name = "Date début formation")]
    [DataType(DataType.Date)]
    [DateInferieur(ErrorMessage = "La date doit être inférieur au 01/01/2021.")]
    public DateOnly? DateDebutFormation { get; set;  }

    [Required(ErrorMessage = "Veuillez renseigner la formation suivie.")]
    [Display(Name = "Formation suivie")]
    public string? FormationSuivie { get; set; }

    [Display(Name = "Formation COBOL")]
    public string? AvisFormCobol { get; set; }

    [Display(Name = "Formation C#")]
    public string? AvisFormCSharp { get; set; }

    class DateInferieurAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null)
            {
                return false;
            }
            DateOnly date = (DateOnly)value;
            return date < new DateOnly(2021,1,1);
        }
    }
}
