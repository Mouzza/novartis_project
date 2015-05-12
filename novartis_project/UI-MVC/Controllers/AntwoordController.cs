using JPP.BL;
using JPP.BL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using PagedList;
using Microsoft.AspNet.Identity;
using JPP.DAL.Interface;
using JPP.BL.Domain.Vragen;
using JPP.BL.Domain.Modules;
using JPP.BL.Domain.Antwoorden;
using JPP.BL.Domain.Gebruikers;
using JPP.BL.Domain.Gebruikers.Beheerder;
using JPP.BL.Domain.Gebruikers.SuperUser;
using JPP.UI.Web.MVC;

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
        public ActionResult Dossier(int id)
        {
            DossierAntwoord dossierAntwoord = (DossierAntwoord)antwManager.readAntwoord(id);
            return View(dossierAntwoord);
        }
        public ActionResult Agenda(int id)
        {
            AgendaAntwoord agendaAntwoord = (AgendaAntwoord)antwManager.readAntwoord(id);
            return View(agendaAntwoord);
        }

        public ActionResult AdjustableDossierModelOne()
        {
            return View();
        }

        public ActionResult AdjustableDossierModelSix()
        {
            return View();
        }

        public ActionResult AdjustableDossierModelThree()
        {
            return View();
        }

        public ActionResult AdjustableDossierModelFive()
        {
            return View();
        }

        public ActionResult CreateDossier()
        {
            return View();
        }

        public ActionResult AdjustableDossierModelTwo()
        {
            return View();
        }

        public ActionResult DossierModelOne()
        {
            return View();
        }

        public ActionResult DossierModelTwo()
        {
            return View();
        }

        public ActionResult DossierModelThree()
        {
            return View();
        }

        public ActionResult DossierModelFive()
        {
            return View();
        }

        public ActionResult DossierModelSix()
        {
            return View();
        }

        public ActionResult homePartialAntwoorden(string searchString, string currentFilter, int? page)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            int pageSize = 8;
            int pageNumber = (page ?? 1);

            IEnumerable<Antwoord> antwoorden = antwManager.readAllAntwoorden();
            if (!String.IsNullOrEmpty(searchString))
            {
                antwoorden = antwoorden.Where(antw => antw.inhoud.Contains(searchString)
                                       || antw.titel.Contains(searchString));
            }
         
            return PartialView(antwoorden.ToPagedList(pageNumber, pageSize));
        }

        //Antwoord/Lijst

        public ActionResult _partialAntwoordLijst(string sortOrder, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.Top25SortParm = sortOrder == "top25" ? "" : "top25";
            ViewBag.Top5SortParm = sortOrder == "top5" ? "" : "top5";

            ViewBag.RecentSortParm = sortOrder == "recent" ? "" : "recent";

         
            
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            DossierModule dossiermodule = dossManager.readActieveDossierModule();
            List<DossierAntwoord> dossierAntwoorden = antwManager.getAllDossierAntwoordenPerModule(dossiermodule.ID);
            List<DossierAntwoord> dossierAntwoorden2 = new List<DossierAntwoord>();
            ViewBag.winnaar = dossierAntwoorden.Max(antw => antw.aantalStemmen);

            switch (sortOrder)
            {
                case "top25":
                    dossierAntwoorden = antwManager.sortDossierAntwoordMeesteLikes(dossierAntwoorden);
                    for (int i = 0; i < 25; i++)
                    {
                        dossierAntwoorden2.Add(dossierAntwoorden[i]);
                    }
                    break;
                case "top5":
                    dossierAntwoorden = antwManager.sortDossierAntwoordMeesteLikes(dossierAntwoorden);
                    for (int i = 0; i < 5; i++)
                    {
                        dossierAntwoorden2.Add(dossierAntwoorden[i]);
                    }
                    break;
                case "recent":
                    dossierAntwoorden = antwManager.sortDossierAntwoordNieuwOud(dossierAntwoorden);
                    dossierAntwoorden2 = dossierAntwoorden;
                    break;
                default:
                    dossierAntwoorden = antwManager.sortDossierAntwoordNieuwOud(dossierAntwoorden);
                    dossierAntwoorden2 = dossierAntwoorden;
                    break;
            }
            ViewBag.Aantal = dossierAntwoorden2.Count();
            return PartialView(dossierAntwoorden2.ToPagedList(pageNumber, pageSize));
 
        }

        public ActionResult _partialAgendaAntwoordLijst(string sortOrder, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.Top25SortParm = sortOrder=="top25" ? "" : "top25";
            ViewBag.Top5SortParm = sortOrder == "top5" ? "" : "top5";

          
            ViewBag.RecentSortParm = sortOrder =="recent" ? "" : "recent"; 
            

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            AgendaModule agendaModule = dossManager.readActieveAgendaModule();
            List<AgendaAntwoord> agendaAntwoorden = antwManager.getAllAgendaAntwoordenPerModule(agendaModule.ID);
            List<AgendaAntwoord> agendaAntwoorden2 = new List<AgendaAntwoord>();

            ViewBag.winnaar = agendaAntwoorden.Max(antw => antw.aantalStemmen);



            switch (sortOrder)
            {
                case "top25":
                    agendaAntwoorden = antwManager.sortAgendaAntwoordMeesteLikes(agendaAntwoorden);
                    for (int i = 0; i < 25; i++)
                    {
                        agendaAntwoorden2.Add(agendaAntwoorden[i]);
                    }
                        break;
                case "top5":
                        agendaAntwoorden = antwManager.sortAgendaAntwoordMeesteLikes(agendaAntwoorden);
                        for (int i = 0; i < 5; i++)
                        {
                            agendaAntwoorden2.Add(agendaAntwoorden[i]);
                        }
                        break;
                case "recent":
                    agendaAntwoorden = antwManager.sortAgendaAntwoordNieuwOud(agendaAntwoorden);
                    agendaAntwoorden2 = agendaAntwoorden;
                    break;
                default:
                    agendaAntwoorden = antwManager.sortAgendaAntwoordNieuwOud(agendaAntwoorden);
                    agendaAntwoorden2 = agendaAntwoorden;
                    break;
            }
            ViewBag.Aantal = agendaAntwoorden2.Count();
            return PartialView(agendaAntwoorden2.ToPagedList(pageNumber, pageSize));




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
                //dossiermodule.dossierAntwoorden.Add(dossierAntwoord);
                //dossManager.updateModule(dossiermodule);
                return RedirectToAction("Index","Home");
                 
            }
            catch
            {
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult AdjustableDossierModelOne(HttpPostedFileBase file)
        {

            if (file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.GetFullPath(Server.MapPath("~/App_Data/uploads/")+ fileName);
                file.SaveAs(path);
            }

            return RedirectToAction("AdjustableDossierModelOne");
        }

        [HttpPost]
        public ActionResult AdjustableDossierModelTwo(HttpPostedFileBase file)
        {

            if (file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.GetFullPath(Server.MapPath("~/App_Data/uploads/") + fileName);
                file.SaveAs(path);
            }

            return RedirectToAction("AdjustableDossierModelOne");
        }

        [HttpPost]
        public ActionResult AdjustableDossierModelThree(HttpPostedFileBase file)
        {

            if (file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.GetFullPath(Server.MapPath("~/App_Data/uploads/") + fileName);
                file.SaveAs(path);
            }

            return RedirectToAction("AdjustableDossierModelOne");
        }

        [HttpPost]
        public ActionResult AdjustableDossierModelSix(HttpPostedFileBase file)
        {

            if (file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.GetFullPath(Server.MapPath("~/App_Data/uploads/") + fileName);
                file.SaveAs(path);
            }

            return RedirectToAction("AdjustableDossierModelOne");
        }

        [HttpPost]
        public ActionResult AdjustableDossierModelFive(HttpPostedFileBase file)
        {

            if (file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.GetFullPath(Server.MapPath("~/App_Data/uploads/") + fileName);
                file.SaveAs(path);
            }

            return RedirectToAction("AdjustableDossierModelOne");
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
            Antwoord antwoord = antwManager.readAntwoord(id);
            return View(antwoord);
        }

        // POST: Antwoord/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                antwManager.removeAntwoord(id);
                return RedirectToAction("Index", "Module");
            }
            catch
            {
                return View();
            }
        }
    }
}
