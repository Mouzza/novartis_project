using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace JPP.BL.Domain.Antwoorden
{
    public class DossierAntwoord:Antwoord
    {
        public string afbeeldingPath { get; set; }
        public int percentageVolledigheid { get; set; }
        public Boolean statusOnline { get; set; }
        public string extraVraag { get; set; }
        

        public virtual Evenement evenement { get; set; }
        public virtual ICollection<Comment> comments { get; set; }
    }
}
