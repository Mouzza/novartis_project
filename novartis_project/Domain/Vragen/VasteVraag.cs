using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JPP.BL.Domain.Antwoorden;

namespace JPP.BL.Domain.Vragen
{
    public class VasteVraag
    {
        public int ID { get; set; }
        public String inhoud { get; set; }
        public string extraInfo { get; set; }
        public Boolean boolVerplicht { get; set; }
        public virtual ICollection<VasteVraagAntwoord> vasteVraagAntwoorden { get; set; }
    }
}
