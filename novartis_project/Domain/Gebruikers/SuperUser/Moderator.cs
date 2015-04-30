using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace JPP.BL.Domain.Gebruikers.SuperUser
{
    public class Moderator:Gebruiker
    {
        [Key]
        public int ModeratorID { get; set; }
        public virtual Gebruiker gebruiker { get; set; }

        
    }
}
