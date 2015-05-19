using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPP.BL.Domain.Antwoorden
{
    public class Stem
    {
        [Key]
        public int ID { get; set; }

        public Antwoord antwoord { get; set; }
        public string gebruikersNaam { get; set; }
    }
}
