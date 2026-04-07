using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Text.RegularExpressions;
using TPLOCAL1.Models;

//Subject is find at the root of the project and the logo in the wwwroot/ressources folders of the solution
//--------------------------------------------------------------------------------------
//Careful, the MVC model is a so-called convention model instead of configuration,
//The controller must imperatively be name with "Controller" at the end !!!
namespace TPLOCAL1.Controllers;

public class HomeController : Controller
{

    //methode "naturally" call by router
    public ActionResult Index(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            //retourn to the Index view (see routing in Program.cs)
            return View();
        else
        {
            //Call different pages, according to the id pass as parameter
            switch (id)
            {
                case "AvisListe":
                    List<Opinion> model = new OpinionList().GetAvis("./XmlFile/DataAvis.xml");
                    return View(id, model);
                case "Form":
                    return View(id);
                default:
                    //retourn to the Index view (see routing in Program.cs)
                    return View();
            }
        }
    }


    //methode to send datas from form to validation page
    [HttpPost]
    public ActionResult ValidationFormulaire([Bind("Id,Nom,Prenom,Genre,Adresse,CodePostal,Ville,Email,DateDebutFormation,FormationSuivie,AvisFormCobol,AvisFormCSharp")] Form form)
    {
        bool erreur = false;
        if (String.IsNullOrEmpty(form.Nom))
        {
            erreur = true;
            ModelState.AddModelError("Nom", "Le Nom n'a pas été renseigné.");
        }
        if (String.IsNullOrEmpty(form.Prenom))
        {
            erreur = true;
            ModelState.AddModelError("Prenom", "Le Prenom n'a pas été renseigné.");
        }
        if (String.IsNullOrEmpty(form.Genre))
        {
            erreur = true;
            ModelState.AddModelError("Genre", "Le Genre n'a pas été renseigné.");
        }
        if (String.IsNullOrEmpty(form.Adresse))
        {
            erreur = true;
            ModelState.AddModelError("Adresse", "L'Adresse n'a pas été renseignée.");
        }
        if (String.IsNullOrEmpty(form.CodePostal))
        {
            erreur = true;
            ModelState.AddModelError("CodePostal", "Le Code Postal n'a pas été renseigné.");
        }
        if (form.CodePostal != null && !Regex.IsMatch(form.CodePostal, @"^[0-9]{5}$"))
        {
            erreur = true;
            ModelState.AddModelError("CodePostal", "Le Code Postal doit être composé de 5 chiffres.");
        }
        if (String.IsNullOrEmpty(form.Ville))
        {
            erreur = true;
            ModelState.AddModelError("Ville", "La Ville n'a pas été renseignée.");
        }
        if (String.IsNullOrEmpty(form.Email))
        {
            erreur = true;
            ModelState.AddModelError("Email", "L'Adresse E-Mail n'a pas été renseignée.");
        }
        if (form.Email != null && IsInvalidEmail(form.Email))
        {
            erreur = true;
            ModelState.AddModelError("Email", "L'Adresse E-Mail n'est pas valide.");
        }
        if (form.DateDebutFormation == null)
        {
            erreur = true;
            ModelState.AddModelError("DateDebutFormation", "La date n'a pas été renseignée.");
        }
        if (form.DateDebutFormation != null && form.DateDebutFormation > new DateOnly(2021,01,01)) //DateDebutForm
        {
            erreur = true;
            ModelState.AddModelError("DateDebutFormation", "La date doit être inférieur au 01/01/2021.");
        }
        if (String.IsNullOrEmpty(form.FormationSuivie))
        {
            erreur = true;
            ModelState.AddModelError("FormationSuivie", "La Formation n'a pas été renseignée.");
        }

        if (erreur)
        {
            return View("Form");
        }

        return View("ValidationFormulaire", form);
    }

    public ActionResult ValidationFormulaire()
    {
        return View("ValidationFormulaire");
    }

    private static bool IsInvalidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return true;
        try
        {
            MailAddress addr = new MailAddress(email);
            return addr.Address != email;
        }
        catch
        {
            return true;
        }
    }

}