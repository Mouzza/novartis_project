using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using JPP.BL.Domain.Vragen;

namespace JPP.BL.Domain.Antwoorden
{
    public class Tag
    {
        [Key]
        public int ID { get; set; }
        public string naam { get; set; }
        public string beschrijving { get; set; }
        public virtual ICollection<Antwoord> antwoorden { get; set; }
        public virtual ICollection<Voorstel> voorstellen { get; set; }
        /*public List<Tag> tags { get; set; }
        public List<PersoonlijkeTag> persoonlijkeTags { get; set; }
         * */
    }
}
