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

        public ActionResult AdjustableDossierModelOne(DossierAntwoord dossierAntwoord)
        {

            //if (!Request.IsAuthenticated)
            //{
            //    return RedirectToAction("Login","Account");
            //}

            if (dossierAntwoord.titel != null)
            {
                return View(dossierAntwoord);
            }
            else
            {

                dossierAntwoord = new DossierAntwoord()
                {

                    titel = "Geef titel",
                    subtitel = "Geef subtitel",
                    inhoud = "Aliquam condimentum magna ac ultricies posuere. Cras viverra velit lectus,vel pretium nulla posuere sit amet. Vestibulum venenatis volutpat dui. Aliquam dictum metus eget est sodales malesuada. Nunc pharetra iaculis suscipit. Mauris sed lectus nec nunc laoreet molestie et ac ex. Duis a aliquam sapien. Nullam fermentum diam arcu, nec lacinia metus pulvinar at. Nunc eget tempor ex. Nunc vehicula neque ut vulputate feugiat. Aenean euismod posuere nunc, a aliquet nunc laoreet nec. Phasellus faucibus mi et bibendum pretium. Morbi magna lorem, eleifend at convallis quis, pretium id turpis. In suscipit, magna ac laoreet pellentesque, augue risus cursus arcu, eget ornare est libero vel leo. Etiam hendrerit hendrerit arcu, posuere semper sapien facilisis a.",
                    textvak2 = "Aliquam condimentum magna ac ultricies posuere. Cras viverra velit lectus,vel pretium nulla posuere sit amet. Vestibulum venenatis volutpat dui. Aliquam dictum metus eget est sodales malesuada. Nunc pharetra iaculis suscipit. Mauris sed lectus nec nunc laoreet molestie et ac ex. Duis a aliquam sapien. Nullam fermentum diam arcu, nec lacinia metus pulvinar at. Nunc eget tempor ex. Nunc vehicula neque ut vulputate feugiat. Aenean euismod posuere nunc, a aliquet nunc laoreet nec. Phasellus faucibus mi et bibendum pretium.",
                    textvak3 = "Aliquam condimentum magna ac ultricies posuere. Cras viverra velit lectus,vel pretium nulla posuere sit amet. Vestibulum venenatis volutpat dui. Aliquam dictum metus eget est sodales malesuada. Nunc pharetra iaculis suscipit. Mauris sed lectus nec nunc laoreet molestie et ac ex. Duis a aliquam sapien. Nullam fermentum diam arcu, nec lacinia metus pulvinar at. Nunc eget tempor ex. Nunc vehicula neque ut vulputate feugiat. Aenean euismod posuere nunc, a aliquet nunc laoreet nec. Phasellus faucibus mi et bibendum pretium.",
                    afbeeldingPath = "~/uploads/379465.png"

                };

                return View(dossierAntwoord);
            }
        }

        ModuleManager modMan = new ModuleManager();

        [HttpPost]
        public ActionResult AdjustableDossierModelOne(HttpPostedFileBase file, DossierAntwoord dossierAntwoord)
        {
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.GetFullPath(Server.MapPath("~/uploads/") + fileName);
                file.SaveAs(path);
                dossierAntwoord.afbeeldingPath = "/uploads/" + fileName;
            }
            dossierAntwoord.gebruikersNaam = User.Identity.GetUserName();
            //antwManager.createDossierAntwoord(dossierAntwoord);
            dossierAntwoord.comments = new List<Comment>();
            dossierAntwoord.vasteTags = new List<VasteTag>();
            dossierAntwoord.persoonlijkeTags = new List<PersoonlijkeTag>();
            dossierAntwoord.datum = DateTime.Now;
            dossierAntwoord.aantalStemmen = 0;
            dossierAntwoord.percentageVolledigheid = 95;
            dossierAntwoord.statusOnline = true;
            //dossierAntwoord.extraVraag = "Zou het mogelijk zijn om handtekeningen te verzamelen om mijn idee te kunnen steunen?";
            dossierAntwoord.aantalFlags = 0;
            //dossierAntwoord.module = modMan.readActieveDossierModule();
            Antwoord createddos = antwManager.createDossierAntwoord(dossierAntwoord);  // CreateDossier geeft problemen

            return RedirectToAction("DossierModelOne", new { id = createddos.ID });
        }


        public ActionResult AdjustableDossierModelSix()
        {
            return View();
        }

        public ActionResult CreateDossier()
        {
            return View();
        }

        public ActionResult AdjustableDossierModelTwo(DossierAntwoord dossierAntwoord)
        {

            //if (!Request.IsAuthenticated)
            //{
            //    return RedirectToAction("Login","Account");
            //}

            if (dossierAntwoord.titel != null)
            {
                return View(dossierAntwoord);
            }
            else
            {

                dossierAntwoord = new DossierAntwoord()
                {

                    titel = "Geef titel",
                    subtitel = "Geef subtitel",
                    inhoud = "Aliquam condimentum magna ac ultricies posuere. Cras viverra velit lectus,vel pretium nulla posuere sit amet. Vestibulum venenatis volutpat dui. Aliquam dictum metus eget est sodales malesuada. Nunc pharetra iaculis suscipit. Mauris sed lectus nec nunc laoreet molestie et ac ex. Duis a aliquam sapien. Nullam fermentum diam arcu, nec lacinia metus pulvinar at. Nunc eget tempor ex. Nunc vehicula neque ut vulputate feugiat. Aenean euismod posuere nunc, a aliquet nunc laoreet nec. Phasellus faucibus mi et bibendum pretium. Morbi magna lorem, eleifend at convallis quis, pretium id turpis. In suscipit, magna ac laoreet pellentesque, augue risus cursus arcu, eget ornare est libero vel leo. Etiam hendrerit hendrerit arcu, posuere semper sapien facilisis a.",
                    textvak2 = "Aliquam condimentum magna ac ultricies posuere. Cras viverra velit lectus,vel pretium nulla posuere sit amet. Vestibulum venenatis volutpat dui. Aliquam dictum metus eget est sodales malesuada. Nunc pharetra iaculis suscipit. Mauris sed lectus nec nunc laoreet molestie et ac ex. Duis a aliquam sapien. Nullam fermentum diam arcu, nec lacinia metus pulvinar at. Nunc eget tempor ex. Nunc vehicula neque ut vulputate feugiat. Aenean euismod posuere nunc, a aliquet nunc laoreet nec. Phasellus faucibus mi et bibendum pretium.",
                    textvak3 = "Aliquam condimentum magna ac ultricies posuere. Cras viverra velit lectus,vel pretium nulla posuere sit amet. Vestibulum venenatis volutpat dui. Aliquam dictum metus eget est sodales malesuada. Nunc pharetra iaculis suscipit. Mauris sed lectus nec nunc laoreet molestie et ac ex. Duis a aliquam sapien. Nullam fermentum diam arcu, nec lacinia metus pulvinar at. Nunc eget tempor ex. Nunc vehicula neque ut vulputate feugiat. Aenean euismod posuere nunc, a aliquet nunc laoreet nec. Phasellus faucibus mi et bibendum pretium.",
                    afbeeldingPath = "~/uploads/379465.png"

                };

                return View(dossierAntwoord);
            }
        }

        [HttpPost]
        public ActionResult AdjustableDossierModelTwo(HttpPostedFileBase file, DossierAntwoord dossierAntwoord)
        {
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.GetFullPath(Server.MapPath("~/uploads/") + fileName);
                file.SaveAs(path);
                dossierAntwoord.afbeeldingPath = "/uploads/" + fileName;
            }
            dossierAntwoord.gebruikersNaam = User.Identity.GetUserName();
            //antwManager.createDossierAntwoord(dossierAntwoord);
            dossierAntwoord.comments = new List<Comment>();
            dossierAntwoord.vasteTags = new List<VasteTag>();
            dossierAntwoord.persoonlijkeTags = new List<PersoonlijkeTag>();
            dossierAntwoord.datum = DateTime.Now;
            dossierAntwoord.aantalStemmen = 0;
            dossierAntwoord.percentageVolledigheid = 95;
            dossierAntwoord.statusOnline = true;
            //dossierAntwoord.extraVraag = "Zou het mogelijk zijn om handtekeningen te verzamelen om mijn idee te kunnen steunen?";
            dossierAntwoord.aantalFlags = 0;
            //dossierAntwoord.module = modMan.readActieveDossierModule();
            Antwoord createddos = antwManager.createDossierAntwoord(dossierAntwoord);  // CreateDossier geeft problemen

            return RedirectToAction("DossierModelTwo", new { id = createddos.ID });
        }

        public ActionResult AdjustableDossierModelThree(DossierAntwoord dossierAntwoord)
        {

            //if (!Request.IsAuthenticated)
            //{
            //    return RedirectToAction("Login","Account");
            //}

            if (dossierAntwoord.titel != null)
            {
                return View(dossierAntwoord);
            }
            else
            {

                dossierAntwoord = new DossierAntwoord()
                {

                    titel = "Geef titel",
                    subtitel = "Geef subtitel",
                    inhoud = "Aliquam condimentum magna ac ultricies posuere. Cras viverra velit lectus,vel pretium nulla posuere sit amet. Vestibulum venenatis volutpat dui. Aliquam dictum metus eget est sodales malesuada. Nunc pharetra iaculis suscipit. Mauris sed lectus nec nunc laoreet molestie et ac ex. Duis a aliquam sapien. Nullam fermentum diam arcu, nec lacinia metus pulvinar at. Nunc eget tempor ex. Nunc vehicula neque ut vulputate feugiat. Aenean euismod posuere nunc, a aliquet nunc laoreet nec. Phasellus faucibus mi et bibendum pretium. Morbi magna lorem, eleifend at convallis quis, pretium id turpis. In suscipit, magna ac laoreet pellentesque, augue risus cursus arcu, eget ornare est libero vel leo. Etiam hendrerit hendrerit arcu, posuere semper sapien facilisis a.",
                    textvak2 = "Aliquam condimentum magna ac ultricies posuere. Cras viverra velit lectus,vel pretium nulla posuere sit amet. Vestibulum venenatis volutpat dui. Aliquam dictum metus eget est sodales malesuada. Nunc pharetra iaculis suscipit. Mauris sed lectus nec nunc laoreet molestie et ac ex. Duis a aliquam sapien. Nullam fermentum diam arcu, nec lacinia metus pulvinar at. Nunc eget tempor ex. Nunc vehicula neque ut vulputate feugiat. Aenean euismod posuere nunc, a aliquet nunc laoreet nec. Phasellus faucibus mi et bibendum pretium.",
                    textvak3 = "Aliquam condimentum magna ac ultricies posuere. Cras viverra velit lectus,vel pretium nulla posuere sit amet. Vestibulum venenatis volutpat dui. Aliquam dictum metus eget est sodales malesuada. Nunc pharetra iaculis suscipit. Mauris sed lectus nec nunc laoreet molestie et ac ex. Duis a aliquam sapien. Nullam fermentum diam arcu, nec lacinia metus pulvinar at. Nunc eget tempor ex. Nunc vehicula neque ut vulputate feugiat. Aenean euismod posuere nunc, a aliquet nunc laoreet nec. Phasellus faucibus mi et bibendum pretium.",
                    afbeeldingPath = "~/uploads/379465.png"

                };

                return View(dossierAntwoord);
            }
        }

        [HttpPost]
        public ActionResult AdjustableDossierModelThree(HttpPostedFileBase file, DossierAntwoord dossierAntwoord)
        {
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.GetFullPath(Server.MapPath("~/uploads/") + fileName);
                file.SaveAs(path);
                dossierAntwoord.afbeeldingPath = "/uploads/" + fileName;
            }
            dossierAntwoord.gebruikersNaam = User.Identity.GetUserName();
            //antwManager.createDossierAntwoord(dossierAntwoord);
            dossierAntwoord.comments = new List<Comment>();
            dossierAntwoord.vasteTags = new List<VasteTag>();
            dossierAntwoord.persoonlijkeTags = new List<PersoonlijkeTag>();
            dossierAntwoord.datum = DateTime.Now;
            dossierAntwoord.aantalStemmen = 0;
            dossierAntwoord.percentageVolledigheid = 95;
            dossierAntwoord.statusOnline = true;
            //dossierAntwoord.extraVraag = "Zou het mogelijk zijn om handtekeningen te verzamelen om mijn idee te kunnen steunen?";
            dossierAntwoord.aantalFlags = 0;
            //dossierAntwoord.module = modMan.readActieveDossierModule();
            Antwoord createddos = antwManager.createDossierAntwoord(dossierAntwoord);  // CreateDossier geeft problemen

            return RedirectToAction("DossierModelThree", new { id = createddos.ID });
        }

        public ActionResult AdjustableDossierModelFive(DossierAntwoord dossierAntwoord)
        {

            //if (!Request.IsAuthenticated)
            //{
            //    return RedirectToAction("Login","Account");
            //}

            if (dossierAntwoord.titel != null)
            {
                return View(dossierAntwoord);
            }
            else
            {

                dossierAntwoord = new DossierAntwoord()
                {

                    titel = "Geef titel",
                    subtitel = "Geef subtitel",
                    inhoud = "Aliquam condimentum magna ac ultricies posuere. Cras viverra velit lectus,vel pretium nulla posuere sit amet. Vestibulum venenatis volutpat dui. Aliquam dictum metus eget est sodales malesuada. Nunc pharetra iaculis suscipit. Mauris sed lectus nec nunc laoreet molestie et ac ex. Duis a aliquam sapien. Nullam fermentum diam arcu, nec lacinia metus pulvinar at. Nunc eget tempor ex. Nunc vehicula neque ut vulputate feugiat. Aenean euismod posuere nunc, a aliquet nunc laoreet nec. Phasellus faucibus mi et bibendum pretium. Morbi magna lorem, eleifend at convallis quis, pretium id turpis. In suscipit, magna ac laoreet pellentesque, augue risus cursus arcu, eget ornare est libero vel leo. Etiam hendrerit hendrerit arcu, posuere semper sapien facilisis a.",
                    textvak2 = "Aliquam condimentum magna ac ultricies posuere. Cras viverra velit lectus,vel pretium nulla posuere sit amet. Vestibulum venenatis volutpat dui. Aliquam dictum metus eget est sodales malesuada. Nunc pharetra iaculis suscipit. Mauris sed lectus nec nunc laoreet molestie et ac ex. Duis a aliquam sapien. Nullam fermentum diam arcu, nec lacinia metus pulvinar at. Nunc eget tempor ex. Nunc vehicula neque ut vulputate feugiat. Aenean euismod posuere nunc, a aliquet nunc laoreet nec. Phasellus faucibus mi et bibendum pretium.",
                    textvak3 = "Aliquam condimentum magna ac ultricies posuere. Cras viverra velit lectus,vel pretium nulla posuere sit amet. Vestibulum venenatis volutpat dui. Aliquam dictum metus eget est sodales malesuada. Nunc pharetra iaculis suscipit. Mauris sed lectus nec nunc laoreet molestie et ac ex. Duis a aliquam sapien. Nullam fermentum diam arcu, nec lacinia metus pulvinar at. Nunc eget tempor ex. Nunc vehicula neque ut vulputate feugiat. Aenean euismod posuere nunc, a aliquet nunc laoreet nec. Phasellus faucibus mi et bibendum pretium.",
                    afbeeldingPath = "~/uploads/379465.png"

                };

                return View(dossierAntwoord);
            }
        }

        [HttpPost]
        public ActionResult AdjustableDossierModelFive(HttpPostedFileBase file, DossierAntwoord dossierAntwoord)
        {
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.GetFullPath(Server.MapPath("~/uploads/") + fileName);
                file.SaveAs(path);
                dossierAntwoord.afbeeldingPath = "/uploads/" + fileName;
            }
            dossierAntwoord.gebruikersNaam = User.Identity.GetUserName();
            //antwManager.createDossierAntwoord(dossierAntwoord);
            dossierAntwoord.comments = new List<Comment>();
            dossierAntwoord.vasteTags = new List<VasteTag>();
            dossierAntwoord.persoonlijkeTags = new List<PersoonlijkeTag>();
            dossierAntwoord.datum = DateTime.Now;
            dossierAntwoord.aantalStemmen = 0;
            dossierAntwoord.percentageVolledigheid = 95;
            dossierAntwoord.statusOnline = true;
            //dossierAntwoord.extraVraag = "Zou het mogelijk zijn om handtekeningen te verzamelen om mijn idee te kunnen steunen?";
            dossierAntwoord.aantalFlags = 0;
            //dossierAntwoord.module = modMan.readActieveDossierModule();
            Antwoord createddos = antwManager.createDossierAntwoord(dossierAntwoord);  // CreateDossier geeft problemen

            return RedirectToAction("DossierModelThree", new { id = createddos.ID });
        }



        public ActionResult DossierModelOne(int id)
        {
            DossierAntwoord dossierAntwoord = new DossierAntwoord();
            if (id != null)
            {
                dossierAntwoord = (DossierAntwoord)antwManager.readAntwoord(id);
                return View(dossierAntwoord);
            }
            else
            {

                dossierAntwoord = new DossierAntwoord()
                {

                    titel = "Geef titel",
                    subtitel = "Geef subtitel",
                    inhoud = "Aliquam condimentum magna ac ultricies posuere. Cras viverra velit lectus,vel pretium nulla posuere sit amet. Vestibulum venenatis volutpat dui. Aliquam dictum metus eget est sodales malesuada. Nunc pharetra iaculis suscipit. Mauris sed lectus nec nunc laoreet molestie et ac ex. Duis a aliquam sapien. Nullam fermentum diam arcu, nec lacinia metus pulvinar at. Nunc eget tempor ex. Nunc vehicula neque ut vulputate feugiat. Aenean euismod posuere nunc, a aliquet nunc laoreet nec. Phasellus faucibus mi et bibendum pretium. Morbi magna lorem, eleifend at convallis quis, pretium id turpis. In suscipit, magna ac laoreet pellentesque, augue risus cursus arcu, eget ornare est libero vel leo. Etiam hendrerit hendrerit arcu, posuere semper sapien facilisis a.",
                    textvak2 = "Aliquam condimentum magna ac ultricies posuere. Cras viverra velit lectus,vel pretium nulla posuere sit amet. Vestibulum venenatis volutpat dui. Aliquam dictum metus eget est sodales malesuada. Nunc pharetra iaculis suscipit. Mauris sed lectus nec nunc laoreet molestie et ac ex. Duis a aliquam sapien. Nullam fermentum diam arcu, nec lacinia metus pulvinar at. Nunc eget tempor ex. Nunc vehicula neque ut vulputate feugiat. Aenean euismod posuere nunc, a aliquet nunc laoreet nec. Phasellus faucibus mi et bibendum pretium.",
                    textvak3 = "Aliquam condimentum magna ac ultricies posuere. Cras viverra velit lectus,vel pretium nulla posuere sit amet. Vestibulum venenatis volutpat dui. Aliquam dictum metus eget est sodales malesuada. Nunc pharetra iaculis suscipit. Mauris sed lectus nec nunc laoreet molestie et ac ex. Duis a aliquam sapien. Nullam fermentum diam arcu, nec lacinia metus pulvinar at. Nunc eget tempor ex. Nunc vehicula neque ut vulputate feugiat. Aenean euismod posuere nunc, a aliquet nunc laoreet nec. Phasellus faucibus mi et bibendum pretium.",
                    afbeeldingPath = "/uploads/379465.png"

                };

                return View(dossierAntwoord);
            }
        }

        public ActionResult DossierModelTwo(int id)
        {
            DossierAntwoord dossierAntwoord = new DossierAntwoord();
            if (id != null)
            {
                dossierAntwoord = (DossierAntwoord)antwManager.readAntwoord(id);
                return View(dossierAntwoord);
            }
            else
            {

                dossierAntwoord = new DossierAntwoord()
                {

                    titel = "Geef titel",
                    subtitel = "Geef subtitel",
                    inhoud = "Aliquam condimentum magna ac ultricies posuere. Cras viverra velit lectus,vel pretium nulla posuere sit amet. Vestibulum venenatis volutpat dui. Aliquam dictum metus eget est sodales malesuada. Nunc pharetra iaculis suscipit. Mauris sed lectus nec nunc laoreet molestie et ac ex. Duis a aliquam sapien. Nullam fermentum diam arcu, nec lacinia metus pulvinar at. Nunc eget tempor ex. Nunc vehicula neque ut vulputate feugiat. Aenean euismod posuere nunc, a aliquet nunc laoreet nec. Phasellus faucibus mi et bibendum pretium. Morbi magna lorem, eleifend at convallis quis, pretium id turpis. In suscipit, magna ac laoreet pellentesque, augue risus cursus arcu, eget ornare est libero vel leo. Etiam hendrerit hendrerit arcu, posuere semper sapien facilisis a.",
                    textvak2 = "Aliquam condimentum magna ac ultricies posuere. Cras viverra velit lectus,vel pretium nulla posuere sit amet. Vestibulum venenatis volutpat dui. Aliquam dictum metus eget est sodales malesuada. Nunc pharetra iaculis suscipit. Mauris sed lectus nec nunc laoreet molestie et ac ex. Duis a aliquam sapien. Nullam fermentum diam arcu, nec lacinia metus pulvinar at. Nunc eget tempor ex. Nunc vehicula neque ut vulputate feugiat. Aenean euismod posuere nunc, a aliquet nunc laoreet nec. Phasellus faucibus mi et bibendum pretium.",
                    textvak3 = "Aliquam condimentum magna ac ultricies posuere. Cras viverra velit lectus,vel pretium nulla posuere sit amet. Vestibulum venenatis volutpat dui. Aliquam dictum metus eget est sodales malesuada. Nunc pharetra iaculis suscipit. Mauris sed lectus nec nunc laoreet molestie et ac ex. Duis a aliquam sapien. Nullam fermentum diam arcu, nec lacinia metus pulvinar at. Nunc eget tempor ex. Nunc vehicula neque ut vulputate feugiat. Aenean euismod posuere nunc, a aliquet nunc laoreet nec. Phasellus faucibus mi et bibendum pretium.",
                    afbeeldingPath = "/uploads/379465.png"

                };

                return View(dossierAntwoord);
            }
        }

        public ActionResult DossierModelThree(int id)
        {
            DossierAntwoord dossierAntwoord = new DossierAntwoord();
            if (id != null)
            {
                dossierAntwoord = (DossierAntwoord)antwManager.readAntwoord(id);
                return View(dossierAntwoord);
            }
            else
            {

                dossierAntwoord = new DossierAntwoord()
                {

                    titel = "Geef titel",
                    subtitel = "Geef subtitel",
                    inhoud = "Aliquam condimentum magna ac ultricies posuere. Cras viverra velit lectus,vel pretium nulla posuere sit amet. Vestibulum venenatis volutpat dui. Aliquam dictum metus eget est sodales malesuada. Nunc pharetra iaculis suscipit. Mauris sed lectus nec nunc laoreet molestie et ac ex. Duis a aliquam sapien. Nullam fermentum diam arcu, nec lacinia metus pulvinar at. Nunc eget tempor ex. Nunc vehicula neque ut vulputate feugiat. Aenean euismod posuere nunc, a aliquet nunc laoreet nec. Phasellus faucibus mi et bibendum pretium. Morbi magna lorem, eleifend at convallis quis, pretium id turpis. In suscipit, magna ac laoreet pellentesque, augue risus cursus arcu, eget ornare est libero vel leo. Etiam hendrerit hendrerit arcu, posuere semper sapien facilisis a.",
                    textvak2 = "Aliquam condimentum magna ac ultricies posuere. Cras viverra velit lectus,vel pretium nulla posuere sit amet. Vestibulum venenatis volutpat dui. Aliquam dictum metus eget est sodales malesuada. Nunc pharetra iaculis suscipit. Mauris sed lectus nec nunc laoreet molestie et ac ex. Duis a aliquam sapien. Nullam fermentum diam arcu, nec lacinia metus pulvinar at. Nunc eget tempor ex. Nunc vehicula neque ut vulputate feugiat. Aenean euismod posuere nunc, a aliquet nunc laoreet nec. Phasellus faucibus mi et bibendum pretium.",
                    textvak3 = "Aliquam condimentum magna ac ultricies posuere. Cras viverra velit lectus,vel pretium nulla posuere sit amet. Vestibulum venenatis volutpat dui. Aliquam dictum metus eget est sodales malesuada. Nunc pharetra iaculis suscipit. Mauris sed lectus nec nunc laoreet molestie et ac ex. Duis a aliquam sapien. Nullam fermentum diam arcu, nec lacinia metus pulvinar at. Nunc eget tempor ex. Nunc vehicula neque ut vulputate feugiat. Aenean euismod posuere nunc, a aliquet nunc laoreet nec. Phasellus faucibus mi et bibendum pretium.",
                    afbeeldingPath = "/uploads/379465.png"

                };

                return View(dossierAntwoord);
            }
        }

        public ActionResult DossierModelFive(int id)
        {
            DossierAntwoord dossierAntwoord = new DossierAntwoord();
            if (id != null)
            {
                dossierAntwoord = (DossierAntwoord)antwManager.readAntwoord(id);
                return View(dossierAntwoord);
            }
            else
            {

                dossierAntwoord = new DossierAntwoord()
                {

                    titel = "Geef titel",
                    subtitel = "Geef subtitel",
                    inhoud = "Aliquam condimentum magna ac ultricies posuere. Cras viverra velit lectus,vel pretium nulla posuere sit amet. Vestibulum venenatis volutpat dui. Aliquam dictum metus eget est sodales malesuada. Nunc pharetra iaculis suscipit. Mauris sed lectus nec nunc laoreet molestie et ac ex. Duis a aliquam sapien. Nullam fermentum diam arcu, nec lacinia metus pulvinar at. Nunc eget tempor ex. Nunc vehicula neque ut vulputate feugiat. Aenean euismod posuere nunc, a aliquet nunc laoreet nec. Phasellus faucibus mi et bibendum pretium. Morbi magna lorem, eleifend at convallis quis, pretium id turpis. In suscipit, magna ac laoreet pellentesque, augue risus cursus arcu, eget ornare est libero vel leo. Etiam hendrerit hendrerit arcu, posuere semper sapien facilisis a.",
                    textvak2 = "Aliquam condimentum magna ac ultricies posuere. Cras viverra velit lectus,vel pretium nulla posuere sit amet. Vestibulum venenatis volutpat dui. Aliquam dictum metus eget est sodales malesuada. Nunc pharetra iaculis suscipit. Mauris sed lectus nec nunc laoreet molestie et ac ex. Duis a aliquam sapien. Nullam fermentum diam arcu, nec lacinia metus pulvinar at. Nunc eget tempor ex. Nunc vehicula neque ut vulputate feugiat. Aenean euismod posuere nunc, a aliquet nunc laoreet nec. Phasellus faucibus mi et bibendum pretium.",
                    textvak3 = "Aliquam condimentum magna ac ultricies posuere. Cras viverra velit lectus,vel pretium nulla posuere sit amet. Vestibulum venenatis volutpat dui. Aliquam dictum metus eget est sodales malesuada. Nunc pharetra iaculis suscipit. Mauris sed lectus nec nunc laoreet molestie et ac ex. Duis a aliquam sapien. Nullam fermentum diam arcu, nec lacinia metus pulvinar at. Nunc eget tempor ex. Nunc vehicula neque ut vulputate feugiat. Aenean euismod posuere nunc, a aliquet nunc laoreet nec. Phasellus faucibus mi et bibendum pretium.",
                    afbeeldingPath = "/uploads/379465.png"

                };

                return View(dossierAntwoord);
            }
        }

        public ActionResult DossierModelSix()
        {
            return View();
        }

        public ActionResult homePartialAntwoorden(string searchString, string currentFilter, string sortOrder, int? page)
        {

            ViewBag.CurrentSort = sortOrder;
            ViewBag.LikesSortParm = sortOrder == "Likes" ? "" : "Likes";
            ViewBag.NPopSortParm = sortOrder == "NPop" ? "" : "NPop";
            ViewBag.AZSortParm = sortOrder == "AZ" ? "" : "AZ";
            ViewBag.ZASortParm = sortOrder == "ZA" ? "" : "ZA";

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
            switch (sortOrder)
            {
                case "AZ":
                    antwoorden = antwManager.sortAntwoordAZ(antwoorden);
                 
                    break;
                case "ZA":
                    antwoorden = antwManager.sortAntwoordZA(antwoorden);
                
                    break;
                case "NPop":
                    antwoorden = antwManager.sortAntwoordMinsteLikes(antwoorden);
            
                    break;
                case "Likes":
                    antwoorden = antwManager.sortAntwoordMeesteLikes(antwoorden);
              
                    break;
                default:
                    antwoorden = antwManager.sortAntwoordNieuwOud(antwoorden);
         
                    break;
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
                return View();
            }
        }



        




        //[HttpPost]
        //public ActionResult AdjustableDossierModelTwo(HttpPostedFileBase file)
        //{

        //    if (file.ContentLength > 0)
        //    {
        //        var fileName = Path.GetFileName(file.FileName);
        //        var path = Path.GetFullPath(Server.MapPath("~/uploads/") + fileName);
        //        file.SaveAs(path);
        //    }

        //    return RedirectToAction("AdjustableDossierModelOne");
        //}

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
