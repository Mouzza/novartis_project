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
                    vasteTags = new List<ANDROIDVasteTag>(),
                    persoonlijkeTags = new List<ANDROIDPersoonlijkeTag>(),
                    titel = agenda.titel,
                    subTitel=agenda.subtitel
                };

                foreach (var vTag in agenda.vasteTags)
                {
                    ANDROIDVasteTag vasteTag = new ANDROIDVasteTag()
                    {
                        ID = vTag.ID,
                        naam = vTag.naam,
                        beschrijving = vTag.beschrijving
                    };
                    agAntwoord.vasteTags.Add(vasteTag);
                }

                foreach (var pTag in agenda.persoonlijkeTags)
                {
                    ANDROIDPersoonlijkeTag persTag = new ANDROIDPersoonlijkeTag()
                    {
                        ID = pTag.ID,
                        naam = pTag.naam,
                        beschrijving = pTag.beschrijving
                    };
                    agAntwoord.persoonlijkeTags.Add(persTag);
                }
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
                    vasteTags = new List<ANDROIDVasteTag>(),
                    persoonlijkeTags = new List<ANDROIDPersoonlijkeTag>(),
                    //afbeeldingPath = dossier.afbeeldingPath,
                    percentageVolledigheid = dossier.percentageVolledigheid,
                    statusOnline = dossier.statusOnline,
                    extraVraag = dossier.extraVraag,
                    evenementID = 10/*dossier.evenement.ID*/,
                    comments = new List<ANDROIDComment>(),
                    titel = dossier.titel,
                    googleMapsAdress = dossier.googleMapsAdress,
                    subtitel=dossier.subtitel,
                    textvak2 = dossier.textvak2,
                    textvak3=dossier.textvak3
                };

                //Image tmpimg = null;
                //HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create("~/"+dosAntwoord.afbeeldingPath);
                //HttpWebResponse httpWebReponse = (HttpWebResponse)httpWebRequest.GetResponse();
                //Stream stream = httpWebReponse.GetResponseStream();
                //tmpimg = Image.FromStream(stream);

                //MemoryStream ms = new MemoryStream();
                //tmpimg.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                //dosAntwoord.afbeeldingBytes = ms.ToArray();

                foreach (VasteTag vTag in dossier.vasteTags)
                {
                    ANDROIDVasteTag vasteTag = new ANDROIDVasteTag()
                    {
                        ID = vTag.ID,
                        naam = vTag.naam,
                        beschrijving = vTag.beschrijving
                    };
                    dosAntwoord.vasteTags.Add(vasteTag);
                }

                foreach (PersoonlijkeTag pTag in dossier.persoonlijkeTags)
                {
                    ANDROIDPersoonlijkeTag persTag = new ANDROIDPersoonlijkeTag()
                    {
                        ID = pTag.ID,
                        naam = pTag.naam,
                        beschrijving = pTag.beschrijving
                    };
                    dosAntwoord.persoonlijkeTags.Add(persTag);
                }

                foreach (Comment comment in dossier.comments)
                {
                    ANDROIDComment aComment = new ANDROIDComment()
                    {
                        ID = comment.ID,
                        inhoud = comment.inhoud,
                        datum = comment.datum,
                        aantalStemmen = comment.aantalStemmen,
                        gebruikersNaam = comment.gebruikersNaam
                    };
                    dosAntwoord.comments.Add(aComment);
                }
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
                module = moduleManager.readAllAgendaModules().Find(o => o.ID==agendaAntwoord.moduleID),
                vasteTags = new List<VasteTag>(),
                persoonlijkeTags = new List<PersoonlijkeTag>(),
            };
            antwoordManager.createAgendaAntwoord(agAntwoord);
        }
        [HttpPost]
        [ActionName("createDossier")]
        public void createDossierAntwoord(ANDROIDDossierAntwoord dossierAntwoord)
        {
            DossierAntwoord dosAntwoord = new DossierAntwoord()
            {
                aantalFlags = dossierAntwoord.aantalFlags,
                aantalStemmen = dossierAntwoord.aantalStemmen,
                datum = dossierAntwoord.datum,
                //editable = dossierAntwoord.editable,
                extraInfo = dossierAntwoord.extraInfo,
                gebruikersNaam = dossierAntwoord.gebruikersNaam,
                ID = dossierAntwoord.ID,
                inhoud = dossierAntwoord.inhoud,
                subtitel = dossierAntwoord.subtitel,
                titel = dossierAntwoord.titel,
                module = moduleManager.readAllDossierModules().Find(o=>o.ID==dossierAntwoord.moduleID),
                vasteTags = new List<VasteTag>(),
                persoonlijkeTags = new List<PersoonlijkeTag>(),
                comments = new List<Comment>(),
                afbeeldingPath = dossierAntwoord.afbeeldingPath,
                googleMapsAdress = dossierAntwoord.googleMapsAdress,
                evenement=new Evenement(), //kan evenement niet oproepen
                extraVraag = dossierAntwoord.extraVraag,
                percentageVolledigheid = dossierAntwoord.percentageVolledigheid,
                statusOnline = dossierAntwoord.statusOnline,
                textvak2 = dossierAntwoord.textvak2,
                textvak3 = dossierAntwoord.textvak3
            };
            
            foreach(var vtag in dossierAntwoord.vasteTags)
            {
                VasteTag tag = new VasteTag()
                {
                    ID=vtag.ID,
                    beschrijving=vtag.beschrijving,
                    naam=vtag.naam
                };
                dosAntwoord.vasteTags.Add(tag);
            }
            foreach (var ptag in dossierAntwoord.persoonlijkeTags)
            {
                PersoonlijkeTag tag = new PersoonlijkeTag()
                {
                    ID = ptag.ID,
                    beschrijving = ptag.beschrijving,
                    naam = ptag.naam
                };
                dosAntwoord.persoonlijkeTags.Add(tag);
            }
            foreach (var comment in dossierAntwoord.comments)
            {
                Comment com = new Comment()
                {
                    ID = comment.ID,
                    aantalStemmen=comment.aantalStemmen,
                    datum=comment.datum,
                    gebruikersNaam=comment.gebruikersNaam,
                    inhoud=comment.inhoud
                };
                dosAntwoord.comments.Add(com);
            }
            antwoordManager.createDossierAntwoord(dosAntwoord);
        }
        #endregion

        #region UPDATE dossier/agenda
        [HttpPut]
        [ActionName("updateAgenda")]
        public void updateAgendaAntwoord(Antwoord antwoord)
        {
            antwoordManager.updateAgendaAntwoord(antwoord);
        }
        [HttpPut]
        [ActionName("updateDossier")]
        public void updateDossierAntwoord(Antwoord antwoord)
        {
            antwoordManager.updateDossierAntwoord(antwoord);
        }
        #endregion

        #region STEM
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
