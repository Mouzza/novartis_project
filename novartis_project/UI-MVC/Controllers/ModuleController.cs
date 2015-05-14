using JPP.BL;
using JPP.BL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using JPP.UI.Web.MVC.Models;
using JPP.BL.Domain.Modules;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using PagedList;



namespace JPP.UI.Web.MVC.Controllers
{

    public class ModuleController : Controller
    {

        ModuleManager moduleManager = new ModuleManager();



        public ActionResult CommingSoon()
        {

            return View();
        }

        public ActionResult GeplandeModules(int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            IEnumerable<Module> geplandeModules = moduleManager.readGeplandeModules();

            return View(geplandeModules.ToPagedList(pageNumber, pageSize));
        }


        // GET: Module
       [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }

       public ActionResult partialViewDossierModule(int? page)
       {
           int pageSize = 5;
           int pageNumber = (page ?? 1);

           IEnumerable<DossierModule> DossierModules = moduleManager.readAllDossierModules();

           return PartialView(DossierModules.ToPagedList(pageNumber, pageSize));

       }
       public ActionResult partialViewAgendaModule(int? page)
       {
           int pageSize = 5;
           int pageNumber = (page ?? 1);

           IEnumerable<AgendaModule> AgendaModules = moduleManager.readAllAgendaModules();
           return PartialView(AgendaModules.ToPagedList(pageNumber, pageSize));
       }
       public ActionResult Dossier()
       {

           return View();
       }

       public ActionResult Agenda()
       {

           return View();
       }
      
    
        
        public ActionResult Actief()
        {
           //DossierModule actieveDossierModule = moduleManager.readAllDossierModules().Where(dmod => dmod.status == true).First();

            DossierModule actieveDossierModule = moduleManager.readActieveDossierModule();
           return View(actieveDossierModule);
        }

        public ActionResult ActiefAgenda()
        {
            //DossierModule actieveDossierModule = moduleManager.readAllDossierModules().Where(dmod => dmod.status == true).First();

            AgendaModule actieveAgendaModule = moduleManager.readActieveAgendaModule();
            return View(actieveAgendaModule);
        }

       [Authorize(Roles = "Admin")]
        public ActionResult Details(int id)
        {
            DossierModule DossierModule = (DossierModule)moduleManager.readModule(id);

            return View(DossierModule);
        }
       [Authorize(Roles = "Admin")]
       public ActionResult _Details(int id)
       {
           AgendaModule agendaModule = (AgendaModule)moduleManager.readModule(id);

           return View(agendaModule);
       }
       [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            DossierModule DossierModule = (DossierModule)moduleManager.readModule(id);

            return View(DossierModule);
        }
        // POST: Module/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                moduleManager.removeModule(id);
                return RedirectToAction("Index", "Module");
            }
            catch
            {
                return View("Error");
            }
        }

        [Authorize(Roles = "Admin")]
        public ActionResult _Delete(int id)
        {
            AgendaModule agendaModule = (AgendaModule)moduleManager.readModule(id);

            return View(agendaModule);
        }
        // POST: Module/_Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult _Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                moduleManager.removeModule(id);
                return RedirectToAction("Index", "Module");
            }
            catch
            {
                return View("Error");
            }
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
       
            DossierModule DossierModule = (DossierModule)moduleManager.readModule(id);

            return View(DossierModule);
        }
        // POST: Module/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(DossierModule DossierModule)
        {
            
            try
            {
                
                // TODO: Add update logic here

                moduleManager.updateModule(DossierModule);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles = "Admin")]
        public ActionResult _Edit(int id)
        {

            AgendaModule agendaModule = (AgendaModule)moduleManager.readModule(id);

            return View(agendaModule);
        }
        // POST: Module/_Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult _Edit(AgendaModule agendaModule)
        {

            try
            {

                // TODO: Add update logic here

                moduleManager.updateModule(agendaModule);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        // GET: Module/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {

            return View();
        }

        // POST: Module/Create
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(DossierModule dosModule)
        {
            try
            {
              
                dosModule.adminNaam = User.Identity.GetUserName();

                // TODO: Add insert logic here
                moduleManager.createDossierModule(dosModule);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: Module/_Create
        [Authorize(Roles = "Admin")]
        public ActionResult _Create()
        {

            return View();
        }

        // POST: Module/_Create
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult _Create(AgendaModule agModule)
        {
            try
            {

                agModule.adminNaam = User.Identity.GetUserName();

                // TODO: Add insert logic here
                moduleManager.createAgendaModule(agModule);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}