using JPP.BL;
using JPP.BL.Domain.Antwoorden;
using JPP.BL.Domain.Modules;
using JPP.UI.Web.MVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JPP.UI.Web.MVC.Controllers
{
    public class AndroidModuleController : Controller
    {


        ModuleManager moduleManager = new ModuleManager();
 


        //// GET  http://localhost:44302/AndroidModule/ActieveModule
        [HttpGet]
        public JsonResult ActieveModule()
        {
            //DossierModule actieveDossierModule = moduleManager.readAllDossierModules().Where(dmod => dmod.status == true).First();

            DossierModule actieveDossierModule = moduleManager.readActieveDossierModule();

          
            ANDROIDDossierModule dosModule = new ANDROIDDossierModule()
            {
                ID = actieveDossierModule.ID,
                naam = actieveDossierModule.naam,
                beginDatum = actieveDossierModule.beginDatum,
                eindDatum = actieveDossierModule.eindDatum,
                adminNaam = actieveDossierModule.adminNaam,
                status = actieveDossierModule.status,
                thema = new Thema()
                {
                    ID=actieveDossierModule.thema.ID,
                    naam=actieveDossierModule.thema.naam,
                    beschrijving=actieveDossierModule.thema.beschrijving
                }

            };


            var json = JsonConvert.SerializeObject(dosModule,new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            json = json.Replace("\"", "");
            return Json(json, JsonRequestBehavior.AllowGet);

        }
    }
}