using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace JPP.BL.Domain.Gebruikers
{
    public class Gebruiker:IGebruiker
    {
        [Key]
        public int id { get; set; }

        public string gebruikersnaam { get; set; }

        public string voornaam { get; set; }

        public string achternaam { get; set; }

        public DateTime geboorteDatum { get; set; }

        public int postcode { get; set; }

        public string wachtwoord { get; set; }

        public string email { get; set; }

        public int telefoonnummer { get; set; }

        public Boolean active { get; set; }
    }
}
