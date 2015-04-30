using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JPP.BL.Domain.Gebruikers;
using System.ComponentModel.DataAnnotations;

namespace JPP.BL.Domain.Modules
{
    public class Organisatie
    {
        [Key]
        public int organisatieID { get; set; }
        public string naam { get; set; }
        public string gemeente { get; set; }
        //check if uri = url
        public string url { get; set; }
        public string imagePathname { get; set; }
        public List<Gebruiker> gebruikers { get; set; }
        public ICollection<Module> modules { get; set; }


    }
}
