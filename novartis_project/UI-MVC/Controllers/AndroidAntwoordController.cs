using JPP.BL;
using JPP.BL.Domain.Antwoorden;

using JPP.BL.Domain.Modules; //azeaeazeazeazeazeaze

using JPP.UI.Web.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.IO;


namespace JPP.UI.Web.MVC.Controllers
{
    public class AndroidAntwoordController : ApiController
    {
        AntwoordManager antwoordManager = new AntwoordManager();
        ModuleManager moduleManager = new ModuleManager();

        [HttpGet]
        [ActionName("test")]
        public IHttpActionResult test()
        {
            Image tmpimg = null;
            HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create("~/uploads/ae0K8gv_460s.jpg");
            HttpWebResponse httpWebReponse = (HttpWebResponse)httpWebRequest.GetResponse();
            Stream stream = httpWebReponse.GetResponseStream();
            tmpimg = Image.FromStream(stream);

            MemoryStream ms = new MemoryStream();
            tmpimg.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);

            byte[] image = new byte[100000];
            image = ms.ToArray();
            return Ok(image);
        }


        #region GET dossier/agenda
        [HttpGet]
        [ActionName("getAgendaAntwoordID")]
        public IHttpActionResult getAgendaAntwoorden(int id)
        {
            List<AgendaAntwoord> agendaAntwoord = antwoordManager.getAllAgendaAntwoordenPerModule(id);
            List<ANDROIDAgendaAntwoord> agendaAntwoorden = new List<ANDROIDAgendaAntwoord>();

            foreach (var agenda in agendaAntwoord)
            {
                ANDROIDAgendaAntwoord agAntwoord = new ANDROIDAgendaAntwoord()
                {
                    ID = agenda.ID,
                    inhoud = agenda.inhoud,
                    extraInfo = agenda.extraInfo,
                    datum = agenda.datum,
                    aantalStemmen = agenda.aantalStemmen,
                    //editable = agenda.editable,
                    gebruikersNaam = agenda.gebruikersNaam,
                    aantalFlags = agenda.aantalFlags,
                    moduleID = agenda.module.ID,
                    //vasteTags = new List<ANDROIDVasteTag>(),
                    // persoonlijkeTags = new List<ANDROIDPersoonlijkeTag>(),
                    titel = agenda.titel,
                    subTitel = agenda.subtitel,
                };
                if (agenda.module.ID == moduleManager.readActieveAgendaModule().ID)
                {
                    agAntwoord.isActieveModule = true;
                }
                else
                {
                    agAntwoord.isActieveModule = false;
                }

                //foreach (var vTag in agenda.vasteTags)
                //{
                //    ANDROIDVasteTag vasteTag = new ANDROIDVasteTag()
                //    {
                //        ID = vTag.ID,
                //        naam = vTag.naam,
                //        beschrijving = vTag.beschrijving
                //    };
                //    agAntwoord.vasteTags.Add(vasteTag);
                //}

                //foreach (var pTag in agenda.persoonlijkeTags)
                //{
                //    ANDROIDPersoonlijkeTag persTag = new ANDROIDPersoonlijkeTag()
                //    {
                //        ID = pTag.ID,
                //        naam = pTag.naam,
                //        beschrijving = pTag.beschrijving
                //    };
                //    agAntwoord.persoonlijkeTags.Add(persTag);
                //}
                agendaAntwoorden.Add(agAntwoord);
            }
            return Ok(agendaAntwoorden);
        }
        [HttpGet]
        [ActionName("getDossierAntwoordID")]
        public IHttpActionResult getDossierAntwoorden(int id)
        {
            List<DossierAntwoord> dossierAntwoord = antwoordManager.getAllDossierAntwoordenPerModule(id);
            List<ANDROIDDossierAntwoord> dossierAntwoorden = new List<ANDROIDDossierAntwoord>();
            foreach (DossierAntwoord dossier in dossierAntwoord)
            {
                ANDROIDDossierAntwoord dosAntwoord = new ANDROIDDossierAntwoord()
                {
                    ID = dossier.ID,
                    inhoud = dossier.inhoud,
                    extraInfo = dossier.extraInfo,
                    datum = dossier.datum,
                    aantalStemmen = dossier.aantalStemmen,
                    //editable = dossier.editable,
                    gebruikersNaam = dossier.gebruikersNaam,
                    aantalFlags = dossier.aantalFlags,
                    moduleID = dossier.module.ID,
                    // vasteTags = new List<ANDROIDVasteTag>(),
                    // persoonlijkeTags = new List<ANDROIDPersoonlijkeTag>(),
                    //afbeeldingPath = dossier.afbeeldingPath,
                    percentageVolledigheid = dossier.percentageVolledigheid,
                    statusOnline = dossier.statusOnline,
                    extraVraag = dossier.extraVraag,
                    evenementID = 10/*dossier.evenement.ID*/,
                    comments = new List<ANDROIDComment>(),
                    titel = dossier.titel,
                    googleMapsAdress = dossier.googleMapsAdress,
                    subtitel = dossier.subtitel,
                    textvak2 = dossier.textvak2,
                    textvak3 = dossier.textvak3
                };
                if (dossier.module.ID == moduleManager.readActieveDossierModule().ID)
                {
                    dosAntwoord.isActieveModule = true;
                }
                else
                {
                    dosAntwoord.isActieveModule = false;
                }
                //Image tmpimg = null;
                //HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create("~/"+dosAntwoord.afbeeldingPath);
                //HttpWebResponse httpWebReponse = (HttpWebResponse)httpWebRequest.GetResponse();
                //Stream stream = httpWebReponse.GetResponseStream();
                //tmpimg = Image.FromStream(stream);

                //MemoryStream ms = new MemoryStream();
                //tmpimg.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                //dosAntwoord.afbeeldingBytes = ms.ToArray();

                //foreach (VasteTag vTag in dossier.vasteTags)
                //{
                //    ANDROIDVasteTag vasteTag = new ANDROIDVasteTag()
                //    {
                //        ID = vTag.ID,
                //        naam = vTag.naam,
                //        beschrijving = vTag.beschrijving
                //    };
                //    dosAntwoord.vasteTags.Add(vasteTag);
                //}

                //foreach (PersoonlijkeTag pTag in dossier.persoonlijkeTags)
                //{
                //    ANDROIDPersoonlijkeTag persTag = new ANDROIDPersoonlijkeTag()
                //    {
                //        ID = pTag.ID,
                //        naam = pTag.naam,
                //        beschrijving = pTag.beschrijving
                //    };
                //    dosAntwoord.persoonlijkeTags.Add(persTag);
                //}

                //foreach (Comment comment in dossier.comments)
                //{
                //    ANDROIDComment aComment = new ANDROIDComment()
                //    {
                //        ID = comment.ID,
                //        inhoud = comment.inhoud,
                //        datum = comment.datum,
                //        aantalStemmen = comment.aantalStemmen,
                //        gebruikersNaam = comment.gebruikersNaam
                //    };
                //    dosAntwoord.comments.Add(aComment);
                //}
                dossierAntwoorden.Add(dosAntwoord);
            }
            return Ok(dossierAntwoorden);
        }
<<<<<<< HEAD
        [HttpGet]
        [ActionName("getUserAgendaAntwoord")]
        public IHttpActionResult getUserAgendaAntwoord(string username)
        {
            List<AgendaAntwoord> antwoorden = antwoordManager.readAllAgendaAntwoorden();
            List<ANDROIDAgendaAntwoord> returnAntw = new List<ANDROIDAgendaAntwoord>();
            foreach (var antwoord in antwoorden)
            {
                if (antwoord.gebruikersNaam == username)
                {
                    ANDROIDAgendaAntwoord antw = new ANDROIDAgendaAntwoord()
                    {
                        ID = antwoord.ID,
                        inhoud = antwoord.inhoud,
                        extraInfo = antwoord.extraInfo,
                        datum = antwoord.datum,
                        aantalStemmen = antwoord.aantalStemmen,
                        //editable = dossier.editable,
                        gebruikersNaam = antwoord.gebruikersNaam,
                        aantalFlags = antwoord.aantalFlags,
                        moduleID = antwoord.module.ID,
                        //vasteTags = new List<ANDROIDVasteTag>(),
                        //persoonlijkeTags = new List<ANDROIDPersoonlijkeTag>(),
                        //afbeeldingPath = dossier.afbeeldingPath,
                        statusOnline = antwoord.statusOnline,
                        titel = antwoord.titel,
                        subTitel = antwoord.subtitel
                    };
                    if (antwoord.module.ID == moduleManager.readActieveAgendaModule().ID)
                    {
                        antw.isActieveModule = true;
                    }
                    else
                    {
                        antw.isActieveModule = false;
                    }
                }
            }
            return Ok(returnAntw);
        }
        [HttpGet]
        [ActionName("getUserDossierAntwoord")]
        public IHttpActionResult getUserDossierAntwoord(string username)
        {
            List<DossierAntwoord> dossiers = antwoordManager.readAllDossierAntwoorden();
            List<ANDROIDDossierAntwoord> returnDossier = new List<ANDROIDDossierAntwoord>();
            foreach (var dos in dossiers)
            {
                if(dos.gebruikersNaam==username)
                {
                    ANDROIDDossierAntwoord dossier = new ANDROIDDossierAntwoord()
                    {
                        ID = dos.ID,
                        inhoud = dos.inhoud,
                        extraInfo = dos.extraInfo,
                        datum = dos.datum,
                        aantalStemmen = dos.aantalStemmen,
                        //editable = dossier.editable,
                        gebruikersNaam = dos.gebruikersNaam,
                        aantalFlags = dos.aantalFlags,
                        moduleID = dos.module.ID,
                        // vasteTags = new List<ANDROIDVasteTag>(),
                        // persoonlijkeTags = new List<ANDROIDPersoonlijkeTag>(),
                        //afbeeldingPath = dossier.afbeeldingPath,
                        percentageVolledigheid = dos.percentageVolledigheid,
                        statusOnline = dos.statusOnline,
                        extraVraag = dos.extraVraag,
                        comments = new List<ANDROIDComment>(),
                        titel = dos.titel,
                        googleMapsAdress = dos.googleMapsAdress,
                        subtitel = dos.subtitel,
                        textvak2 = dos.textvak2,
                        textvak3 = dos.textvak3
                    };
                    if (dos.module.ID == moduleManager.readActieveDossierModule().ID)
                    {
                        dossier.isActieveModule = true;
                    }
                    else
                    {
                        dossier.isActieveModule = false;
                    }
                    returnDossier.Add(dossier);
                }
            }
            return Ok(returnDossier);
        }

        [HttpGet]
        [ActionName("topagendas")]
        public IHttpActionResult topagendas(string sorteer)
        {
            List<AgendaAntwoord> antwoorden = new List<AgendaAntwoord>();
            switch (sorteer)
            {
                case "az":
                    antwoorden = antwoordManager.sortAgendaAntwoordAZ(moduleManager.readActieveAgendaModule().agendaAntwoorden);
                    break;
                case "za":
                    antwoorden = antwoordManager.sortAgendaAntwoordZA(moduleManager.readActieveAgendaModule().agendaAntwoorden);
                    break;
                case "minstelikes":
                    antwoorden = antwoordManager.sortAgendaAntwoordMinsteLikes(moduleManager.readActieveAgendaModule().agendaAntwoorden);
                    break;
                case "meestlikes":
                    antwoorden = antwoordManager.sortAgendaAntwoordMeesteLikes(moduleManager.readActieveAgendaModule().agendaAntwoorden);
                    break;
                case "nieuwoud":
                    antwoorden = antwoordManager.sortAgendaAntwoordNieuwOud(moduleManager.readActieveAgendaModule().agendaAntwoorden);
                    break;
                case "oudnieuw":
                    antwoorden = antwoordManager.sortAgendaAntwoordOudNieuw(moduleManager.readActieveAgendaModule().agendaAntwoorden);
                    break;
            }
            List<ANDROIDAgendaAntwoord> returnAnt = new List<ANDROIDAgendaAntwoord>();
            foreach (var agenda in antwoorden)
            {
                ANDROIDAgendaAntwoord ag = new ANDROIDAgendaAntwoord()
                {
                    ID = agenda.ID,
                    inhoud = agenda.inhoud,
                    extraInfo = agenda.extraInfo,
                    datum = agenda.datum,
                    aantalStemmen = agenda.aantalStemmen,
                    //editable = agenda.editable,
                    gebruikersNaam = agenda.gebruikersNaam,
                    aantalFlags = agenda.aantalFlags,
                    moduleID = agenda.module.ID,
                    //vasteTags = new List<ANDROIDVasteTag>(),
                    // persoonlijkeTags = new List<ANDROIDPersoonlijkeTag>(),
                    titel = agenda.titel,
                    subTitel = agenda.subtitel
                };
                if (agenda.module.ID == moduleManager.readActieveAgendaModule().ID)
                {
                    ag.isActieveModule = true;
                }
                else
                {
                    ag.isActieveModule = false;
                }

                returnAnt.Add(ag);
            }
            return Ok(returnAnt);
        }
        [HttpGet]
        [ActionName("topdossiers")]
        public IHttpActionResult topdossiers(string sorteer)
        {
            List<DossierAntwoord> antwoorden = new List<DossierAntwoord>();
            switch (sorteer)
            {
                case "az":
                    antwoorden = antwoordManager.sortDossierAntwoordTitelAZ(moduleManager.readActieveDossierModule().dossierAntwoorden);
                    break;
                case "za":
                    antwoorden = antwoordManager.sortDossierAntwoordTitelZA(moduleManager.readActieveDossierModule().dossierAntwoorden);
                    break;
                case "minstelikes":
                    antwoorden = antwoordManager.sortDossierAntwoordMinsteLikes(moduleManager.readActieveDossierModule().dossierAntwoorden);
                    break;
                case "meestlikes":
                    antwoorden = antwoordManager.sortDossierAntwoordMeesteLikes(moduleManager.readActieveDossierModule().dossierAntwoorden);
                    break;
                case "nieuwoud":
                    antwoorden = antwoordManager.sortDossierAntwoordNieuwOud(moduleManager.readActieveDossierModule().dossierAntwoorden);
                    break;
                case "oudnieuw":
                    antwoorden = antwoordManager.sortDossierAntwoordOudNieuw(moduleManager.readActieveDossierModule().dossierAntwoorden);
                    break;
            }
            List<ANDROIDDossierAntwoord> returnAnt = new List<ANDROIDDossierAntwoord>();
            foreach (var dossier in antwoorden)
            {
                ANDROIDDossierAntwoord dos = new ANDROIDDossierAntwoord()
                {
                    ID = dossier.ID,
                    inhoud = dossier.inhoud,
                    extraInfo = dossier.extraInfo,
                    datum = dossier.datum,
                    aantalStemmen = dossier.aantalStemmen,
                    //editable = dossier.editable,
                    gebruikersNaam = dossier.gebruikersNaam,
                    aantalFlags = dossier.aantalFlags,
                    moduleID = dossier.module.ID,
                    // vasteTags = new List<ANDROIDVasteTag>(),
                    // persoonlijkeTags = new List<ANDROIDPersoonlijkeTag>(),
                    //afbeeldingPath = dossier.afbeeldingPath,
                    percentageVolledigheid = dossier.percentageVolledigheid,
                    statusOnline = dossier.statusOnline,
                    extraVraag = dossier.extraVraag,
                    evenementID = 10/*dossier.evenement.ID*/,
                    comments = new List<ANDROIDComment>(),
                    titel = dossier.titel,
                    googleMapsAdress = dossier.googleMapsAdress,
                    subtitel = dossier.subtitel,
                    textvak2 = dossier.textvak2,
                    textvak3 = dossier.textvak3
                };
                if (dossier.module.ID == moduleManager.readActieveDossierModule().ID)
                {
                    dos.isActieveModule = true;
                }
                else
                {
                    dos.isActieveModule = false;
                }

                returnAnt.Add(dos);
            }
            return Ok(returnAnt);
        }
=======
>>>>>>> origin/master
        #endregion

        #region CREATE dossier/agenda
        //VOID of niet?
        [HttpPost]
        [ActionName("createAgenda")]
        public void createAgendaAntwoord(ANDROIDAgendaAntwoord agendaAntwoord)
        {
            AgendaAntwoord agAntwoord = new AgendaAntwoord()
            {
                aantalFlags = 0,
                aantalStemmen = 0,
                datum = DateTime.Now,
                extraInfo = agendaAntwoord.extraInfo,
                gebruikersNaam = agendaAntwoord.gebruikersNaam,
                inhoud = agendaAntwoord.inhoud,
                subtitel = agendaAntwoord.subTitel,
                titel = agendaAntwoord.titel,
                vasteTags = new List<VasteTag>(),
                persoonlijkeTags = new List<PersoonlijkeTag>(),
                statusOnline=true,
            };
            AgendaModule actieveAg = moduleManager.readActieveAgendaModule();
            agAntwoord.module = actieveAg;
            AgendaAntwoord createAg = antwoordManager.createAgendaAntwoord(agAntwoord);
            actieveAg.agendaAntwoorden.Add(createAg);
            moduleManager.updateAgendaModule(actieveAg);
        }
        [HttpPost]
        [ActionName("createDossier")]
        public void createDossierAntwoord(ANDROIDDossierAntwoord dossierAntwoord)
        {
            DossierAntwoord dosAntwoord = new DossierAntwoord()
            {
                gebruikersNaam = dossierAntwoord.gebruikersNaam,
                comments = new List<Comment>(),
                vasteTags = new List<VasteTag>(),
                persoonlijkeTags = new List<PersoonlijkeTag>(),
                datum = DateTime.Now,//
                aantalFlags = 0,//
                aantalStemmen = 0,//
                percentageVolledigheid = 50,//
                statusOnline = true,//
                layoutOption = 1,//
                subtitel = dossierAntwoord.subtitel,
                titel = dossierAntwoord.titel,
                inhoud = dossierAntwoord.inhoud,
                textvak2 = dossierAntwoord.textvak2,
                textvak3 = dossierAntwoord.textvak3,
                googleMapsAdress = dossierAntwoord.googleMapsAdress,
                afbeeldingPath = dossierAntwoord.afbeeldingPath,
                backgroundColor="red",//
                foregroundColor="green",//
                extraInfo = dossierAntwoord.extraInfo,
                extraVraag = dossierAntwoord.extraVraag,
                backgroundImage="tstest"//
            };

            DossierModule actieveDos = moduleManager.readActieveDossierModule();
            dosAntwoord.module = actieveDos;
            DossierAntwoord createDos = antwoordManager.createDossierAntwoord(dosAntwoord);
            actieveDos.dossierAntwoorden.Add(createDos);
            moduleManager.updateDossierModule(actieveDos);

            //foreach(var vtag in dossierAntwoord.vasteTags)
            //{
            //    VasteTag tag = new VasteTag()
            //    {
            //        ID=vtag.ID,
            //        beschrijving=vtag.beschrijving,
            //        naam=vtag.naam
            //    };
            //    dosAntwoord.vasteTags.Add(tag);
            //}
            //foreach (var ptag in dossierAntwoord.persoonlijkeTags)
            //{
            //    PersoonlijkeTag tag = new PersoonlijkeTag()
            //    {
            //        ID = ptag.ID,
            //        beschrijving = ptag.beschrijving,
            //        naam = ptag.naam
            //    };
            //    dosAntwoord.persoonlijkeTags.Add(tag);
            //}
        }
        #endregion

        #region UPDATE dossier/agenda
        [HttpPut]
        [ActionName("updateAgenda")]
        public void updateAgendaAntwoord(AgendaAntwoord antwoord)
        {
            AgendaAntwoord ag= antwoordManager.readAgendaAntwoord(antwoord.ID);
            ag.extraInfo = antwoord.extraInfo;
            ag.persoonlijkeTags = antwoord.persoonlijkeTags;
            ag.subtitel = antwoord.subtitel;
            antwoordManager.updateAgendaAntwoord(ag);
        }
        [HttpPut]
        [ActionName("updateDossier")]
        public void updateDossierAntwoord(DossierAntwoord antwoord)
        {
            DossierAntwoord dos = antwoordManager.readDossierAntwoord(antwoord.ID);
            dos.googleMapsAdress = antwoord.googleMapsAdress;
            dos.subtitel = antwoord.subtitel;
            dos.extraInfo = antwoord.extraInfo;
            dos.extraVraag = antwoord.extraVraag;
            dos.persoonlijkeTags = antwoord.persoonlijkeTags;
            dos.textvak2 = antwoord.textvak2;
            dos.textvak3 = antwoord.textvak3;
            antwoordManager.updateDossierAntwoord(dos);
        }
        #endregion

        #region STEM FLAG
        [HttpGet]
        [ActionName("stemCommentID")]
        public IHttpActionResult stemOpComment(int id)
        {
            antwoordManager.stemOpComment(id);
            return Ok("ok");
        }
        [HttpGet]
        [ActionName("stemAntwoordID")]
        public IHttpActionResult stemOpAntwoord(int id)
        {
            antwoordManager.stemOpAntwoord(id);
            return Ok("ok");
        }
        [HttpGet]
        [ActionName("flagAntwoord")]
        public IHttpActionResult flagAntwoord(int id)
        {
            antwoordManager.flagAntwoord(id);
            return Ok("ok");
        }
        #endregion

        #region DELETE antwoord
        [HttpDelete]
        [ActionName("deleteAntwoordID")]
        public void deleteAntwoord(int id)
        {
            antwoordManager.removeAntwoord(id);
        }
        #endregion
    }
}
