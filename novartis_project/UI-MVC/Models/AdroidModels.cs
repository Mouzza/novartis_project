using JPP.BL.Domain.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JPP.UI.Web.MVC.Models
{
    public class AdroidModels
    {

        

    }
    public class ANDROIDDossierModule
    {
        public int ID { get; set; }
        public string naam { get; set; }
        public Boolean status { get; set; }
        public DateTime beginDatum { get; set; }
        public DateTime eindDatum { get; set; }

        public string adminNaam { get; set; }

        public Thema thema { get; set; }
    }
    
        
}