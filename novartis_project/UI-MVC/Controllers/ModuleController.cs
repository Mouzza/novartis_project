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

namespace JPP.UI.Web.MVC.Controllers
{

    public class ModuleController : Controller
    {

        ModuleManager moduleManager = new ModuleManager();


        // GET: Module
       [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            IEnumerable<DossierModule> DossierModules = moduleManager.readAllDossierModules();

            return View(DossierModules);
        }

        public ActionResult Actief()
        {
           //DossierModule actieveDossierModule = moduleManager.readAllDossierModules().Where(dmod => dmod.status == true).First();

            DossierModule actieveDossierModule = moduleManager.readActieveDossierModule();
           return View(actieveDossierModule);
        }
       [Authorize(Roles = "Admin")]
        public ActionResult Details(int id)
        {
            DossierModule DossierModule = (DossierModule)moduleManager.readModule(id);

            return View(DossierModule);
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
                return RedirectToAction("Index");
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
                return View("Error");
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
        public ActionResult Create(DossiermoduleView dosModule)
        {
            try
            {


                DossierModule dossierModule = new DossierModule();
                dossierModule.vasteVragen.Add(dosModule.vasteVraag);
                // TODO: Add insert logic here
               moduleManager.createModule(dosModule.dossiermodule);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }

    }
}