using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace JPP.BL.Domain.Gebruikers.Beheerder
{
    public class Medebeheerder:Gebruiker
    {
        [Key]
        public int Medebeheerderid { get; set; }

        public virtual Gebruiker gebruiker { get; set; }

        public int beheerderID { get; set; }
    }
}
