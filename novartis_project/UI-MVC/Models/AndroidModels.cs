using JPP.BL.Domain.Antwoorden;
using JPP.BL.Domain.Modules;
using JPP.BL.Domain.Vragen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JPP.UI.Web.MVC.Models
{
    public class AndroidModels
    {

        

    }

    
    public class ANDROIDBeloning
    {
        public int ID { get; set; }
        public string naam { get; set; }
        public string beschrijving { get; set; }
        //public Thema thema { get; set; }
    }
    public class ANDROIDDossierModule
    {
        public int ID { get; set; }
        public string naam { get; set; }
        public Boolean status { get; set; }
        public DateTime beginDatum { get; set; }
        public DateTime eindDatum { get; set; }
        public string centralevraag { get; set; }
        public string adminNaam { get; set; }

        public ANDROIDBeloning beloning { get; set; }
        //public Thema thema { get; set; }
    }

    public class ANDROIDAgendaModule
    {
        public int ID { get; set; }
        public string naam { get; set; }
        public Boolean status { get; set; }
        public DateTime beginDatum { get; set; }
        public DateTime eindDatum { get; set; }
        public string adminNaam { get; set; }
        public string centraleVraag { get; set; }
        public ANDROIDBeloning beloning { get; set; }
        //public Thema thema { get; set; }
    }
    public class ANDROIDModule
    {
        public int ID { get; set; }
        public string naam { get; set; }
        public Boolean status { get; set; }
        public DateTime beginDatum { get; set; }
        public DateTime eindDatum { get; set; }
        public string centraleVraag { get; set; }
        public string adminNaam { get; set; }

        public ANDROIDBeloning beloning { get; set; }

        public List<ANDROIDBeloning> beloningen { get; set; }
        public string type { get; set; }

        //public Thema thema { get; set; }
    }

    public class ANDROIDVasteTag
    {
        public int ID { get; set; }
        public string naam { get; set; }
        public string beschrijving { get; set; }
    }
    public class ANDROIDPersoonlijkeTag
    {
        public int ID { get; set; }
        public string naam { get; set; }
        public string beschrijving { get; set; }
    }
    public class ANDROIDAgendaAntwoord
    {
        public int ID { get; set; }
        public string titel { get; set; }
        public string inhoud { get; set; }
        public string extraInfo { get; set; }
        public DateTime datum { get; set; }
        public int aantalStemmen { get; set; }
        public Boolean editable { get; set; }
        public string gebruikersNaam { get; set; }
        public int aantalFlags { get; set; }
        public int moduleID { get; set; }
        public List<ANDROIDVasteTag> vasteTags { get; set; }
        public List<ANDROIDPersoonlijkeTag> persoonlijkeTags { get; set; }
    }
    public class ANDROIDComment
    {
        public int ID { get; set; }
        public string inhoud { get; set; }
        public DateTime datum { get; set; }
        public int aantalStemmen { get; set; }
        public string gebruikersNaam { get; set; }
    }
    public class ANDROIDDossierAntwoord
    {
        public int ID { get; set; }
        public string titel { get; set; }
        public string inhoud { get; set; }
        public string extraInfo { get; set; }
        public DateTime datum { get; set; }
        public int aantalStemmen { get; set; }
        public Boolean editable { get; set; }
        public string gebruikersNaam { get; set; }
        public int aantalFlags { get; set; }
        public int moduleID { get; set; }
        public List<ANDROIDVasteTag> vasteTags { get; set; }
        public List<ANDROIDPersoonlijkeTag> persoonlijkeTags { get; set; }
        public string afbeeldingPath { get; set; }
        public int percentageVolledigheid { get; set; }
        public Boolean statusOnline { get; set; }
        public string extraVraag { get; set; }
        public int evenementID { get; set; }
        public List<ANDROIDComment> comments { get; set; }
    }
        
}