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
                    subTitel = agenda.subtitel
                };

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
        #endregion

        #region CREATE dossier/agenda
        //VOID of niet?
        [HttpPost]
        [ActionName("createAgenda")]
        public void createAgendaAntwoord(ANDROIDAgendaAntwoord agendaAntwoord)
        {
            AgendaAntwoord agAntwoord = new AgendaAntwoord()
            {
                aantalFlags = agendaAntwoord.aantalFlags,
                aantalStemmen = agendaAntwoord.aantalStemmen,
                datum = agendaAntwoord.datum,
                //editable = agendaAntwoord.editable,
                extraInfo = agendaAntwoord.extraInfo,
                gebruikersNaam = agendaAntwoord.gebruikersNaam,
                inhoud = agendaAntwoord.inhoud,
                subtitel = agendaAntwoord.subTitel,
                titel = agendaAntwoord.titel,
                vasteTags = new List<VasteTag>(),
                persoonlijkeTags = new List<PersoonlijkeTag>(),
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
                datum = dossierAntwoord.datum,
                aantalFlags = dossierAntwoord.aantalFlags,
                aantalStemmen = dossierAntwoord.aantalStemmen,
                percentageVolledigheid = dossierAntwoord.percentageVolledigheid,
                statusOnline = dossierAntwoord.statusOnline,
                layoutOption = 1,
                subtitel = dossierAntwoord.subtitel,
                titel = dossierAntwoord.titel,
                inhoud = dossierAntwoord.inhoud,
                textvak2 = dossierAntwoord.textvak2,
                textvak3 = dossierAntwoord.textvak3,
                googleMapsAdress = dossierAntwoord.googleMapsAdress,
                afbeeldingPath = dossierAntwoord.afbeeldingPath,
                backgroundColor="red",
                foregroundColor="green",
                //editable = dossierAntwoord.editable,
                extraInfo = dossierAntwoord.extraInfo,
                evenement = new Evenement(), //kan evenement niet oproepen
                extraVraag = dossierAntwoord.extraVraag,
                backgroundImage="tstest"
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
            antwoord.module = moduleManager.readActieveAgendaModule();
            antwoordManager.updateAgendaAntwoord(antwoord);
        }
        [HttpPut]
        [ActionName("updateDossier")]
        public void updateDossierAntwoord(DossierAntwoord antwoord)
        {
            antwoordManager.updateDossierAntwoord(antwoord);
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
