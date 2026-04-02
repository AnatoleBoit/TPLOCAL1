using Microsoft.AspNetCore.Mvc;
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
                case "OpinionList":
                    return View(id);
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
        }
        if (String.IsNullOrEmpty(form.Prenom))
        {
            erreur = true;
        }
        if (String.IsNullOrEmpty(form.Genre))
        {
            erreur = true;
        }
        if (String.IsNullOrEmpty(form.Adresse))
        {
            erreur = true;
        }
        if (String.IsNullOrEmpty(form.CodePostal))
        {
            erreur = true;
        }
        if (String.IsNullOrEmpty(form.Ville))
        {
            erreur = true;
        }
        if (String.IsNullOrEmpty(form.Email))
        {
            erreur = true;
        }
        /*if (false) //DateDebutForm
        {
            return null;
        }
        if (String.IsNullOrEmpty(form.FormationSuivie))
        {
            Console.WriteLine(form.FormationSuivie);
            return null;
        }*/

        if (erreur)
        {
            return null;
        }
        //TODO : test if model's fields are set
        //if not, display an error message and stay on the form page
        //else, call ValidationForm with the datas set by the user
        return View();
        
    }
}