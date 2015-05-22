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
        /* erft over van Module maar voegt een aantal individuele attributen toe */

        public virtual VasteVraag vasteVraagEen { get; set; }
        public virtual VasteVraag vasteVraagTwee { get; set; }
        public virtual VasteVraag vasteVraagDrie { get; set; }
        public virtual ICollection<DossierAntwoord> dossierAntwoorden { get; set; }
        public double verplichteVolledigheidsPercentage { get; set; }
    }
}
