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
        StemManager stemManager = new StemManager();

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
                    //editable = agenda.editable,
                    gebruikersNaam = agenda.gebruikersNaam,
                    moduleID = agenda.module.ID,
                    //vasteTags = new List<ANDROIDVasteTag>(),
                    // persoonlijkeTags = new List<ANDROIDPersoonlijkeTag>(),
                    titel = agenda.titel,
                    subTitel = agenda.subtitel,
                    statusOnline=agenda.statusOnline
                };
                if (agenda.module.ID == moduleManager.readActieveAgendaModule().ID)
                {
                    agAntwoord.isActieveModule = true;
                }
                else
                {
                    agAntwoord.isActieveModule = false;
                }
                foreach(var stem in agenda.stemmen)
                {
                    ANDROIDstem aStem = new ANDROIDstem()
                    {
                        antwoordid=stem.antwoord.ID,
                        gebruikersNaam=stem.gebruikersNaam

                    };
                    agAntwoord.stemmen.Add(aStem);
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
                    //editable = dossier.editable,
                    gebruikersNaam = dossier.gebruikersNaam,
                    moduleID = dossier.module.ID,
                    // vasteTags = new List<ANDROIDVasteTag>(),
                    // persoonlijkeTags = new List<ANDROIDPersoonlijkeTag>(),
                    afbeeldingByte = dossier.afbeeldingByte,
                    percentageVolledigheid = dossier.percentageVolledigheid,
                    statusOnline = dossier.statusOnline,
                    extraVraag = dossier.extraVraag,
                    titel = dossier.titel,
                    googleMapsAdress = dossier.googleMapsAdress,
                    subtitel = dossier.subtitel,
                    textvak2 = dossier.textvak2,
                    textvak3 = dossier.textvak3,
                    stemmen=new List<ANDROIDstem>()
                };
                if (dossier.module.ID == moduleManager.readActieveDossierModule().ID)
                {
                    dosAntwoord.isActieveModule = true;
                }
                else
                {
                    dosAntwoord.isActieveModule = false;
                }
                foreach (var stem in dossier.stemmen)
                {
                    ANDROIDstem aStem = new ANDROIDstem()
                    {
                        antwoordid = stem.antwoord.ID,
                        gebruikersNaam = stem.gebruikersNaam
                    };
                    dosAntwoord.stemmen.Add(aStem);
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
                        //editable = dossier.editable,
                        gebruikersNaam = antwoord.gebruikersNaam,
                        moduleID = antwoord.module.ID,
                        //vasteTags = new List<ANDROIDVasteTag>(),
                        //persoonlijkeTags = new List<ANDROIDPersoonlijkeTag>(),
                        //afbeeldingPath = dossier.afbeeldingPath,
                        statusOnline = antwoord.statusOnline,
                        titel = antwoord.titel,
                        subTitel = antwoord.subtitel,
                        stemmen=new List<ANDROIDstem>()
                    };
                    if (antwoord.module.ID == moduleManager.readActieveAgendaModule().ID)
                    {
                        antw.isActieveModule = true;
                    }
                    else
                    {
                        antw.isActieveModule = false;
                    }
                    foreach (var stem in antwoord.stemmen)
                    {
                        ANDROIDstem aStem = new ANDROIDstem()
                        {
                            antwoordid = stem.antwoord.ID,
                            gebruikersNaam = stem.gebruikersNaam
                        };
                        antw.stemmen.Add(aStem);
                    }
                    returnAntw.Add(antw);
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
                        //editable = dossier.editable,
                        gebruikersNaam = dos.gebruikersNaam,
                        moduleID = dos.module.ID,
                        // vasteTags = new List<ANDROIDVasteTag>(),
                        // persoonlijkeTags = new List<ANDROIDPersoonlijkeTag>(),
                        afbeeldingByte = dos.afbeeldingByte,
                        percentageVolledigheid = dos.percentageVolledigheid,
                        statusOnline = dos.statusOnline,
                        extraVraag = dos.extraVraag,
                        titel = dos.titel,
                        googleMapsAdress = dos.googleMapsAdress,
                        subtitel = dos.subtitel,
                        textvak2 = dos.textvak2,
                        textvak3 = dos.textvak3,
                        stemmen=new List<ANDROIDstem>()
                    };
                    foreach (var stem in dos.stemmen)
                    {
                        ANDROIDstem aStem = new ANDROIDstem()
                        {
                            antwoordid = stem.antwoord.ID,
                            gebruikersNaam = stem.gebruikersNaam
                        };
                        dossier.stemmen.Add(aStem);
                    }
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
                    //editable = agenda.editable,
                    gebruikersNaam = agenda.gebruikersNaam,
                    moduleID = agenda.module.ID,
                    //vasteTags = new List<ANDROIDVasteTag>(),
                    // persoonlijkeTags = new List<ANDROIDPersoonlijkeTag>(),
                    titel = agenda.titel,
                    subTitel = agenda.subtitel,
                    stemmen=new List<ANDROIDstem>()
                };
                if (agenda.module.ID == moduleManager.readActieveAgendaModule().ID)
                {
                    ag.isActieveModule = true;
                }
                else
                {
                    ag.isActieveModule = false;
                }
                foreach (var stem in agenda.stemmen)
                {
                    ANDROIDstem aStem = new ANDROIDstem()
                    {
                        antwoordid = stem.antwoord.ID,
                        gebruikersNaam = stem.gebruikersNaam
                    };
                    ag.stemmen.Add(aStem);
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
                    //editable = dossier.editable,
                    gebruikersNaam = dossier.gebruikersNaam,
                    moduleID = dossier.module.ID,
                    // vasteTags = new List<ANDROIDVasteTag>(),
                    // persoonlijkeTags = new List<ANDROIDPersoonlijkeTag>(),
                    afbeeldingByte = dossier.afbeeldingByte,
                    percentageVolledigheid = dossier.percentageVolledigheid,
                    statusOnline = dossier.statusOnline,
                    extraVraag = dossier.extraVraag,
                    titel = dossier.titel,
                    googleMapsAdress = dossier.googleMapsAdress,
                    subtitel = dossier.subtitel,
                    textvak2 = dossier.textvak2,
                    textvak3 = dossier.textvak3,
                    stemmen=new List<ANDROIDstem>()
                };
                foreach (var stem in dossier.stemmen)
                {
                    ANDROIDstem aStem = new ANDROIDstem()
                    {
                        antwoordid = stem.antwoord.ID,
                        gebruikersNaam = stem.gebruikersNaam
                    };
                    dos.stemmen.Add(aStem);
                }
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

        #endregion

        #region CREATE dossier/agenda
        //VOID of niet?
        [HttpPost]
        [ActionName("createAgenda")]
        public void createAgendaAntwoord(ANDROIDAgendaAntwoord agendaAntwoord)
        {
            AgendaAntwoord agAntwoord = new AgendaAntwoord()
            {
                flags = new List<Flag>(),
                stemmen = new List<Stem>(),
                datum = DateTime.Now,
                extraInfo = agendaAntwoord.extraInfo,
                gebruikersNaam = agendaAntwoord.gebruikersNaam,
                inhoud = agendaAntwoord.inhoud,
                subtitel = agendaAntwoord.subTitel,
                titel = agendaAntwoord.titel,
                vasteTags = new List<VasteTag>(),
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
                datum = DateTime.Now,//
                flags = new List<Flag>(),
                stemmen = new List<Stem>(),
                percentageVolledigheid = 50,//
                statusOnline = true,//
                layoutOption = 1,//
                subtitel = dossierAntwoord.subtitel,
                titel = dossierAntwoord.titel,
                inhoud = dossierAntwoord.inhoud,
                textvak2 = dossierAntwoord.textvak2,
                textvak3 = dossierAntwoord.textvak3,
                googleMapsAdress = dossierAntwoord.googleMapsAdress,
                afbeeldingByte = dossierAntwoord.afbeeldingByte,
                backgroundColor="White",//
                foregroundColor="Black",//
                extraInfo = dossierAntwoord.extraInfo,
                extraVraag = dossierAntwoord.extraVraag
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
            ag.subtitel = antwoord.subtitel;
            ag.titel = antwoord.titel;
            antwoordManager.updateAgendaAntwoord(ag);

        }
        [HttpPut]
        [ActionName("updateDossier")]
        public void updateDossierAntwoord(DossierAntwoord antwoord)
        {
            DossierAntwoord dos = antwoordManager.readDossierAntwoord(antwoord.ID);
            dos.googleMapsAdress = antwoord.googleMapsAdress;
            dos.subtitel = antwoord.subtitel;
            dos.titel = antwoord.titel;
            dos.extraInfo = antwoord.extraInfo;
            dos.extraVraag = antwoord.extraVraag;
            dos.textvak2 = antwoord.textvak2;
            dos.textvak3 = antwoord.textvak3;
            antwoordManager.updateDossierAntwoord(dos);
        }
        #endregion

        #region STEM FLAG
        [HttpGet]
        [ActionName("stemAntwoord")]
        public IHttpActionResult stemAntwoord(ANDROIDstem aStem)
        {
            
            Antwoord antwoord = antwoordManager.readAllAntwoorden().Find(o=>o.ID==aStem.antwoordid);

            foreach (var stem in antwoord.stemmen)
            {
                if(stem.gebruikersNaam==aStem.gebruikersNaam)
                {
                    return Ok("nok");
                }
                else
                {
                    break;
                }

            }

            Stem stemAntwoord = new Stem()
            {
                antwoord=antwoordManager.readAgendaAntwoord(aStem.antwoordid),
                gebruikersNaam=aStem.gebruikersNaam
            };
            stemManager.stemOpAntwoord(stemAntwoord);
            return Ok("ok");


        }
       
        //[HttpGet]
        //[ActionName("flagAntwoord")]
        //public IHttpActionResult flagAntwoord(ANDROIDFlag flag)
        //{
        //    Antwoord antwoord = antwoordManager.readAllAntwoorden().Find(o=>o.ID==flag.antwoordid);
    
        //}
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
