using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using JPP.BL.Domain.Gebruikers;

namespace JPP.BL.Domain
{
    public class ExpertVraag
    {
        [Key]
        public int ID { get; set; }
        public string vraag { get; set; }
        public string expertNaam { get; set; }

    }
}
