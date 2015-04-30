using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace JPP.BL.Domain.Antwoorden
{
    public class Comment
    {
        [Key]
        public int ID { get; set; }
        public string inhoud { get; set; }
        public DateTime datum { get; set; }
        public int aantalStemmen { get; set; }
        public string gebruikersNaam { get; set; }
    }
}
