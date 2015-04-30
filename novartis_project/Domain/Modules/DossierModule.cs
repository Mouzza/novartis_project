using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using JPP.BL.Domain.Antwoorden;
using JPP.BL.Domain.Vragen;

namespace JPP.BL.Domain.Modules
{
    public class DossierModule:Module
    {
        public virtual  ICollection<VasteVraag> vasteVragen { get; set; }
        public virtual ICollection<DossierAntwoord> dossierAntwoorden { get; set; }
        public double verplichteVolledigheidsPercentage { get; set; }
    }
}
