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
        public IHttpActionResult ActieveDossierModule()
        {


            DossierModule actieveDossierModule = moduleManager.readActieveDossierModule();

            List<ANDROIDDossierModule> modules = new List<ANDROIDDossierModule>();

            
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
                
                //thema = new Thema()
                //{
                //    ID = actieveDossierModule.thema.ID,
                //    naam = actieveDossierModule.thema.naam,
                //    beschrijving = actieveDossierModule.thema.beschrijving
                //}

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


            modules.Add(dosModule);

            //var json = JsonConvert.SerializeObject(dosModule);

            //  json = json.Replace(@"\", @"");

            return Ok(modules);
        }
    }
    
}
