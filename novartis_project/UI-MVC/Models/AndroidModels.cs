using JPP.BL.Domain.Antwoorden;
using JPP.BL.Domain.Modules;
using JPP.BL.Domain.Vragen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;


namespace JPP.UI.Web.MVC.Models
{
    public class AndroidModels
    {



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
        public List<ANDROIDDossierAntwoord> dossierAntwoorden { get; set; }
        public string vasteVraagEen { get; set; }
        public string vasteVraagTwee { get; set; }
        public string vasteVraagDrie { get; set; }
        public double verplichteVolledigheidsPercentage { get; set; }
        //public Thema thema { get; set; }
    }
    public class ANDROIDBeloning
    {
        public int ID { get; set; }
        public string naam { get; set; }
        public string beschrijving { get; set; }

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
        public List<ANDROIDAgendaAntwoord> agendaAntwoorden { get; set; }
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
        public string type { get; set; }

        //public Thema thema { get; set; }
    }
    public class ANDROIDAgendaAntwoord
    {
        public int ID { get; set; }
        public string titel { get; set; }
        public string subTitel { get; set; }
        public string inhoud { get; set; }
        public string extraInfo { get; set; }
        public DateTime datum { get; set; }
        public string gebruikersNaam { get; set; }
        public int moduleID { get; set; }
        public Boolean statusOnline { get; set; }
        public Boolean isActieveModule { get; set; }
        public List<ANDROIDstem> stemmen { get; set; }
        public List<ANDROIDVasteTag> vasteTags { get; set; }
        public List<ANDROIDFlag> flags { get; set; }
        public int aantalStemmen { get; set; }
        public int aantalFlags { get; set; }

    }
    public class ANDROIDDossierAntwoord
    {
        public int ID { get; set; }
        public string titel { get; set; }
        public string subtitel { get; set; }
        public string inhoud { get; set; }
        public string extraInfo { get; set; }
        public DateTime datum { get; set; }
        public string gebruikersNaam { get; set; }
        public int moduleID { get; set; }
        public List<ANDROIDVasteTag> vasteTags { get; set; }
        public byte[] afbeeldingByte { get; set; }
        public int percentageVolledigheid { get; set; }
        public Boolean statusOnline { get; set; }
        //public List<ANDROIDComment> comments { get; set; }
        public string textvak2 { get; set; }
        public string textvak3 { get; set; }
        public string extraVraag { get; set; }
        public string googleMapsAdress { get; set; }
        public string foregroundColor { get; set; }
        public string backgroundColor { get; set; }
        public string backgroundImage { get; set; }
        public Boolean isActieveModule { get; set; }
        public List<ANDROIDstem> stemmen { get; set; }
        public List<ANDROIDFlag> flags { get; set; }
        public int aantalStemmen { get; set; }
        public int aantalFlags { get; set; }

    }

    //*********************************************
    public class ANDROIDComment
    {
        public int ID { get; set; }
        public string inhoud { get; set; }
        public DateTime datum { get; set; }
        public int aantalStemmen { get; set; }
        public string gebruikersNaam { get; set; }
    }
    public class ANDROIDEvenement
    {
        public int ID { get; set; }
        public string title { get; set; }
        public string evenementText { get; set; }
        public string locatie { get; set; }
        public DateTime startDatum { get; set; }
        public DateTime eindDatum { get; set; }
        public string urlFacebookEvent { get; set; }
    }
    public class ANDROIDGebruiker
    {

        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public int Zipcode { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        //public Boolean active { get; set; }
    }
    public class ANDROIDstem
    {
        public int antwoordid { get; set; }
        public string gebruikersNaam { get; set; }
    }
    public class ANDROIDFlag
    {
        public int antwoordid { get; set; }
        public string gebruikersNaam { get; set; }
    }
    public class ANDROIDLoginView
    {
        public string Name { get; set; }
        public string Password { get; set; }
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
    public class ANDROIDImage
    {
        public string imageBytes { get; set; }
    }
}