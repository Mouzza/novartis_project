﻿using JPP.BL;
using JPP.BL.Domain.Antwoorden;
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


namespace JPP.UI.Web.MVC.Controllers
{
    public class AndroidAntwoordController : ApiController
    {
        AntwoordManager antwoordManager = new AntwoordManager();

        #region GET dossier/agenda
        [HttpGet]
        [ActionName("getAgendaAntwoordID")]
        public IHttpActionResult getAgendaAntwoorden(int id)
        {
            List<AgendaAntwoord> agendaAntwoord = antwoordManager.getAllAgendaAntwoordenPerModule(id);
            List<ANDROIDAgendaAntwoorden> agendaAntwoorden = new List<ANDROIDAgendaAntwoorden>();

            foreach (var agenda in agendaAntwoord)
            {
                ANDROIDAgendaAntwoorden agAntwoord = new ANDROIDAgendaAntwoorden()
                {
                    ID = agenda.ID,
                    inhoud = agenda.inhoud,
                    extraInfo = agenda.extraInfo,
                    datum = agenda.datum,
                    aantalStemmen = agenda.aantalStemmen,
                    editable = agenda.editable,
                    gebruikersNaam = agenda.gebruikersNaam,
                    aantalFlags = agenda.aantalFlags,
                    moduleID = agenda.module.ID,
                    vasteTags = new List<ANDROIDVasteTag>(),
                    persoonlijkeTags = new List<ANDROIDPersoonlijkeTag>(),
                    titel = agenda.titel
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
            List<ANDROIDDossierAntwoorden> dossierAntwoorden = new List<ANDROIDDossierAntwoorden>();
                foreach (DossierAntwoord dossier in dossierAntwoord)
                {
                    ANDROIDDossierAntwoorden dosAntwoord = new ANDROIDDossierAntwoorden()
                    {
                        ID = dossier.ID,
                        inhoud = dossier.inhoud,
                        extraInfo = dossier.extraInfo,
                        datum = dossier.datum,
                        aantalStemmen = dossier.aantalStemmen,
                        editable = dossier.editable,
                        gebruikersNaam = dossier.gebruikersNaam,
                        aantalFlags = dossier.aantalFlags,
                        moduleID = dossier.module.ID,
                        vasteTags = new List<ANDROIDVasteTag>(),
                        persoonlijkeTags = new List<ANDROIDPersoonlijkeTag>(),
                        afbeeldingPath = dossier.afbeeldingPath,
                        percentageVolledigheid = dossier.percentageVolledigheid,
                        statusOnline = dossier.statusOnline,
                        extraVraag = dossier.extraVraag,
                        evenementID = dossier.evenement.ID,
                        comments = new List<ANDROIDComment>(),
                        titel = dossier.titel
                    };
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
                }
            return Ok(dossierAntwoorden);
        }
        #endregion

        #region CREATE dossier/agenda
        //VOID of niet?
        [HttpPost]
        [ActionName("createAgenda")]
        public void createAgendaAntwoord(Antwoord antwoord)
        {
            antwoordManager.createAgendaAntwoord(antwoord);
        }
        [HttpPost]
        [ActionName("createDossier")]
        public void createDossierAntwoord(Antwoord antwoord)
        {
            antwoordManager.createDossierAntwoord(antwoord);
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
        [HttpPut]
        [ActionName("stemCommentID")]
        public void stemOpComment(int id)
        {
            antwoordManager.stemOpComment(id);
        }
        [HttpPut]
        [ActionName("stemAntwoordID")]
        public void stemOpAntwoord(int id)
        {
            antwoordManager.stemOpAntwoord(id);
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
