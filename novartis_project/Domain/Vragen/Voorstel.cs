using JPP.BL.Domain.Antwoorden;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPP.BL.Domain.Vragen
{
    public class Voorstel
    {
        public int ID { get; set; }
        public string inhoud { get; set; }
        public string extraInfo { get; set; }
        public DateTime datum { get; set; }
        public int aantalStemmen { get; set; }
        public Boolean editable { get; set; }
        public string gebruikersNaam { get; set; }
        public int centraleVraagID { get; set; }

        public virtual ICollection<VasteTag> vasteTags { get; set; }
    }
}
