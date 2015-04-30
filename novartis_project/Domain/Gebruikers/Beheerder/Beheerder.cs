using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using JPP.BL.Domain.Antwoorden;


namespace JPP.BL.Domain.Gebruikers.Beheerder
{
    public class Beheerder
    {
        public virtual Gebruiker gebruiker { get; set; }
        [Key]
        public int BeheerderID { get; set; }
        public virtual ICollection<Antwoord> antwoord { get; set; }
        public virtual ICollection<Medebeheerder> medebeheerder { get; set; }

        
    }
}
