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
using JPP.BL.Domain.Antwoorden;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using PagedList;



namespace JPP.UI.Web.MVC.Controllers
{

    public class ModuleController : Controller
    {

        ModuleManager moduleManager = new ModuleManager();
        AntwoordManager antwManager = new AntwoordManager();

        public ActionResult VoteUp(int id)
        {
            DossierAntwoord dossierAntwoord = antwManager.readDossierAntwoord(id);
            dossierAntwoord.aantalStemmen = (dossierAntwoord.aantalStemmen + 1);
            antwManager.updateDossierAntwoord(dossierAntwoord);
            return RedirectToAction("Dossier", "Module");
            
        }

        public ActionResult VoteUpAgenda(int id)
        {
            AgendaAntwoord agendaAntwoord = antwManager.readAgendaAntwoord(id);
            agendaAntwoord.aantalStemmen = (agendaAntwoord.aantalStemmen + 1);
            antwManager.updateAgendaAntwoord(agendaAntwoord);
            return RedirectToAction("Agenda", "Module");

        }

        public ActionResult VolgOp()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Manage()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult MijnDossierModules()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult MijnAgendaModules()
        {
            return View();
        }


        public ActionResult DossierModuleUitleg()
        {
            DossierModule dossierModule = moduleManager.readActieveDossierModule();
            if (dossierModule.beloning.naam == null)
            {
                Beloning beloning = new Beloning();
                beloning.naam = " ";
                beloning.beschrijving = " ";
                dossierModule.beloning = beloning;
            }
            return View(dossierModule);
        }

        public ActionResult AgendaModuleUitleg()
        {
            AgendaModule agendaModule = moduleManager.readActieveAgendaModule();
            if (agendaModule.beloning.naam == null)
            {
                Beloning beloning = new Beloning();
                beloning.naam = " ";
                beloning.beschrijving = " ";
                agendaModule.beloning = beloning;
            }
            return View(agendaModule);
        }

        public ActionResult DossModules()
        {
            return View();
        }
        public ActionResult AgdModules()
        {
            return View();

        }

        public ActionResult MijnGeplandeDossierModules(int? page)
        {

            int pageSize = 4;
            int pageNumber = (page ?? 1);


            IEnumerable<DossierModule> geplandeDossierModules = moduleManager.readGeplandeModules().OfType<DossierModule>().OrderBy(o => o.beginDatum).Where(mod => mod.adminNaam == User.Identity.GetUserName());
            return PartialView(geplandeDossierModules.ToPagedList(pageNumber, pageSize));

        }

        public ActionResult MijnGeplandeAgendaModules(int? page)
        {

            int pageSize = 4;
            int pageNumber = (page ?? 1);



            IEnumerable<AgendaModule> geslotenAgendaModules = moduleManager.readGeplandeModules().OfType<AgendaModule>().Where(mod=>mod.adminNaam==User.Identity.GetUserName());
            return PartialView(geslotenAgendaModules.ToPagedList(pageNumber, pageSize));

        }


        public ActionResult _GeplandeDossierModules(int? page)
        {

            int pageSize = 10;
            int pageNumber = (page ?? 1);


            IEnumerable<Module> geslotenModules = moduleManager.readGeplandeModules().OrderBy(o=> o.beginDatum);
            return PartialView(geslotenModules.ToPagedList(pageNumber, pageSize));

        }

        public ActionResult _GeplandeAgendaModules(int? page)
        {

            int pageSize = 5;
            int pageNumber = (page ?? 1);



            IEnumerable<AgendaModule> geslotenAgendaModules = moduleManager.readGeplandeModules().OfType<AgendaModule>();
            return PartialView(geslotenAgendaModules.ToPagedList(pageNumber, pageSize));

        }

        public ActionResult GeplandeDossierModules(int? page)
        {

            int pageSize = 5;
            int pageNumber = (page ?? 1);


            IEnumerable<DossierModule> geslotenDossierModules = moduleManager.readGeplandeModules().OfType<DossierModule>();
            return PartialView(geslotenDossierModules.ToPagedList(pageNumber, pageSize));

        }

        public ActionResult GeplandeAgendaModules(int? page)
        {

            int pageSize = 5;
            int pageNumber = (page ?? 1);



            IEnumerable<AgendaModule> geslotenAgendaModules = moduleManager.readGeplandeModules().OfType<AgendaModule>();
            return PartialView(geslotenAgendaModules.ToPagedList(pageNumber, pageSize));

        }

        public ActionResult MijnGeslotenDossierModules(int? page)
        {

            int pageSize = 5;
            int pageNumber = (page ?? 1);


            IEnumerable<DossierModule> geslotenDossierModules = moduleManager.readGeslotenDossiers().Where(dos => dos.adminNaam == User.Identity.GetUserName());
            return PartialView(geslotenDossierModules.ToPagedList(pageNumber, pageSize));

        }


        public ActionResult MijnGeslotenAgendaModules(int? page)
        {

            int pageSize = 4;
            int pageNumber = (page ?? 1);



            IEnumerable<AgendaModule> geslotenAgendaModules = moduleManager.readGeslotenAgendas().Where(dos => dos.adminNaam == User.Identity.GetUserName());
            return PartialView(geslotenAgendaModules.ToPagedList(pageNumber, pageSize));

        }

        public ActionResult GeslotenDossierModules(int? page)
        {

            int pageSize = 4;
            int pageNumber = (page ?? 1);

     
            IEnumerable<DossierModule> geslotenDossierModules = moduleManager.readGeslotenDossiers();
            return PartialView(geslotenDossierModules.ToPagedList(pageNumber, pageSize));

        }


        public ActionResult GeslotenAgendaModules(int? page)
        {

            int pageSize = 5;
            int pageNumber = (page ?? 1);

     
       
            IEnumerable<AgendaModule> geslotenAgendaModules = moduleManager.readGeslotenAgendas();
            return PartialView(geslotenAgendaModules.ToPagedList(pageNumber, pageSize));

        }

        public ActionResult _GeslotenDossierModules(int? page)
        {

            int pageSize = 10;
            int pageNumber = (page ?? 1);


            IEnumerable<Module> geslotenModules = moduleManager.readGeslotenModules();
            return PartialView(geslotenModules.ToPagedList(pageNumber, pageSize));

        }

        public ActionResult _GeslotenAgendaModules(int? page)
        {

            int pageSize = 5;
            int pageNumber = (page ?? 1);



            IEnumerable<AgendaModule> geslotenAgendaModules = moduleManager.readGeslotenAgendas();
            return PartialView(geslotenAgendaModules.ToPagedList(pageNumber, pageSize));

        }

        public ActionResult CommingSoon()
        {
            IEnumerable<Module> module = moduleManager.readGeplandeModules().OrderBy(o => o.beginDatum);
            return View(module.ToPagedList(1,4));
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

       public ActionResult partialViewDossierModule()
       {


          DossierModule dossierModule = moduleManager.readActieveDossierModule();

           return PartialView(dossierModule);

       }
       public ActionResult partialViewAgendaModule()
       {
          

           AgendaModule agendaModule = moduleManager.readActieveAgendaModule();
           return PartialView(agendaModule);
       }
       public ActionResult partialViewMijnDossierModule()
       {


           DossierModule dossierModule = moduleManager.readActieveDossierModule();
           

           return PartialView(dossierModule);

       }
       public ActionResult partialViewMijnAgendaModule()
       {


           AgendaModule agendaModule = moduleManager.readActieveAgendaModule();
           return PartialView(agendaModule);
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
                moduleManager.removeDossierModule(id);
                return RedirectToAction("DossModules", "Module");
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
                moduleManager.removeAgendaModule(id);
                return RedirectToAction("AgdModules", "Module");
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

                moduleManager.updateDossierModule(DossierModule);
                return RedirectToAction("DossModules", "Module");
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

                moduleManager.updateAgendaModule(agendaModule);
                return RedirectToAction("AgdModules", "Module");
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


        public ActionResult WinnaarVanModule(int id)
        {
            List<DossierModule> dosModuleList = moduleManager.readGeslotenDossiers();
            int exist = 0;
            int identity = id;
            foreach (var item in dosModuleList)
            {
                if (item.ID == id)
                {
                    exist = 1;
                   
                }
            }

            if (exist == 0)
            {
                return RedirectToAction("WinnaarVanModuleAgenda", new { id = identity });
            }
            else
            {
                DossierModule dosmod = (DossierModule)moduleManager.readModule(id);
                List<DossierAntwoord> agAntwoordList = antwManager.getAllDossierAntwoordenPerModule(id);
                int pageSize = dosmod.centraleVraag.aantalWinAntwoorden;
                if (pageSize < 3)
                {
                    pageSize = 3;
                }
                int pageNumber = 1;



                IEnumerable<DossierAntwoord> gewonnenAntwoorden = antwManager.getAllDossierAntwoordenPerModule(id).OrderBy(o => o.aantalStemmen);
                List<DossierAntwoord> FirstAntwoorden = new List<DossierAntwoord>();

                for (int i = 0; i < dosmod.centraleVraag.aantalWinAntwoorden; i++)
                {
                    FirstAntwoorden.Add(gewonnenAntwoorden.ElementAt(i));
                }
                return PartialView(gewonnenAntwoorden.ToPagedList(pageNumber, pageSize));
            }
                
          
       
            
        }

        public ActionResult WinnaarVanModuleAgenda(int id)
        {
            AgendaModule agendaModule = (AgendaModule)moduleManager.readModule(id);
            List<AgendaAntwoord> agAntwoordList = antwManager.getAllAgendaAntwoordenPerModule(id);
            int pageSize = agendaModule.centraleVraag.aantalWinAntwoorden;
            if (pageSize < 3)
            {
                pageSize = 3;
            }
            int pageNumber = 1;



            IEnumerable<AgendaAntwoord> gewonnenAntwoorden = antwManager.getAllAgendaAntwoordenPerModule(id).OrderBy(o => o.aantalStemmen);
            List<AgendaAntwoord> FirstAntwoorden = new List<AgendaAntwoord>();

            for (int i = 0; i < agendaModule.centraleVraag.aantalWinAntwoorden; i++)
            {
                FirstAntwoorden.Add(gewonnenAntwoorden.ElementAt(i));
            }
            return PartialView(gewonnenAntwoorden.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult DossierModuleToekomst(int id)
        {
            Module module = moduleManager.readModule(id);
            return View(module);
        }

    }
}