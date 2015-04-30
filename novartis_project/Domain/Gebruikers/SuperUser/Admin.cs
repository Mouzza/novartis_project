using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace JPP.BL.Domain.Gebruikers.SuperUser
{
    public class Admin:Gebruiker
    {
        [Key]
        public int AdminID {get; set;}
        public virtual Gebruiker gebruiker {get; set;}

    }
}
