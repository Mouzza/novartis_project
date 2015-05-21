using JPP.BL;
using JPP.BL.Domain.Modules;
using JPP.UI.Web.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JPP.UI.Web.MVC.Controllers
{
    public class AndroidModuleController : ApiController
    {

        ModuleManager moduleManager = new ModuleManager();

        #region ACTIEVE dossier/agenda
        [HttpGet]
        [ActionName("getActieveDossier")]
        public IHttpActionResult getActieveDossierModule()
        {
            DossierModule actieveDossierModule = moduleManager.readActieveDossierModule();
            //List<ANDROIDDossierModule> dossierModules = new List<ANDROIDDossierModule>();
            ANDROIDDossierModule dosModule = new ANDROIDDossierModule()
            {
                ID = actieveDossierModule.ID,
                naam = actieveDossierModule.naam,
                beginDatum = actieveDossierModule.beginDatum,
                eindDatum = actieveDossierModule.eindDatum,
                adminNaam = actieveDossierModule.adminNaam,
                status = actieveDossierModule.status,
                centralevraag = actieveDossierModule.centraleVraag.inhoud,
                beloning=new ANDROIDBeloning(),
                dossierAntwoorden=new List<ANDROIDDossierAntwoord>(),
                vasteVraagEen = actieveDossierModule.vasteVraagEen.inhoud,
                vasteVraagTwee = "aaaa" /*actieveDossierModule.vasteVraagTwee.inhoud*/,
                vasteVraagDrie = "aaaa"/*actieveDossierModule.vasteVraagDrie.inhoud*/,
                verplichteVolledigheidsPercentage = actieveDossierModule.verplichteVolledigheidsPercentage,
                
                /*thema = new Thema()
                //{
                //    ID = actieveDossierModule.thema.ID,
                //    naam = actieveDossierModule.thema.naam,
                //    beschrijving = actieveDossierModule.thema.beschrijving
                }*/
            };
            foreach(var dosAntwoord in actieveDossierModule.dossierAntwoorden)
            {
                ANDROIDDossierAntwoord dos = new ANDROIDDossierAntwoord()
                {
                    aantalFlags = dosAntwoord.aantalFlags,
                    aantalStemmen = dosAntwoord.stemmen.Count,
                    datum=dosAntwoord.datum,
                    //editable=dosAntwoord.editable,
                    evenementID=10/*dosAntwoord.evenement.ID*/,
                    extraInfo=dosAntwoord.extraInfo,
                    extraVraag=dosAntwoord.extraVraag,
                    gebruikersNaam=dosAntwoord.gebruikersNaam,
                    ID=dosAntwoord.ID,
                    inhoud=dosAntwoord.inhoud,
                    moduleID=dosAntwoord.module.ID,
                    percentageVolledigheid=dosAntwoord.percentageVolledigheid,
                    statusOnline=dosAntwoord.statusOnline,
                    titel=dosAntwoord.titel,
                    afbeeldingByte = dosAntwoord.afbeeldingByte,
                    textvak2=dosAntwoord.textvak2,
                    textvak3=dosAntwoord.textvak3,
                    comments = new List<ANDROIDComment>(),
                    //persoonlijkeTags = new List<ANDROIDPersoonlijkeTag>(),
                    //vasteTags=new List<ANDROIDVasteTag>(),
                    googleMapsAdress=dosAntwoord.googleMapsAdress,
                    subtitel=dosAntwoord.subtitel,
                    stemmen=new List<ANDROIDstem>()
                };
                if (dosAntwoord.module.ID == moduleManager.readActieveDossierModule().ID)
                {
                    dos.isActieveModule = true;
                }
                else
                {
                    dos.isActieveModule = false;
                }
                foreach (var stem in dosAntwoord.stemmen)
                {
                    ANDROIDstem astem = new ANDROIDstem()
                    {
                        antwoordid=stem.antwoord.ID,
                        gebruikersNaam=stem.gebruikersNaam
                    };
                    dos.stemmen.Add(astem);
                }
                //foreach (var vTag in dosAntwoord.vasteTags)
                //{
                //    ANDROIDVasteTag vasteTag = new ANDROIDVasteTag()
                //    {
                //        ID = vTag.ID,
                //        naam = vTag.naam,
                //        beschrijving = vTag.beschrijving
                //    };
                //    dos.vasteTags.Add(vasteTag);
                //}
                //foreach (var pTag in dosAntwoord.persoonlijkeTags)
                //{
                //    ANDROIDPersoonlijkeTag persTag = new ANDROIDPersoonlijkeTag()
                //    {
                //        ID = pTag.ID,
                //        naam = pTag.naam,
                //        beschrijving = pTag.beschrijving
                //    };
                //    dos.persoonlijkeTags.Add(persTag);
                //}

                foreach (var comment in dosAntwoord.comments)
                {
                    ANDROIDComment aComment = new ANDROIDComment()
                    {
                        ID = comment.ID,
                        inhoud = comment.inhoud,
                        datum = comment.datum,
                        aantalStemmen = comment.aantalStemmen,
                        gebruikersNaam = comment.gebruikersNaam
                    };
                    dos.comments.Add(aComment);
                }
                dosModule.dossierAntwoorden.Add(dos);
            }
            ANDROIDBeloning beloning = new ANDROIDBeloning()
            {
                naam = actieveDossierModule.beloning.naam,
                beschrijving = actieveDossierModule.beloning.beschrijving,
                ID = actieveDossierModule.beloning.ID
            };
            dosModule.beloning = beloning;

            //dossierModules.Add(dosModule);

            //var json = JsonConvert.SerializeObject(dosModule);
            //  json = json.Replace(@"\", @"");

            //return Ok(dossierModules);
            return Ok(dosModule);
        }
        [HttpGet]
        [ActionName("getActieveAgenda")]
        public IHttpActionResult getActieveAgendaModule()
        {
            AgendaModule actieveAgendaModule = moduleManager.readActieveAgendaModule();
           // List<ANDROIDAgendaModule> agendaModules = new List<ANDROIDAgendaModule>();
            ANDROIDAgendaModule agendaModule = new ANDROIDAgendaModule()
            {
                ID = actieveAgendaModule.ID,
                naam = actieveAgendaModule.naam,
                beginDatum = actieveAgendaModule.beginDatum,
                eindDatum = actieveAgendaModule.eindDatum,
                adminNaam = actieveAgendaModule.adminNaam,
                status = actieveAgendaModule.status,
                centraleVraag = actieveAgendaModule.centraleVraag.inhoud,
                agendaAntwoorden = new List<ANDROIDAgendaAntwoord>(),
                beloning=new ANDROIDBeloning()
                /*thema = new Thema()
                //{
                //    ID = actieveDossierModule.thema.ID,
                //    naam = actieveDossierModule.thema.naam,
                //    beschrijving = actieveDossierModule.thema.beschrijving
                }*/
            };
            foreach (var agAntwoord in actieveAgendaModule.agendaAntwoorden)
            {
                ANDROIDAgendaAntwoord ag = new ANDROIDAgendaAntwoord()
                {
                    aantalFlags = agAntwoord.aantalFlags,
                    aantalStemmen = agAntwoord.stemmen.Count,
                    datum = agAntwoord.datum,
                    //editable = agAntwoord.editable,
                    extraInfo = agAntwoord.extraInfo,
                    gebruikersNaam = agAntwoord.gebruikersNaam,
                    ID = agAntwoord.ID,
                    inhoud = agAntwoord.inhoud,
                    moduleID = agAntwoord.module.ID,
                    //persoonlijkeTags = new List<ANDROIDPersoonlijkeTag>(),
                    titel = agAntwoord.titel,
                    //vasteTags = new List<ANDROIDVasteTag>()
                };
                if (agAntwoord.module.ID == moduleManager.readActieveAgendaModule().ID)
                {
                    ag.isActieveModule = true;
                }
                else
                {
                    ag.isActieveModule = false;
                }
                foreach (var stem in agAntwoord.stemmen)
                {
                    ANDROIDstem astem = new ANDROIDstem()
                    {
                        antwoordid = stem.antwoord.ID,
                        gebruikersNaam = stem.gebruikersNaam
                    };
                    ag.stemmen.Add(astem);
                }
                //foreach (var pTag in agAntwoord.persoonlijkeTags)
                //{
                //    ANDROIDPersoonlijkeTag persTag = new ANDROIDPersoonlijkeTag()
                //    {
                //        ID = pTag.ID,
                //        naam = pTag.naam,
                //        beschrijving = pTag.beschrijving
                //    };
                //    ag.persoonlijkeTags.Add(persTag);
                //}

                //foreach (var vTag in agAntwoord.vasteTags)
                //{
                //    ANDROIDVasteTag vasteTag = new ANDROIDVasteTag()
                //    {
                //        ID = vTag.ID,
                //        naam = vTag.naam,
                //        beschrijving = vTag.beschrijving
                //    };
                //    ag.vasteTags.Add(vasteTag);
                //}
                agendaModule.agendaAntwoorden.Add(ag);
            }


            ANDROIDBeloning beloning = new ANDROIDBeloning()
            {
                naam = actieveAgendaModule.beloning.naam,
                beschrijving = actieveAgendaModule.beloning.beschrijving,
                ID = actieveAgendaModule.beloning.ID
            };
            agendaModule.beloning = beloning;

           // agendaModules.Add(agendaModule);

            //var json = JsonConvert.SerializeObject(dosModule);
            //  json = json.Replace(@"\", @"");
            
            //return Ok(agendaModules);
            return Ok(agendaModule);
        }
        
        #endregion

        #region ALL dossier/agenda
        [HttpGet]
        [ActionName("getAllAgendas")]
        public IHttpActionResult getAllAgendaModules()
        {
            List<AgendaModule> agendaModules = moduleManager.readAllAgendaModules();
            List<ANDROIDAgendaModule> agModules = new List<ANDROIDAgendaModule>();

            foreach (var agenda in agendaModules)
            {
                ANDROIDAgendaModule agModule = new ANDROIDAgendaModule()
                {
                    adminNaam = agenda.adminNaam,
                    beginDatum = agenda.beginDatum,
                    centraleVraag = agenda.centraleVraag.inhoud,
                    eindDatum = agenda.eindDatum,
                    ID = agenda.ID,
                    naam = agenda.naam,
                    status = agenda.status,
                    beloning=new ANDROIDBeloning()
                };

                ANDROIDBeloning beloning = new ANDROIDBeloning()
                {
                    naam = agenda.beloning.naam,
                    beschrijving = agenda.beloning.beschrijving,
                    ID = agenda.beloning.ID
                };
                agModule.beloning = beloning;

                agModules.Add(agModule);
            }
            return Ok(agModules);
        }
        [HttpGet]
        [ActionName("getAllDossiers")]
        public IHttpActionResult getAllDossierModules()
        {
            List<DossierModule> dossierModule = moduleManager.readAllDossierModules();
            List<ANDROIDDossierModule> dosModule = new List<ANDROIDDossierModule>();

            foreach (var dos in dossierModule)
            {
                ANDROIDDossierModule dosMod = new ANDROIDDossierModule()
                {
                    adminNaam = dos.adminNaam,
                    beginDatum = dos.beginDatum,
                    centralevraag = dos.centraleVraag.inhoud,
                    eindDatum = dos.eindDatum,
                    ID = dos.ID,
                    naam = dos.naam,
                    status = dos.status,
                    beloning=new ANDROIDBeloning(),
                    vasteVraagDrie="aaa",//dos.vasteVraagDrie.inhoud,
                    vasteVraagEen=dos.vasteVraagEen.inhoud,
                    vasteVraagTwee="aaa",//dos.vasteVraagTwee.inhoud,
                    verplichteVolledigheidsPercentage=dos.verplichteVolledigheidsPercentage
                };

                ANDROIDBeloning beloning = new ANDROIDBeloning()
                {
                    beschrijving = dos.beloning.beschrijving,
                    ID = dos.beloning.ID,
                    naam = dos.beloning.naam
                };
                dosMod.beloning = beloning;

                dosModule.Add(dosMod);
            }
            return Ok(dosModule);
        }
        [HttpGet]
        [ActionName("getDossierID")]
        public IHttpActionResult getDossierID(int id)
        {
            List<DossierModule> dossierModules = moduleManager.readAllDossierModules();
            foreach (var dos in dossierModules)
            {
                if (dos.ID == id)
                {
                    ANDROIDDossierModule dosMod = new ANDROIDDossierModule()
                    {
                        adminNaam = dos.adminNaam,
                        beginDatum = dos.beginDatum,
                        eindDatum = dos.eindDatum,
                        ID = dos.ID,
                        naam = dos.naam,
                        status = dos.status,
                        centralevraag = dos.centraleVraag.inhoud,
                        beloning=new ANDROIDBeloning(),
                        vasteVraagDrie = "aaaa",//dos.vasteVraagDrie.inhoud,
                        vasteVraagEen = dos.vasteVraagEen.inhoud,
                        vasteVraagTwee = "aaaa",//dos.vasteVraagTwee.inhoud,
                        verplichteVolledigheidsPercentage = dos.verplichteVolledigheidsPercentage

                    };
                    ANDROIDBeloning bel = new ANDROIDBeloning()
                    {
                        ID = dos.beloning.ID,
                        beschrijving = dos.beloning.beschrijving,
                        naam = dos.beloning.naam
                    };
                    dosMod.beloning = bel;
                    return Ok(dosMod);
                }
            }
            return Ok("Dossier niet gevonden");
        }
        [HttpGet]
        [ActionName("getAgendaID")]
        public IHttpActionResult getAgendaID(int id)
        {
            List<AgendaModule> agendaModules = moduleManager.readAllAgendaModules();
            foreach (var ag in agendaModules)
            {
                if (ag.ID == id)
                {
                    ANDROIDAgendaModule agMod = new ANDROIDAgendaModule()
                    {
                        adminNaam = ag.adminNaam,
                        beginDatum = ag.beginDatum,
                        eindDatum = ag.eindDatum,
                        ID = ag.ID,
                        naam = ag.naam,
                        status = ag.status,
                        centraleVraag = ag.centraleVraag.inhoud,
                        beloning=new ANDROIDBeloning()
                    };
                    ANDROIDBeloning bel = new ANDROIDBeloning()
                    {
                        ID = ag.beloning.ID,
                        beschrijving = ag.beloning.beschrijving,
                        naam = ag.beloning.naam
                    };
                    agMod.beloning = bel;
                    return Ok(agMod);
                }
            }
            return Ok("Agenda niet gevonden");
        }
        [HttpGet]
        [ActionName("getGeslotenDossiers")]
        public IHttpActionResult getGeslotenDossiers()
        {
            List<DossierModule> dossierModules = moduleManager.readGeslotenDossiers();
            List<ANDROIDDossierModule> androidDossiers = new List<ANDROIDDossierModule>();
            foreach (var dos in dossierModules)
            {
                ANDROIDDossierModule dosMod = new ANDROIDDossierModule()
                {
                    adminNaam = dos.adminNaam,
                    beginDatum = dos.beginDatum,
                    centralevraag = dos.centraleVraag.inhoud,
                    eindDatum = dos.eindDatum,
                    ID = dos.ID,
                    naam = dos.naam,
                    status = dos.status,
                    vasteVraagDrie = "aaaaa",//dos.vasteVraagDrie.inhoud,
                    vasteVraagEen = dos.vasteVraagEen.inhoud,
                    vasteVraagTwee = "aaa",//dos.vasteVraagTwee.inhoud,
                    verplichteVolledigheidsPercentage = dos.verplichteVolledigheidsPercentage,
                    beloning=new ANDROIDBeloning()
                    
                };
                ANDROIDBeloning bel = new ANDROIDBeloning()
                {
                    beschrijving = dos.beloning.beschrijving,
                    ID = dos.beloning.ID,
                    naam = dos.beloning.naam
                };
                dosMod.beloning = bel;
                androidDossiers.Add(dosMod);
            }
            if (androidDossiers.Count() == 0)
            {
                return Ok("Geen gesloten dossiers");
            }
            return Ok(androidDossiers);
        }
        [HttpGet]
        [ActionName("getGeslotenAgendas")]
        public IHttpActionResult getGeslotenAgendas()
        {
            List<AgendaModule> agendaDossiers = moduleManager.readGeslotenAgendas();
            List<ANDROIDAgendaModule> androidAgendas = new List<ANDROIDAgendaModule>();
            foreach (var ag in agendaDossiers)
            {
                ANDROIDAgendaModule agMod = new ANDROIDAgendaModule()
                {
                    adminNaam = ag.adminNaam,
                    beginDatum = ag.beginDatum,
                    centraleVraag = ag.centraleVraag.inhoud,
                    eindDatum = ag.eindDatum,
                    ID = ag.ID,
                    naam = ag.naam,
                    status = ag.status,
                    beloning=new ANDROIDBeloning()
                };
                ANDROIDBeloning bel = new ANDROIDBeloning()
                {
                    beschrijving = ag.beloning.beschrijving,
                    ID = ag.beloning.ID,
                    naam = ag.beloning.naam
                };
                agMod.beloning = bel;
                androidAgendas.Add(agMod);
            }
            if (androidAgendas.Count() == 0)
            {
                return Ok("Geen gesloten agendas");
            }
            return Ok(androidAgendas);
        }
        
        #endregion

        #region TOEKOMSTIGE modules
        [HttpGet]
        [ActionName("getToekomst")]
        public IHttpActionResult getToekomstigModules()
        {
            List<Module> modules = moduleManager.readGeplandeModules();
            List<ANDROIDModule> returnModules = new List<ANDROIDModule>();
            foreach (var mod in modules)
            {
                ANDROIDModule module = new ANDROIDModule()
                {
                    adminNaam = mod.adminNaam,
                    beginDatum = mod.beginDatum,
                    centraleVraag = mod.centraleVraag.inhoud,
                    eindDatum = mod.eindDatum,
                    ID = mod.ID,
                    naam = mod.naam,
                    status = mod.status,
                    type = mod.GetType().BaseType.Name,
                    beloning=new ANDROIDBeloning()
                };
                ANDROIDBeloning beloning = new ANDROIDBeloning()
                {
                    beschrijving = mod.beloning.beschrijving,
                    ID = mod.beloning.ID,
                    naam = mod.beloning.naam
                };
                module.beloning = beloning;

                returnModules.Add(module);
            }
            return Ok(returnModules);
        }
        #endregion

    }
}
