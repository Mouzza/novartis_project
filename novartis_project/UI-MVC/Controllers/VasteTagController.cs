using JPP.BL;
using JPP.BL.Domain.Antwoorden;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JPP.UI.Web.MVC.Controllers
{
    [Authorize(Roles="Admin, Moderator")]
    public class VasteTagController : Controller
    {
        VasteTagManager vtManager = new VasteTagManager();

        public ActionResult Index()
        {
        
            return View(vtManager.readAllVasteTags());
        }

        public ActionResult Wijzig(int id)
        {
            return View(vtManager.readVasteTag(id));
        }

        [HttpPost]
        public ActionResult Wijzig(VasteTag vasteTag)
        {
            try
            {
                vtManager.updateVasteTag(vasteTag);
                return RedirectToAction("Index", "VasteTag");
            }
            catch
            {
                return View();
            }
           
        }


        public ActionResult Verwijder(int id)
        {

            return View(vtManager.readVasteTag(id));
        }

        [HttpPost]
        public ActionResult Verwijder(int id, FormCollection formCollection)
        {
            try
            {
                vtManager.removeVasteTag(id);
                return RedirectToAction("Index", "VasteTag");
            }
            catch
            {
                return View();
            }

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(VasteTag vasteTag)
        {

            try
            {
                vasteTag.antwoorden = new List<Antwoord>();
                vtManager.createVasteTag(vasteTag);

                return RedirectToAction("Index","VasteTag");
            }
            catch
            {
                return View();
            }
          
        }

    }
}