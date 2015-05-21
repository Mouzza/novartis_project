using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPP.BL.Domain.Antwoorden
{
    public class VasteTag
    {
        [Key]
        public int ID { get; set; }
        public string naam { get; set; }
        public string beschrijving { get; set; }
        public virtual ICollection<Antwoord> antwoorden { get; set; }
    }
}
