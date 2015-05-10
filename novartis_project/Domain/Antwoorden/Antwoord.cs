using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using JPP.BL.Domain.Modules;
using JPP.BL.Domain.Gebruikers;

namespace JPP.BL.Domain.Antwoorden
{
    public class Antwoord
    {
        [Key]
        public int ID { get; set; }
        public string titel { get; set; }
        public string subtitel { get; set; }
        public string inhoud { get; set; } //Textvak 1
        public string extraInfo { get; set; }
        public DateTime datum { get; set; }
        public int aantalStemmen { get; set; }
        public Boolean editable { get; set; }
        public string gebruikersNaam { get; set; }
        public int aantalFlags { get; set; }
        public virtual Module module { get; set; }
     

        public virtual ICollection<VasteTag> vasteTags { get; set; }
        public virtual ICollection<PersoonlijkeTag> persoonlijkeTags { get; set; }
    }
}
