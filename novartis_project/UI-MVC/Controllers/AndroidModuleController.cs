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
            List<ANDROIDDossierModule> dossierModules = new List<ANDROIDDossierModule>();
            ANDROIDDossierModule dosModule = new ANDROIDDossierModule()
            {
                ID = actieveDossierModule.ID,
                naam = actieveDossierModule.naam,
                beginDatum = actieveDossierModule.beginDatum,
                eindDatum = actieveDossierModule.eindDatum,
                adminNaam = actieveDossierModule.adminNaam,
                status = actieveDossierModule.status,
                centralevraag = actieveDossierModule.centraleVraag.inhoud
             
                /*thema = new Thema()
                //{
                //    ID = actieveDossierModule.thema.ID,
                //    naam = actieveDossierModule.thema.naam,
                //    beschrijving = actieveDossierModule.thema.beschrijving
                }*/
            };

          
                ANDROIDBeloning beloning = new ANDROIDBeloning()
                {
                    naam = actieveDossierModule.beloning.naam,
                    beschrijving = actieveDossierModule.beloning.beschrijving,
                    ID = actieveDossierModule.beloning.ID
                };
                dosModule.beloning = beloning;
            
            dossierModules.Add(dosModule);
            //var json = JsonConvert.SerializeObject(dosModule);
            //  json = json.Replace(@"\", @"");
            return Ok(dossierModules);
        }
        [HttpGet]
        [ActionName("getActieveAgenda")]
        public IHttpActionResult getActieveAgendaModule()
        {
            AgendaModule actieveAgendaModule = moduleManager.readActieveAgendaModule();
            List<ANDROIDAgendaModule> agendaModules = new List<ANDROIDAgendaModule>();
            ANDROIDAgendaModule agendaModule = new ANDROIDAgendaModule()
            {
                ID = actieveAgendaModule.ID,
                naam = actieveAgendaModule.naam,
                beginDatum = actieveAgendaModule.beginDatum,
                eindDatum = actieveAgendaModule.eindDatum,
                adminNaam = actieveAgendaModule.adminNaam,
                status = actieveAgendaModule.status,
                centraleVraag = actieveAgendaModule.centraleVraag.inhoud,
               
                /*thema = new Thema()
                //{
                //    ID = actieveDossierModule.thema.ID,
                //    naam = actieveDossierModule.thema.naam,
                //    beschrijving = actieveDossierModule.thema.beschrijving
                }*/
            };

           
                ANDROIDBeloning beloning = new ANDROIDBeloning()
                {
                    naam = actieveAgendaModule.beloning.naam,
                    beschrijving = actieveAgendaModule.beloning.beschrijving,
                    ID = actieveAgendaModule.beloning.ID
                };
                agendaModule.beloning = beloning;
         
            agendaModules.Add(agendaModule);
            //var json = JsonConvert.SerializeObject(dosModule);
            //  json = json.Replace(@"\", @"");
            return Ok(agendaModules);
        }
        #endregion

        #region ALL dossier/agenda
        [HttpGet]
        [ActionName("getAllAgendas")]
        public IHttpActionResult getAllAgendaModules()
        {
            List<AgendaModule> agendaModules = moduleManager.readAllAgendaModules();
            List<ANDROIDAgendaModule> agModules = new List<ANDROIDAgendaModule>();

            foreach(var agenda in agendaModules)
            {
                ANDROIDAgendaModule agModule = new ANDROIDAgendaModule()
                {
                    adminNaam = agenda.adminNaam,
                    beginDatum = agenda.beginDatum,
                    centraleVraag = agenda.centraleVraag.inhoud,
                    eindDatum = agenda.eindDatum,
                    ID = agenda.ID,
                    naam = agenda.naam,
                    status = agenda.status
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
                    status = dos.status
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
                        adminNaam=dos.adminNaam,
                        beginDatum=dos.beginDatum,
                        eindDatum=dos.eindDatum,
                        ID=dos.ID,
                        naam=dos.naam,
                        status=dos.status,
                        centralevraag=dos.centraleVraag.inhoud,
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
                        centraleVraag=ag.centraleVraag.inhoud
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
                    adminNaam=dos.adminNaam,
                    beginDatum=dos.beginDatum,
                    centralevraag=dos.centraleVraag.inhoud,
                    eindDatum=dos.eindDatum,
                    ID=dos.ID,
                    naam=dos.naam,
                    status=dos.status
                };
                ANDROIDBeloning bel = new ANDROIDBeloning()
                {
                    beschrijving=dos.beloning.beschrijving,
                    ID=dos.beloning.ID,
                    naam=dos.beloning.naam
                };
                dosMod.beloning = bel;
                androidDossiers.Add(dosMod);
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
                    centraleVraag=ag.centraleVraag.inhoud,
                    eindDatum = ag.eindDatum,
                    ID = ag.ID,
                    naam = ag.naam,
                    status = ag.status
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
                    type=mod.GetType().BaseType.Name
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
