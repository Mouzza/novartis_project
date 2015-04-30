using JPP.BL.Domain;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using JPP.BL.Domain.Modules;
using JPP.BL.Domain.Vragen;

namespace JPP.UI.Web.MVC.Models
{
    public class DossiermoduleView
    {
        public DossierModule dossiermodule { get; set; }
        public VasteVraag vasteVraag { get; set; }

    }

}