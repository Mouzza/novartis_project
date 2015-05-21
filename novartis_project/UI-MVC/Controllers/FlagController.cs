using JPP.BL;
using JPP.BL.Domain.Antwoorden;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace JPP.UI.Web.MVC.Controllers
{
    public class FlagController : Controller
    {

        AntwoordManager antwManager = new AntwoordManager();

        // GET: Flag
        public ActionResult FlagError()
        {
            return View();
        }

        public ActionResult FlagAntwoord(int id, string type)
        {

            if (Request.IsAuthenticated)
            {
                Flag flag = null;

                Antwoord antwoord = antwManager.readAntwoord(id);
                if (antwoord.flags == null || antwoord.flags.Count == 0)
                {
                    antwoord.flags = new List<Flag>();
                }
                else
                {
                    flag = antwoord.flags.FirstOrDefault(flagx => flagx.gebruikersNaam == User.Identity.GetUserName());
                }



                if (flag == null)
                {
                    Flag nieuwFlag = new Flag()
                    {
                        gebruikersNaam = User.Identity.GetUserName(),
                        antwoord = antwoord
                    };

                    antwManager.flagAntwoord(nieuwFlag);
                    if (type == "Dossier")
                    {
                        return RedirectToAction("Dossier", "Module");
                    }
                    else
                    {
                        return RedirectToAction("Agenda", "Module");
                    }

                }
                else
                {
                    return RedirectToAction("FlagError", "Flag");
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }





        }
    }
}