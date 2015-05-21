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

        public ActionResult MijnAntwoordenMenu()
        {
            int aantal = antwManager.readAllAntwoorden().Where(antw => antw.gebruikersNaam == User.Identity.GetUserName() & antw.statusOnline==true).Count();
            ViewBag.Aantal = "Mijn antwoorden(" + aantal + ")";
            return PartialView();

        }

     

        public ActionResult MijnAntwoorden()
        {
            return View();
        }
        public ActionResult MijnDossiers()
        {
            return View();
        }
        public ActionResult Manage()
        {

            return View();
        }

    
        public ActionResult _Wijzig(int id)
        {
            AgendaAntwoord agendaAntwoord = antwManager.readAgendaAntwoord(id);

            return View(agendaAntwoord);
        }

        [HttpPost]
        public ActionResult _Wijzig(AgendaAntwoord agendaAntwoord, string type)
        {
            try
            {
                AgendaAntwoord agendaAntwoordX = antwManager.readAgendaAntwoord(agendaAntwoord.ID);
                agendaAntwoordX.titel = agendaAntwoord.titel;
                agendaAntwoordX.subtitel = agendaAntwoord.subtitel;
                antwManager.updateAgendaAntwoord(agendaAntwoordX);

                if (type == "ActieveAgendaModule")
                {
                    return RedirectToAction("Agenda", "Module");

                }
                else if (type == "MijnAntwoorden")
                {
                    return RedirectToAction("MijnAntwoorden", "Antwoord");
                }
                else
                {
                    return View();
                }



            }
            catch
            {
                return View();
            }



        }

        public ActionResult Edit(int id)
        {
            DossierAntwoord dossierAntwoord = antwManager.readDossierAntwoord(id);

            return View(dossierAntwoord);

        }

        [HttpPost]
        public ActionResult Edit(DossierAntwoord dossierAntwoord, int? moduleId, string type)
        {
            try
            {

                antwManager.updateDossierAntwoord(dossierAntwoord);

                if (type == "AdminDossier")
                {
                    return RedirectToAction("DossAntwoorden", "Antwoord", new { id = moduleId });

                }
                else if (type == "MijnDossierModules")
                {
                    return RedirectToAction("DossAntwoorden", "Antwoord", new { id = moduleId });

                }
                else
                {
                    return View();
                }



            }
            catch
            {
                return View();
            }

        }


        public ActionResult _Edit(int id)
        {
            AgendaAntwoord agendaAntwoord = antwManager.readAgendaAntwoord(id);

            return View(agendaAntwoord);

        }

        [HttpPost]
        public ActionResult _Edit(AgendaAntwoord agendaAntwoord, int? moduleId, string type)
        {
            try
            {

                antwManager.updateAgendaAntwoord(agendaAntwoord);

                if (type == "AdminAgenda")
                {
                    return RedirectToAction("AgdAntwoorden", "Antwoord", new { id = moduleId });

                }
                else if (type == "MijnAgendaModules")
                {
                    return RedirectToAction("AgdAntwoorden", "Antwoord", new { id = moduleId });

                }
                else
                {
                    return View();
                }



            }
            catch
            {
                return View();
            }

        }

        public ActionResult Wijzig(int id)
        {
            DossierAntwoord dossierAntwoord = antwManager.readDossierAntwoord(id);

            return View(dossierAntwoord);
        }

        [HttpPost]
        public ActionResult Wijzig(DossierAntwoord dossierAntwoord, string type)
        {
            try
            {
                DossierAntwoord dossierAntwoordX = antwManager.readDossierAntwoord(dossierAntwoord.ID);
                dossierAntwoordX.textvak3 = dossierAntwoord.textvak3;
                dossierAntwoordX.textvak2 = dossierAntwoord.textvak2;
                dossierAntwoordX.titel = dossierAntwoord.titel;
                dossierAntwoordX.subtitel = dossierAntwoord.subtitel;
                dossierAntwoordX.googleMapsAdress = dossierAntwoord.googleMapsAdress;
                antwManager.updateDossierAntwoord(dossierAntwoordX);

               if (type == "ActieveDossierModule")
                {
                    return RedirectToAction("Dossier", "Module");

                }
                else if (type == "MijnDossiers")
                {
                    return RedirectToAction("MijnDossiers", "Antwoord");
                }
                else
                {
                    return View();
                }
                
                

            }catch {
                return View();
            }
         

         
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

        public ActionResult ModuleBeslissing(int id)
        {
            int identity = id;
            if (antwManager.readAntwoord(id) is DossierAntwoord){
                return RedirectToAction("Dossier", new { id = identity});
            }
            else
            {
                return RedirectToAction("Agenda", new { id = identity });
            }
            
        }

        public ActionResult BlokkeerAgendaAntwoord(int id)
        {
            AgendaAntwoord agendaAntwoord = (AgendaAntwoord)antwManager.readAntwoord(id);
            return View(agendaAntwoord);

        }
        [HttpPost]
        public ActionResult BlokkeerAgendaAntwoord(int id, int moduleId)
        {
            try
            {
                AgendaAntwoord agendaAntwoord = (AgendaAntwoord)antwManager.readAntwoord(id);

                if (agendaAntwoord.statusOnline == true)
                {
                    agendaAntwoord.statusOnline = false;
                }else
                {
                    agendaAntwoord.statusOnline = true;
                }
             
                antwManager.updateAgendaAntwoord(agendaAntwoord);
                return RedirectToAction("AgdAntwoorden", "Antwoord", new { id = moduleId});
            }
            catch
            {
                return RedirectToAction("Error");
            }

        }

        public ActionResult BlokkeerDossierAntwoord(int id)
        {
            DossierAntwoord dossierAntwoord = (DossierAntwoord)antwManager.readAntwoord(id);
            return View(dossierAntwoord);
       
        }

        [HttpPost]
        public ActionResult BlokkeerDossierAntwoord(int id, int moduleId)
        {
            try
            {
                DossierAntwoord dossierAntwoord = (DossierAntwoord)antwManager.readAntwoord(id);

                if (dossierAntwoord.statusOnline == true)
                {
                    dossierAntwoord.statusOnline = false;
                }
                else
                {
                    dossierAntwoord.statusOnline = true;
                }

                antwManager.updateDossierAntwoord(dossierAntwoord);
                return RedirectToAction("DossAntwoorden", "Antwoord", new { id = moduleId });
            }
            catch
            {
                return RedirectToAction("Error");
            }
            
        }
        public ActionResult AdjustableDossierModelOne(DossierAntwoord dossierAntwoord)
        {


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
        public ActionResult AdjustableDossierModelOne(DossierAntwoord dossAntwoord, HttpPostedFileBase file)
        {

            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction("AdjustableDossierModelOne",
                    new
                    {
                        inhoud = dossAntwoord.inhoud,
                        textvak2 = dossAntwoord.textvak2,
                        textvak3 = dossAntwoord.textvak3,
                        googleMapsAdress = dossAntwoord.googleMapsAdress,
                        afbeeldingPath = dossAntwoord.afbeeldingPath,
                        foregroundColor = dossAntwoord.foregroundColor,
                        backgroundColor = dossAntwoord.backgroundColor
                    
                    
                    
                    
                    });
            }
            else
            {
                var fileName = "";
                if (file != null && file.ContentLength > 0)
                {
                    fileName = Path.GetFileName(file.FileName);
                    var path = Path.GetFullPath(Server.MapPath("~/uploads/") + fileName);
                    file.SaveAs(path);
                  
                }
                

                byte[] imgByte;
                using(MemoryStream ms = new MemoryStream()){

                    file.InputStream.CopyTo(ms);
                      imgByte = ms.GetBuffer();
                }


                if (dossAntwoord.googleMapsAdress == null)
                {

                    dossAntwoord.googleMapsAdress = "Leuven";
                }
                if (dossAntwoord.backgroundColor == null)
                {
                    dossAntwoord.backgroundColor = "White";
                }

                if (dossAntwoord.foregroundColor == null)
                {
                    dossAntwoord.backgroundColor = "Black";
                }
                if (file == null)
                {
                    
                }

                DossierAntwoord dossierAntwoordX = new DossierAntwoord()
                {
                    gebruikersNaam = User.Identity.GetUserName(),
                    comments = new List<Comment>(),
                    vasteTags = new List<VasteTag>(),
                    persoonlijkeTags = new List<PersoonlijkeTag>(),
                    datum = DateTime.Now,
                    aantalFlags = 0,
                    stemmen = new List<Stem>(),
                    percentageVolledigheid = 50,
                    statusOnline = false,
                    layoutOption = 1,
                    subtitel = dossAntwoord.subtitel,
                    titel = dossAntwoord.titel,
                    inhoud = dossAntwoord.inhoud,
                    textvak2 = dossAntwoord.textvak2,
                    textvak3 = dossAntwoord.textvak3,
                    googleMapsAdress = dossAntwoord.googleMapsAdress,
                    afbeeldingPath = "/uploads/" + fileName,
                    foregroundColor = dossAntwoord.foregroundColor,
                    backgroundColor = dossAntwoord.backgroundColor,
                    evenementen = new List<Evenement>(),
                     afbeeldingByte = imgByte
                   

                };


                ////Voeg toe en leg relatie tussen de dossier antwoord en de actieve dossier module

                DossierModule actieveDossierModule = dossManager.readActieveDossierModule();
                dossierAntwoordX.module = actieveDossierModule;
                DossierAntwoord createddos = antwManager.createDossierAntwoord(dossierAntwoordX);
                actieveDossierModule.dossierAntwoorden.Add(createddos);
                dossManager.updateDossierModule(actieveDossierModule);




                return RedirectToAction("DossierModelOne", new { id = createddos.ID });

            
            }
 
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
        public ActionResult AdjustableDossierModelTwo(DossierAntwoord dossAntwoord, HttpPostedFileBase file)
        {
            
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction("AdjustableDossierModelTwo",
                    new
                    {
                        inhoud = dossAntwoord.inhoud,

                        textvak2 = dossAntwoord.textvak2,
                        textvak3 = dossAntwoord.textvak3,
                        googleMapsAdress = dossAntwoord.googleMapsAdress,
                        afbeeldingPath = dossAntwoord.afbeeldingPath,
                        foregroundColor = dossAntwoord.foregroundColor,
                        backgroundColor = dossAntwoord.backgroundColor




                    });
            }
            else
            {
                var fileName = "";
                if (file != null && file.ContentLength > 0)
                {
                    fileName = Path.GetFileName(file.FileName);
                    var path = Path.GetFullPath(Server.MapPath("~/uploads/") + fileName);
                    file.SaveAs(path);

                }

                byte[] imgByte;
                using (MemoryStream ms = new MemoryStream())
                {

                    file.InputStream.CopyTo(ms);
                    imgByte = ms.GetBuffer();
                }

                if (dossAntwoord.googleMapsAdress == null)
                {

                    dossAntwoord.googleMapsAdress = "Leuven";
                }

                if (dossAntwoord.backgroundColor == null)
                {
                    dossAntwoord.backgroundColor = "White";
                }

                if (dossAntwoord.foregroundColor == null)
                {
                    dossAntwoord.backgroundColor = "Black";
                }


                DossierAntwoord dossierAntwoordX = new DossierAntwoord()
                {
                    gebruikersNaam = User.Identity.GetUserName(),
                    comments = new List<Comment>(),
                    vasteTags = new List<VasteTag>(),
                    persoonlijkeTags = new List<PersoonlijkeTag>(),
                    datum = DateTime.Now,
                    aantalFlags = 0,
                    stemmen = new List<Stem>(),
                    percentageVolledigheid = 50,
                    statusOnline = false,
                    layoutOption = 2,
                    subtitel = dossAntwoord.subtitel,
                    titel = dossAntwoord.titel,
                    inhoud = dossAntwoord.inhoud,
                    textvak2 = dossAntwoord.textvak2,
                    textvak3 = dossAntwoord.textvak3,
                    googleMapsAdress = dossAntwoord.googleMapsAdress,
                    afbeeldingPath = "/uploads/" + fileName,
                    foregroundColor = dossAntwoord.foregroundColor,
                    backgroundColor = dossAntwoord.backgroundColor,
                    evenementen = new List<Evenement>(),
                    afbeeldingByte=imgByte
                };



                ////Voeg toe en leg relatie tussen de dossier antwoord en de actieve dossier module

                DossierModule actieveDossierModule = dossManager.readActieveDossierModule();
                dossierAntwoordX.module = actieveDossierModule;
                DossierAntwoord createddos = antwManager.createDossierAntwoord(dossierAntwoordX);
                actieveDossierModule.dossierAntwoorden.Add(createddos);
                dossManager.updateDossierModule(actieveDossierModule);




                return RedirectToAction("DossierModelTwo", new { id = createddos.ID });
            }
        }

        public ActionResult AdjustableDossierModelThree(DossierAntwoord dossierAntwoord)
        {

     
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
        public ActionResult AdjustableDossierModelThree(DossierAntwoord dossAntwoord, HttpPostedFileBase file)
        {
           
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction("AdjustableDossierModelThree",
                    new
                    {
                        inhoud = dossAntwoord.inhoud,

                        textvak2 = dossAntwoord.textvak2,
                        textvak3 = dossAntwoord.textvak3,
                        googleMapsAdress = dossAntwoord.googleMapsAdress,
                        afbeeldingPath = dossAntwoord.afbeeldingPath,
                        foregroundColor = dossAntwoord.foregroundColor,
                        backgroundColor = dossAntwoord.backgroundColor




                    });
            }
            else
            {
                var fileName = "";
                if (file != null && file.ContentLength > 0)
                {
                    fileName = Path.GetFileName(file.FileName);
                    var path = Path.GetFullPath(Server.MapPath("~/uploads/") + fileName);
                    file.SaveAs(path);

                }


                byte[] imgByte;
                using (MemoryStream ms = new MemoryStream())
                {

                    file.InputStream.CopyTo(ms);
                    imgByte = ms.GetBuffer();
                }

                if (dossAntwoord.googleMapsAdress == null)
                {

                    dossAntwoord.googleMapsAdress = "Leuven";
                }
                if (dossAntwoord.backgroundColor == null)
                {
                    dossAntwoord.backgroundColor = "White";
                }

                if (dossAntwoord.foregroundColor == null)
                {
                    dossAntwoord.backgroundColor = "Black";
                }

                DossierAntwoord dossierAntwoordX = new DossierAntwoord()
                {
                    gebruikersNaam = User.Identity.GetUserName(),
                    comments = new List<Comment>(),
                    vasteTags = new List<VasteTag>(),
                    persoonlijkeTags = new List<PersoonlijkeTag>(),
                    datum = DateTime.Now,
                    aantalFlags = 0,
                    stemmen = new List<Stem>(),
                    percentageVolledigheid = 50,
                    statusOnline = false,
                    layoutOption = 3,
                    subtitel = dossAntwoord.subtitel,
                    titel = dossAntwoord.titel,
                    inhoud = dossAntwoord.inhoud,
                    textvak2 = dossAntwoord.textvak2,
                    textvak3 = dossAntwoord.textvak3,
                    googleMapsAdress = dossAntwoord.googleMapsAdress,
                    afbeeldingPath = "/uploads/" + fileName,
                    foregroundColor = dossAntwoord.foregroundColor,
                    backgroundColor = dossAntwoord.backgroundColor,
                    evenementen = new List<Evenement>(),
                    afbeeldingByte = imgByte

                };



                ////Voeg toe en leg relatie tussen de dossier antwoord en de actieve dossier module

                DossierModule actieveDossierModule = dossManager.readActieveDossierModule();
                dossierAntwoordX.module = actieveDossierModule;
                DossierAntwoord createddos = antwManager.createDossierAntwoord(dossierAntwoordX);
                actieveDossierModule.dossierAntwoorden.Add(createddos);
                dossManager.updateDossierModule(actieveDossierModule);




                return RedirectToAction("DossierModelThree", new { id = createddos.ID });
            }
        }

        public ActionResult AdjustableDossierModelFive(DossierAntwoord dossierAntwoord)
        {

        
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
        public ActionResult AdjustableDossierModelFive(DossierAntwoord dossAntwoord, HttpPostedFileBase file)
        {

            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction("AdjustableDossierModelFive",
                    new
                    {
                        inhoud = dossAntwoord.inhoud,

                        textvak2 = dossAntwoord.textvak2,
                        textvak3 = dossAntwoord.textvak3,
                        googleMapsAdress = dossAntwoord.googleMapsAdress,
                        afbeeldingPath = dossAntwoord.afbeeldingPath,
                        foregroundColor = dossAntwoord.foregroundColor,
                        backgroundColor = dossAntwoord.backgroundColor




                    });
            }
            else
            {
                var fileName = "";
                if (file != null && file.ContentLength > 0)
                {
                    fileName = Path.GetFileName(file.FileName);
                    var path = Path.GetFullPath(Server.MapPath("~/uploads/") + fileName);
                    file.SaveAs(path);

                }

                byte[] imgByte;
                using (MemoryStream ms = new MemoryStream())
                {

                    file.InputStream.CopyTo(ms);
                    imgByte = ms.GetBuffer();
                }


                if (dossAntwoord.googleMapsAdress == null)
                {

                    dossAntwoord.googleMapsAdress = "Leuven";
                }

                if (dossAntwoord.backgroundColor == null)
                {
                    dossAntwoord.backgroundColor = "White";
                }

                if (dossAntwoord.foregroundColor == null)
                {
                    dossAntwoord.backgroundColor = "Black";
                }

                DossierAntwoord dossierAntwoordX = new DossierAntwoord()
                {
                    gebruikersNaam = User.Identity.GetUserName(),
                    comments = new List<Comment>(),
                    vasteTags = new List<VasteTag>(),
                    persoonlijkeTags = new List<PersoonlijkeTag>(),
                    datum = DateTime.Now,
                    aantalFlags = 0,
                    stemmen = new List<Stem>(),
                    percentageVolledigheid = 50,
                    statusOnline = false,
                    layoutOption = 5,
                    subtitel = dossAntwoord.subtitel,
                    titel = dossAntwoord.titel,
                    inhoud = dossAntwoord.inhoud,
                    textvak2 = dossAntwoord.textvak2,
                    textvak3 = dossAntwoord.textvak3,
                    googleMapsAdress = dossAntwoord.googleMapsAdress,
                    afbeeldingPath = "/uploads/" + fileName,
                    foregroundColor = dossAntwoord.foregroundColor,
                    backgroundColor = dossAntwoord.backgroundColor,
                    evenementen = new List<Evenement>(),
                    afbeeldingByte = imgByte

                };



                ////Voeg toe en leg relatie tussen de dossier antwoord en de actieve dossier module

                DossierModule actieveDossierModule = dossManager.readActieveDossierModule();
                dossierAntwoordX.module = actieveDossierModule;
                DossierAntwoord createddos = antwManager.createDossierAntwoord(dossierAntwoordX);
                actieveDossierModule.dossierAntwoorden.Add(createddos);
                dossManager.updateDossierModule(actieveDossierModule);




                return RedirectToAction("DossierModelFive", new { id = createddos.ID });
            }
        }

        public ActionResult AdjustableDossierModelSix(DossierAntwoord dossierAntwoord)
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
        public ActionResult AdjustableDossierModelSix(DossierAntwoord dossAntwoord, HttpPostedFileBase file)
        {

            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction("AdjustableDossierModelSix",
                    new
                    {
                        inhoud = dossAntwoord.inhoud,

                        textvak2 = dossAntwoord.textvak2,
                        textvak3 = dossAntwoord.textvak3,
                        googleMapsAdress = dossAntwoord.googleMapsAdress,
                        afbeeldingPath = dossAntwoord.afbeeldingPath,
                        foregroundColor = dossAntwoord.foregroundColor,
                        backgroundColor = dossAntwoord.backgroundColor




                    });
            }
            else
            {
                var fileName = "";
                if (file != null && file.ContentLength > 0)
                {
                    fileName = Path.GetFileName(file.FileName);
                    var path = Path.GetFullPath(Server.MapPath("~/uploads/") + fileName);
                    file.SaveAs(path);

                }


                byte[] imgByte;
                using (MemoryStream ms = new MemoryStream())
                {

                    file.InputStream.CopyTo(ms);
                    imgByte = ms.GetBuffer();
                }

                if (dossAntwoord.googleMapsAdress == null)
                {

                    dossAntwoord.googleMapsAdress = "Leuven";
                }
                if (dossAntwoord.backgroundColor == null)
                {
                    dossAntwoord.backgroundColor = "White";
                }

                if (dossAntwoord.foregroundColor == null)
                {
                    dossAntwoord.backgroundColor = "Black";
                }


                DossierAntwoord dossierAntwoordX = new DossierAntwoord()
                {
                    gebruikersNaam = User.Identity.GetUserName(),
                    comments = new List<Comment>(),
                    vasteTags = new List<VasteTag>(),
                    persoonlijkeTags = new List<PersoonlijkeTag>(),
                    datum = DateTime.Now,
                    aantalFlags = 0,
                    stemmen = new List<Stem>(),
                    percentageVolledigheid = 50,
                    statusOnline = false,
                    layoutOption = 6,
                    subtitel = dossAntwoord.subtitel,
                    titel = dossAntwoord.titel,
                    inhoud = dossAntwoord.inhoud,
                    textvak2 = dossAntwoord.textvak2,
                    textvak3 = dossAntwoord.textvak3,
                    googleMapsAdress = dossAntwoord.googleMapsAdress,
                    afbeeldingPath = "/uploads/" + fileName,
                    foregroundColor = dossAntwoord.foregroundColor,
                    backgroundColor = dossAntwoord.backgroundColor,
                    evenementen = new List<Evenement>(),
                    afbeeldingByte = imgByte

                };



                ////Voeg toe en leg relatie tussen de dossier antwoord en de actieve dossier module

                DossierModule actieveDossierModule = dossManager.readActieveDossierModule();
                dossierAntwoordX.module = actieveDossierModule;
                DossierAntwoord createddos = antwManager.createDossierAntwoord(dossierAntwoordX);
                actieveDossierModule.dossierAntwoorden.Add(createddos);
                dossManager.updateDossierModule(actieveDossierModule);




                return RedirectToAction("DossierModelSix", new { id = createddos.ID });


              }
        }



        public ActionResult DossierModelOne(int id)
        {
            DossierAntwoord dossierAntwoord = new DossierAntwoord();
            if (id != null)
            {
                dossierAntwoord = (DossierAntwoord)antwManager.readDossierAntwoord(id);
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
                    afbeeldingPath = "/uploads/379465.png",
                    foregroundColor = "black",
                    backgroundColor = "white"

                };

                return View(dossierAntwoord);
            }
        }

        [HttpPost]
        public ActionResult DossierModelOne(int id, FormCollection collection)
        {
            DossierAntwoord dossierAntwoord = (DossierAntwoord)antwManager.readAntwoord(id);
            dossierAntwoord.statusOnline = true;
            
            antwManager.updateDossierAntwoord(dossierAntwoord);
            return RedirectToAction("DossierModelOne", new { id = dossierAntwoord.ID });

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

        public ActionResult DossierModelSix(int id)
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

            IEnumerable<Antwoord> antwoorden = antwManager.readAllAntwoorden().Where(antw=>antw.statusOnline==true);
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

        public ActionResult _partialMijnAgendaAntwoorden(string searchString, string currentFilter, string sortOrder, int? page)
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

            int pageSize = 4;
            int pageNumber = (page ?? 1);

            List<AgendaModule> agendamodules = dossManager.readAllAgendaModules();

            IEnumerable<AgendaAntwoord> agendaAntwoorden = antwManager.readAllAgendaAntwoorden().Where(antw => antw.gebruikersNaam == User.Identity.GetUserName() && antw.statusOnline==true);


            if (agendaAntwoorden.ToList().Count != 0)
            {
                ViewBag.winnaar = agendaAntwoorden.Max(antw => antw.stemmen.Count);
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                agendaAntwoorden = agendaAntwoorden.Where(antw => antw.inhoud.Contains(searchString)
                                       || antw.titel.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "AZ":
                    agendaAntwoorden = antwManager.sortAgendaAntwoordAZ(agendaAntwoorden);

                    break;
                case "ZA":
                    agendaAntwoorden = antwManager.sortAgendaAntwoordZA(agendaAntwoorden);

                    break;
                case "NPop":
                    agendaAntwoorden = antwManager.sortAgendaAntwoordMinsteLikes(agendaAntwoorden);

                    break;
                case "Likes":
                    agendaAntwoorden = antwManager.sortAgendaAntwoordMeesteLikes(agendaAntwoorden);

                    break;
                default:
                    agendaAntwoorden = antwManager.sortAgendaAntwoordNieuwOud(agendaAntwoorden);

                    break;
            }


            ViewBag.Aantal = agendaAntwoorden.Count();

            return PartialView(agendaAntwoorden.ToPagedList(pageNumber, pageSize));

        }

        public ActionResult _partialMijnDossierAntwoorden(string searchString, string currentFilter, string sortOrder, int? page)
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

            int pageSize = 4;
            int pageNumber = (page ?? 1);

            List<DossierModule> dossiermodules = dossManager.readAllDossierModules();

            IEnumerable<DossierAntwoord> dossierAntwoorden = antwManager.readAllDossierAntwoorden().Where(antw => antw.gebruikersNaam == User.Identity.GetUserName() && antw.statusOnline == true);

           
            if (dossierAntwoorden.ToList().Count != 0)
            {
                ViewBag.winnaar = dossierAntwoorden.Max(antw => antw.stemmen.Count);
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                dossierAntwoorden = dossierAntwoorden.Where(antw => antw.inhoud.Contains(searchString)
                                       || antw.titel.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "AZ":
                    dossierAntwoorden = antwManager.sortDossierAntwoordTitelAZ(dossierAntwoorden);

                    break;
                case "ZA":
                    dossierAntwoorden = antwManager.sortDossierAntwoordTitelZA(dossierAntwoorden);

                    break;
                case "NPop":
                    dossierAntwoorden = antwManager.sortDossierAntwoordMinsteLikes(dossierAntwoorden);

                    break;
                case "Likes":
                    dossierAntwoorden = antwManager.sortDossierAntwoordMeesteLikes(dossierAntwoorden);

                    break;
                default:
                    dossierAntwoorden = antwManager.sortDossierAntwoordNieuwOud(dossierAntwoorden);

                    break;
            }


            ViewBag.Aantal = dossierAntwoorden.Count();

            return PartialView(dossierAntwoorden.ToPagedList(pageNumber, pageSize));

        }
        public ActionResult _partialAntwoordLijst(string sortOrder, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.Top25SortParm = sortOrder == "top25" ? "" : "top25";
            ViewBag.Top5SortParm = sortOrder == "top5" ? "" : "top5";

            ViewBag.RecentSortParm = sortOrder == "recent" ? "" : "recent";

         
            
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            DossierModule dossiermodule = dossManager.readActieveDossierModule();
            List<DossierAntwoord> dossierAntwoorden = new List<DossierAntwoord>();
            if (dossiermodule.naam != null)
            {
                dossierAntwoorden = antwManager.getAllDossierAntwoordenPerModule(dossiermodule.ID).Where(antw => antw.statusOnline == true).ToList();
                ViewBag.winnaar = dossierAntwoorden.Max(antw => antw.stemmen.Count);
            }

            List<DossierAntwoord> dossierAntwoorden2 = new List<DossierAntwoord>();


            switch (sortOrder)
            {
                case "top25":
                    dossierAntwoorden = antwManager.sortDossierAntwoordMeesteLikes(dossierAntwoorden);


                    if (dossierAntwoorden.Count < 25)
                    {
                        for (int i = 0; i < dossierAntwoorden.Count; i++)
                        {
                            dossierAntwoorden2.Add(dossierAntwoorden[i]);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < 25; i++)
                        {
                            dossierAntwoorden2.Add(dossierAntwoorden[i]);
                        }
                    }
                    break;
                case "top5":
                    dossierAntwoorden = antwManager.sortDossierAntwoordMeesteLikes(dossierAntwoorden);
                 
                    if (dossierAntwoorden.Count < 5)
                    {
                        for (int i = 0; i < dossierAntwoorden.Count; i++)
                        {
                            dossierAntwoorden2.Add(dossierAntwoorden[i]);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            dossierAntwoorden2.Add(dossierAntwoorden[i]);
                        }
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
            List<AgendaAntwoord> agendaAntwoorden = new List<AgendaAntwoord>();
            if (agendaModule.naam != null)
            {
                agendaAntwoorden = antwManager.getAllAgendaAntwoordenPerModule(agendaModule.ID).Where(antw => antw.statusOnline == true).ToList();
                ViewBag.winnaar = agendaAntwoorden.Max(antw => antw.stemmen.Count);
            }
         
            List<AgendaAntwoord> agendaAntwoorden2 = new List<AgendaAntwoord>();

           



            switch (sortOrder)
            {
                case "top25":
                    agendaAntwoorden = antwManager.sortAgendaAntwoordMeesteLikes(agendaAntwoorden);
                    if (agendaAntwoorden.Count < 25)
                    {
                        for (int i = 0; i < agendaAntwoorden.Count; i++)
                        {
                            agendaAntwoorden2.Add(agendaAntwoorden[i]);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < 25; i++)
                        {
                            agendaAntwoorden2.Add(agendaAntwoorden[i]);
                        }
                    }
                  
                        break;
                case "top5":
                        agendaAntwoorden = antwManager.sortAgendaAntwoordMeesteLikes(agendaAntwoorden);
                        if (agendaAntwoorden.Count < 5)
                        {
                            for (int i = 0; i < agendaAntwoorden.Count; i++)
                            {
                                agendaAntwoorden2.Add(agendaAntwoorden[i]);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < 5; i++)
                            {
                                agendaAntwoorden2.Add(agendaAntwoorden[i]);
                            }
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
            
            IEnumerable<DossierAntwoord> dossierAntwoorden = antwManager.getAllDossierAntwoordenPerModule(id).Where(antw=>antw.statusOnline==true);
            ViewBag.Aantal = dossierAntwoorden.Count();
            return View(dossierAntwoorden.ToPagedList(pageNumber, pageSize));
            

        }
        //Antwoord/Lijst2
        public ActionResult Lijst2(int id, int? page)
        {
            //Manager moet nog gemaakt worden

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            IEnumerable<DossierAntwoord> dossierAntwoorden = antwManager.getAllDossierAntwoordenPerModule(id).Where(antw => antw.statusOnline == false);
            ViewBag.Aantal = dossierAntwoorden.Count();
            return View(dossierAntwoorden.ToPagedList(pageNumber, pageSize));


        }


        public ActionResult AgdAntwoorden(int id)
        {
          AgendaModule agendaModule = (AgendaModule)dossManager.readModule(id);
          return View(agendaModule);
        }


        public ActionResult DossAntwoorden(int id)
        {
            DossierModule dossierModule = (DossierModule)dossManager.readModule(id);
            return View(dossierModule);
        }

        //Antwoord/_Lijst
        public ActionResult _Lijst(int id, int? page)
        {
            //Manager moet nog gemaakt worden

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            IEnumerable<AgendaAntwoord> agendaAntwoorden = antwManager.getAllAgendaAntwoordenPerModule(id).Where(antw => antw.statusOnline == true);
            ViewBag.Aantal = agendaAntwoorden.Count();
            return View(agendaAntwoorden.ToPagedList(pageNumber, pageSize));


        }
        //Antwoord/_Lijst2
        public ActionResult _Lijst2(int id, int? page)
        {
            //Manager moet nog gemaakt worden

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            IEnumerable<AgendaAntwoord> agendaAntwoorden = antwManager.getAllAgendaAntwoordenPerModule(id).Where(antw => antw.statusOnline == false);
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
        // GET: Antwoord/Verwijder/5
        public ActionResult Verwijder(int id)
        {
            Antwoord antwoord = antwManager.readAntwoord(id);
            return View(antwoord);
        }

        // POST: Antwoord/Delete/5
        [HttpPost]
        public ActionResult Verwijder(int id, int? moduleId, string type)
        {
            try
            {
                antwManager.removeAntwoord(id);

            
                if (type == "AgendaModule")
                {
                    return RedirectToAction("AgdAntwoorden", "Antwoord", new { id = moduleId});

                }else if(type == "DossierModule")
                {
                    return RedirectToAction("DossAntwoorden", "Antwoord", new { id = moduleId });
                }else if(type == "MijnDossiers")
                {
                    return RedirectToAction("MijnDossiers", "Antwoord");
                }
                else if (type == "MijnAntwoorden")
                {
                    return RedirectToAction("MijnAntwoorden", "Antwoord");
                }
                else if (type == "ActieveDossierModule")
                {
                    return RedirectToAction("Dossier", "Module");
                }
                else if (type == "ActieveAgendaModule")
                {
                    return RedirectToAction("Agenda", "Module");
                }
                else
                {
                    return View();
                }
                
            }
            catch
            {
                return RedirectToAction("Error");
            }

        }


        public ActionResult AdjAgendaAntwoord(AgendaAntwoord agendaAntwoord)
        {

          

              if (agendaAntwoord.titel != null)
              {

                 return View(agendaAntwoord);
              }else{

                   agendaAntwoord = new AgendaAntwoord()
                    {

                        titel = "Geef titel",
                        subtitel = "Geef subtitel",
                        inhoud = "Aliquam condimentum magna ac ultricies posuere. Cras viverra velit lectus,vel pretium nulla posuere sit amet. Vestibulum venenatis volutpat dui. Aliquam dictum metus eget est sodales malesuada. Nunc pharetra iaculis suscipit. Mauris sed lectus nec nunc laoreet molestie et ac ex. Duis a aliquam sapien. Nullam fermentum diam arcu, nec lacinia metus pulvinar at. Nunc eget tempor ex. Nunc vehicula neque ut vulputate feugiat. Aenean euismod posuere nunc, a aliquet nunc laoreet nec. Phasellus faucibus mi et bibendum pretium. Morbi magna lorem, eleifend at convallis quis, pretium id turpis. In suscipit, magna ac laoreet pellentesque, augue risus cursus arcu, eget ornare est libero vel leo. Etiam hendrerit hendrerit arcu, posuere semper sapien facilisis a.",

                    };

                   return View(agendaAntwoord);
              }
                  

        }


        [HttpPost]
        public ActionResult AdjAgendaAntwoord(AgendaAntwoord agendaAntwoord, FormCollection formCollection)
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Login","Account");
            }

            if (!ModelState.IsValid)
            {
                return View(agendaAntwoord);
            }
            else
            {
                AgendaAntwoord agendaAntwoordX = new AgendaAntwoord()
                {
                    gebruikersNaam = User.Identity.GetUserName(),
                    datum = DateTime.Now,
                    stemmen = new List<Stem>(),
                    aantalFlags = 0,
                    statusOnline = true,
                    inhoud = agendaAntwoord.inhoud,
                    subtitel = agendaAntwoord.subtitel,
                    titel = agendaAntwoord.titel,
                    evenementen = new List<Evenement>()
                  

                };

                //Voeg toe en leg relatie tussen de agenda antwoord en de actieve agenda module
                AgendaModule actieveAgendaModule = dossManager.readActieveAgendaModule();
                agendaAntwoordX.module = actieveAgendaModule;
                AgendaAntwoord createddos = antwManager.createAgendaAntwoord(agendaAntwoordX);

                actieveAgendaModule.agendaAntwoorden.Add(createddos);

                dossManager.updateAgendaModule(actieveAgendaModule);


                return RedirectToAction("Agenda", new { id = createddos.ID });

              

            }    
        }
    }
}
