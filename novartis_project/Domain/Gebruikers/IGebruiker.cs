using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPP.BL.Domain.Gebruikers
{
    public interface IGebruiker
    {
        int id { get; set; }
        string gebruikersnaam { get; set; }
        string voornaam { get; set; }
        string achternaam { get; set; }
        DateTime geboorteDatum { get; set; }
        int postcode { get; set; }
        string wachtwoord { get; set; }
        string email { get; set; }
        int telefoonnummer { get; set; }

    }
}
