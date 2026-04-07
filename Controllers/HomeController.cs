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
        if (!ModelState.IsValid)
        {
            return View("Form");
        }

        return View("ValidationFormulaire", form);
    }

    public ActionResult ValidationFormulaire()
    {
        return View();
    }

}