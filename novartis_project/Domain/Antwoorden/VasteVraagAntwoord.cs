using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JPP.BL.Domain.Vragen;

namespace JPP.BL.Domain.Antwoorden
{
    public class VasteVraagAntwoord
    {
        public int ID { get; set; }
        public String inhoud { get; set; }
        public VasteVraag vasteVraag { get; set; }
    }
}
