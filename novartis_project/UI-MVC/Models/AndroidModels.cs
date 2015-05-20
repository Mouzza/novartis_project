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
        public  string vasteVraagEen { get; set; }
        public  string vasteVraagTwee { get; set; }
        public  string vasteVraagDrie { get; set; }
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
        public string gebruikersNaam { get; set; }
        public int aantalFlags { get; set; }
        public string subTitel { get; set; }
        public int moduleID { get; set; }

        public Boolean statusOnline { get; set; }
        public Boolean isActieveModule { get; set; }
        //public List<ANDROIDVasteTag> vasteTags { get; set; }
        //public List<ANDROIDPersoonlijkeTag> persoonlijkeTags { get; set; }

       // public List<ANDROIDVasteTag> vasteTags { get; set; }
       // public List<ANDROIDPersoonlijkeTag> persoonlijkeTags { get; set; }


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
        public string gebruikersNaam { get; set; }
        public int aantalFlags { get; set; }
        public int moduleID { get; set; }
        //public List<ANDROIDVasteTag> vasteTags { get; set; }
        //public List<ANDROIDPersoonlijkeTag> persoonlijkeTags { get; set; }
        public string afbeeldingPath { get; set; }
        //public byte[] afbeeldingBytes { get; set; }
        public int percentageVolledigheid { get; set; }
        public Boolean statusOnline { get; set; }
        public List<ANDROIDComment> comments { get; set; }
        public string textvak2 { get; set; }
        public string textvak3 { get; set; }
        public string extraVraag { get; set; }
        public int evenementID { get; set; }
        public string googleMapsAdress { get; set; }
        public string subtitel { get; set; }
        public string foregroundColor { get; set; }
        public string backgroundColor { get; set; }
        public string backgroundImage { get; set; }
        public Boolean isActieveModule { get; set; }
    }

    //***********************************************************
    public class UserModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; }
    }

    //*********************************************

    public class AndroidGebruiker
    {
        public int id { get; set; }
        [Required]
        [StringLength(12, ErrorMessage = "{0} moet minstens {2} karakters en max 12 karakters lang zijn. ", MinimumLength = 6)]
        [Display(Name = "Gebruikersnaam")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Voornaam")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Achternaam")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Geboortedatum")]
        public DateTime Birthday { get; set; }
        [Required]
        [Display(Name = "Postcode")]
        public int Zipcode { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "{0} moet minstens {2} karakters lang zijn.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Wachtwoord")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Herhaal wachtwoord")]
        [Compare("Password", ErrorMessage = "Het wachtwoord en confirmatie wachtwoord komen niet overeen.")]
        public string ConfirmPassword { get; set; }
        public Boolean active { get; set; }
    }
}



