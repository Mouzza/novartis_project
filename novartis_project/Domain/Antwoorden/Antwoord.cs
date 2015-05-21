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
        [Required]
        [StringLength(30, ErrorMessage = "Het veld {0} moet minstens {2} karakters en max 30 karakters lang zijn. ", MinimumLength = 3)]
        public string titel { get; set; }
        [Required]
        [StringLength(40, ErrorMessage = "Het veld {0} moet minstens {2} karakters en max 30 karakters lang zijn. ", MinimumLength = 3)]
        public string subtitel { get; set; }
        [Required]
        [StringLength(250, ErrorMessage = "Het veld {0} moet minstens {2} karakters en max 250 karakters lang zijn. ", MinimumLength = 3)]
        public string inhoud { get; set; } //Textvak 1
        public string extraInfo { get; set; }
        public DateTime datum { get; set; }
        public string gebruikersNaam { get; set; }
        public Boolean statusOnline { get; set; }
        public virtual ICollection<Evenement> evenementen { get; set; }
        public virtual Module module { get; set; }
        public virtual ICollection<Stem> stemmen { get; set; }
        public virtual ICollection<Flag> flags { get; set; }
        public virtual ICollection<VasteTag> vasteTags { get; set; }
        public virtual ICollection<PersoonlijkeTag> persoonlijkeTags { get; set; }
    }
}
