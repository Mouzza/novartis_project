using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JPP.BL.Domain;
using System.ComponentModel.DataAnnotations;

namespace JPP.BL.Domain.Gebruikers.SuperUser
{
    public class SuperAdmin:Gebruiker
    {
        [Key]
        public int SuperAdminID { get; set; }

        public virtual Gebruiker gebruiker { get; set; }
    }
}
