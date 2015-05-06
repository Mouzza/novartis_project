using JPP.BL;
using JPP.BL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Microsoft.AspNet.Identity;
using JPP.DAL.Interface;
using JPP.BL.Domain.Vragen;
using JPP.BL.Domain.Modules;
using JPP.BL.Domain.Antwoorden;
using JPP.BL.Domain.Gebruikers;
using JPP.BL.Domain.Gebruikers.Beheerder;
using JPP.BL.Domain.Gebruikers.SuperUser;

namespace JPP.UI.Web.MVC.Controllers
{
    public class AntwoordController : Controller
    {
        AntwoordManager antwManager = new AntwoordManager();
        ModuleManager dossManager = new ModuleManager();
        // GET: Antwoord
        public ActionResult Index()
        {
            return View();
        
        }

        //Antwoord/Lijst

        public ActionResult _partialAntwoordLijst(int? page)
        {
            //Manager moet nog gemaakt worden
            
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            DossierModule dossiermodule = dossManager.readActieveDossierModule();
            IEnumerable<DossierAntwoord> dossierAntwoorden = antwManager.getAllDossierAntwoordenPerModule(dossiermodule.ID);

            ViewBag.Aantal = dossierAntwoorden.Count();
             
            return PartialView(dossierAntwoorden.ToPagedList(pageNumber, pageSize));
            
            

            
        }

        public ActionResult _partialAgendaAntwoordLijst(int? page)
        {
            //Manager moet nog gemaakt worden

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            AgendaModule agendaModule = dossManager.readActieveAgendaModule();
            IEnumerable<AgendaAntwoord> dossierAntwoorden = antwManager.getAllAgendaAntwoordenPerModule(agendaModule.ID);

            ViewBag.Aantal = dossierAntwoorden.Count();

            return PartialView(dossierAntwoorden.ToPagedList(pageNumber, pageSize));




        }
        //Antwoord/Lijst
        public ActionResult Lijst(int id, int? page)
        {
            //Manager moet nog gemaakt worden
            
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            
            IEnumerable<DossierAntwoord> dossierAntwoorden = antwManager.getAllDossierAntwoordenPerModule(id);
            ViewBag.Aantal = dossierAntwoorden.Count();
            return View(dossierAntwoorden.ToPagedList(pageNumber, pageSize));
            

        }
        //Antwoord/_Lijst
        public ActionResult _Lijst(int id, int? page)
        {
            //Manager moet nog gemaakt worden

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            IEnumerable<AgendaAntwoord> agendaAntwoorden = antwManager.getAllAgendaAntwoordenPerModule(id);
            ViewBag.Aantal = agendaAntwoorden.Count();
            return View(agendaAntwoorden.ToPagedList(pageNumber, pageSize));


        }
        // GET: Antwoord/Details/5
        public ActionResult Details(int id)
        {
            Antwoord antwoord = antwManager.readAntwoord(id);
            return View(antwoord);
        }

        // GET: Antwoord/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Antwoord/Create
        [HttpPost]
        public ActionResult Create(DossierAntwoord dossierAntwoord)
        {
            try
            {

                DossierModule dossiermodule = dossManager.readActieveDossierModule();
                
                dossierAntwoord.datum = DateTime.Now;
                dossierAntwoord.aantalFlags = 0;  
                dossierAntwoord.aantalStemmen = 0;
                dossierAntwoord.statusOnline = true;
                dossierAntwoord.module = dossiermodule;
                dossierAntwoord.gebruikersNaam= User.Identity.GetUserName();

                antwManager.createDossierAntwoord(dossierAntwoord);
                dossiermodule.dossierAntwoorden.Add(dossierAntwoord);
                dossManager.updateModule(dossiermodule);
                return RedirectToAction("Index","Home");
                 
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: Antwoord/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Antwoord/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Antwoord/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Antwoord/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
