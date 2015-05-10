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
        [HttpGet]
        #region ACTIEVE dossier/agenda

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
                centralevraag = actieveDossierModule.centraleVraag.inhoud,
                beloningen = new List<ANDROIDBeloning>()
                /*thema = new Thema()
                //{
                //    ID = actieveDossierModule.thema.ID,
                //    naam = actieveDossierModule.thema.naam,
                //    beschrijving = actieveDossierModule.thema.beschrijving
                }*/
            };

            foreach (var bel in actieveDossierModule.beloning)
            {
                ANDROIDBeloning beloning = new ANDROIDBeloning()
                {
                    naam = bel.naam,
                    beschrijving = bel.beschrijving,
                    ID = bel.ID
                };
                dosModule.beloningen.Add(beloning);
            }
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
                beloningen = new List<ANDROIDBeloning>()
                /*thema = new Thema()
                //{
                //    ID = actieveDossierModule.thema.ID,
                //    naam = actieveDossierModule.thema.naam,
                //    beschrijving = actieveDossierModule.thema.beschrijving
                }*/
            };

            foreach (var bel in actieveAgendaModule.beloning)
            {
                ANDROIDBeloning beloning = new ANDROIDBeloning()
                {
                    naam = bel.naam,
                    beschrijving = bel.beschrijving,
                    ID = bel.ID
                };
                agendaModule.beloningen.Add(beloning);
            }
            agendaModules.Add(agendaModule);
            //var json = JsonConvert.SerializeObject(dosModule);
            //  json = json.Replace(@"\", @"");
            return Ok(agendaModules);
        }
        #endregion


        #region ALL dossier/agenda
        [ActionName("getAllAgendas")]
        public IHttpActionResult getAllAgendaModules()
        {
            List<AgendaModule> agendaModules = moduleManager.readAllAgendaModules();
            List<ANDROIDAgendaModule> agModules = new List<ANDROIDAgendaModule>();

            for (int agenda = 0; agenda < agendaModules.Count()-1;agenda++ )
            {
                ANDROIDAgendaModule agModule = new ANDROIDAgendaModule()
                {
                    adminNaam = agendaModules[agenda].adminNaam,
                    beginDatum = agendaModules[agenda].beginDatum,
                    beloningen = new List<ANDROIDBeloning>(),
                    centraleVraag = "testtest",
                    eindDatum = agendaModules[agenda].eindDatum,
                    ID = agendaModules[agenda].ID,
                    naam = agendaModules[agenda].naam,
                    status = agendaModules[agenda].status
                };
                foreach (var bel in agendaModules[agenda].beloning)
                {
                    ANDROIDBeloning beloning = new ANDROIDBeloning()
                    {
                        naam = bel.naam,
                        beschrijving = bel.beschrijving,
                        ID = bel.ID
                    };
                    agModule.beloningen.Add(beloning);
                }
            }
            return Ok(agModules);
        }

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
                    beloningen = new List<ANDROIDBeloning>(),
                    centralevraag = dos.centraleVraag.inhoud,
                    eindDatum = dos.eindDatum,
                    ID = dos.ID,
                    naam = dos.naam,
                    status = dos.status
                };
                foreach (var bel in dos.beloning)
                {
                    ANDROIDBeloning beloning = new ANDROIDBeloning()
                    {
                        beschrijving = bel.beschrijving,
                        ID = bel.ID,
                        naam = bel.naam
                    };
                }
                dosModule.Add(dosMod);
            }
            return Ok(dosModule);
        }
        #endregion

        /*  #region TOEKOMSTIGE modules
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
                    beloningen = new List<ANDROIDBeloning>(),
                    centraleVraag = mod.centraleVraag.inhoud,
                    eindDatum = mod.eindDatum,
                    ID = mod.ID,
                    naam = mod.naam,
                    status = mod.status
                };
                foreach (var bel in mod.beloning)
                {
                    ANDROIDBeloning beloning = new ANDROIDBeloning()
                    {
                        beschrijving = bel.beschrijving,
                        ID = bel.ID,
                        naam = bel.naam
                    };
                    module.beloningen.Add(beloning);
                }
                returnModules.Add(module);
            }
            return Ok(returnModules);
        }
        #endregion*/

    }
}
