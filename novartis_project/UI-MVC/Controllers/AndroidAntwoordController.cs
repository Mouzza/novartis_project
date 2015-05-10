using JPP.BL;
using JPP.BL.Domain.Antwoorden;
using JPP.UI.Web.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JPP.UI.Web.MVC.Controllers
{
    public class AndroidAntwoordController : ApiController
    {
        AntwoordManager antwoordManager = new AntwoordManager();
        [HttpGet]
        #region GET dossier/agenda
        [ActionName("getAgendaAntwoorden")]
        public IHttpActionResult getAgendaAntwoorden()
        {
            List<AgendaAntwoord> agendaAntwoord = antwoordManager.readAllAgendaAntwoorden();
            List<ANDROIDAgendaAntwoorden> agendaAntwoorden = new List<ANDROIDAgendaAntwoorden>();

            foreach (AgendaAntwoord agenda in agendaAntwoord)
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
                    module = agenda.module,
                    vasteTags = new List<ANDROIDVasteTag>(),
                    persoonlijkeTags = new List<ANDROIDPersoonlijkeTag>(),
                    titel=agenda.titel
                };

                foreach (VasteTag vTag in agenda.vasteTags)
                {
                    ANDROIDVasteTag vasteTag = new ANDROIDVasteTag()
                    {
                        ID = vTag.ID,
                        naam = vTag.naam,
                        beschrijving = vTag.beschrijving
                    };
                    agAntwoord.vasteTags.Add(vasteTag);
                }

                foreach (PersoonlijkeTag pTag in agenda.persoonlijkeTags)
                {
                    ANDROIDVasteTag vasteTag = new ANDROIDVasteTag()
                    {
                        ID = pTag.ID,
                        naam = pTag.naam,
                        beschrijving = pTag.beschrijving
                    };
                    agAntwoord.vasteTags.Add(vasteTag);
                }
                agendaAntwoorden.Add(agAntwoord);
            }

            return Ok(agendaAntwoorden);

        }

        public IHttpActionResult getDossierAntwoorden()
        {
            List<DossierAntwoord> dossierAntwoord = antwoordManager.readAllDossierAntwoorden();
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
                    module = dossier.module,
                    vasteTags = new List<ANDROIDVasteTag>(),
                    persoonlijkeTags = new List<ANDROIDPersoonlijkeTag>(),
                    afbeeldingPath = dossier.afbeeldingPath,
                    percentageVolledigheid = dossier.percentageVolledigheid,
                    statusOnline = dossier.statusOnline,
                    extraVraag = dossier.extraVraag,
                    evenement = dossier.evenement,
                    comments = new List<ANDROIDComment>(),
                    titel=dossier.titel
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
        public void createAgendaAntwoord(Antwoord antwoord)
        {
            antwoordManager.createAgendaAntwoord(antwoord);
        }

        public void createDossierAntwoord(Antwoord antwoord)
        {
            antwoordManager.createDossierAntwoord(antwoord);
        }
        #endregion

        #region UPDATE dossier/agenda

        public void updateAgendaAntwoord(Antwoord antwoord)
        {
            antwoordManager.updateAgendaAntwoord(antwoord);
        }

        public void updateDossierAntwoord(Antwoord antwoord)
        {
            antwoordManager.updateDossierAntwoord(antwoord);
        }
        #endregion

        #region DELETE
        public void deleteAntwoord(int id)
        {
            antwoordManager.removeAntwoord(id);
        }
        #endregion

        #region STEM
        public void stemOpComment(int id)
        {
            antwoordManager.stemOpComment(id);
        }

        public void stemOpAntwoord(int id)
        {
            antwoordManager.stemOpAntwoord(id);
        }
        #endregion
    }
}
