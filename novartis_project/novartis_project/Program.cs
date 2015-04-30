using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JPP.BL.Domain.Gebruikers;
using JPP.BL.Domain.Gebruikers.Beheerder;
using JPP.BL.Domain.Gebruikers.SuperUser;
using JPP.BL.Domain.Antwoorden;

namespace novartis_project
{
   /* class Program
    {
        public static IngelogdeGebruikerSC ingelogdegebr = new IngelogdeGebruikerSC();
        
        static void Main(string[] args)
        {
            
            //var ingelogdegebr = new IngelogdeGebruikerSC();
            ShowMenuInloggen();


        }

        private static void ShowMenuIngelogdeGebruiker()
        {
            Console.WriteLine("1) GetGebruiker");
            Console.WriteLine("2) GetBeheerder");
            Console.WriteLine("3) GetMedebeheerder");
            Console.WriteLine("4) GetAdmin");
            Console.WriteLine("5) GetSuperAdmin");
            Console.WriteLine("6) GetModerator");
            Console.WriteLine("7) GetExpert");
            Console.WriteLine("8) GetAntwoord");
            Console.WriteLine("9) Delete gebruiker");

            Console.WriteLine("0) Exit");
        }
        
        private static void ShowMenu()
        {
            
            Console.WriteLine("1) GetGebruiker");
            Console.WriteLine("2) GetBeheerder");
            Console.WriteLine("3) GetMedebeheerder");
            Console.WriteLine("4) GetAdmin");
            Console.WriteLine("5) GetSuperAdmin");
            Console.WriteLine("6) GetModerator");
            Console.WriteLine("7) GetExpert");
            Console.WriteLine("8) GetAntwoord");

            Console.WriteLine("0) Exit");
        }

        private static void ShowMenuInloggen()
        {
            Console.WriteLine("1) Doorgaan");
            Console.WriteLine("2) Log In");
            Console.WriteLine("3) Register");

            Console.WriteLine("0) Exit");

            string keuze;

            keuze = Console.ReadLine();
            int keuzeint = Convert.ToInt32(keuze);
            Console.Clear();
            switch (keuzeint)
            {
                case 1:
                     int menuact = 1;
                     while (menuact != 0)
                     {
                         ShowMenu();
                         string reader = Console.ReadLine();
                         int readint = Convert.ToInt32(reader);
                         menuact = DetectMenuAction(readint);
                     }
                    break;
                case 2:
                    Inloggen();
                    break;
                case 3:
                    Register();
                    break;
                default:
                    Console.WriteLine("Exit!");
                    break;
            }
        }

        private static void Inloggen()
        {
            NietIngelogdeGebruikerSC nietingelogdegebr = new NietIngelogdeGebruikerSC();
            string reader;
            Console.Clear();
            Console.Write("\nGebruikersnaam: ");
            reader = Console.ReadLine();
            string gebruikersNaam = reader;
            Console.Write("\nWachtwoord: ");
            reader = Console.ReadLine();
            string wachtwoord = reader;

            Gebruiker gebr = new Gebruiker();
            gebr = nietingelogdegebr.getGebruiker(gebruikersNaam);
            if (gebr != null)
            {
                Console.WriteLine("Welkom " + gebr.gebruikersnaam + " Met ID: " + gebr.id);
                int menuact = 1;
                while (menuact != 0)
                {
                    ShowMenuIngelogdeGebruiker();
                    reader = Console.ReadLine();
                    int readint = Convert.ToInt32(reader);
                    menuact = DetectMenuAction(readint);
                }
            }
        }

        private static void Register()
        {
            NietIngelogdeGebruikerSC nietingelogdegebr = new NietIngelogdeGebruikerSC();
            Gebruiker gebr = new Gebruiker();
            Gebruiker gebreen = new Gebruiker();
            string reader;
            Console.Clear();
            Console.Write("\nGeef een gebruikersnaam: ");
            reader = Console.ReadLine();
            gebr.gebruikersnaam = reader;
            Console.Write("\nGeef een Wachtwoord: ");
            reader = Console.ReadLine();
            gebr.wachtwoord = reader;
            Console.Write("\nGeef uw Voornaam: ");
            reader = Console.ReadLine();
            gebr.voornaam = reader;
            Console.Write("\nGeef uw Achternaam: ");
            reader = Console.ReadLine();
            gebr.achternaam = reader;
            Console.Write("\nGeef uw GeboorteDatum: ");
            reader = Console.ReadLine();
            gebr.geboorteDatum = Convert.ToDateTime(reader);
            Console.Write("\nGeef uw PostCode: ");
            reader = Console.ReadLine();
            gebr.postcode = Convert.ToInt32(reader);
            Console.Write("\nGeef uw Email: ");
            reader = Console.ReadLine();
            gebr.email = reader;
            Console.Write("\nGeef uw telefoonnummer: ");
            reader = Console.ReadLine();
            gebr.telefoonnummer = Convert.ToInt32(reader);

            gebreen = nietingelogdegebr.createGebruiker(gebr);

            Console.WriteLine("Bedankt om uw te registreren " + gebreen.gebruikersnaam + " " + "Met Id " + gebreen.id);
            int menuact = 1;
            while (menuact != 0)
            {
                ShowMenuIngelogdeGebruiker();
                reader = Console.ReadLine();
                int readint = Convert.ToInt32(reader);
                menuact = DetectMenuAction(readint);
            }
        }

        private static int DetectMenuAction(int menuAction)
        {
            int menuaction = 1;
            string reader = "";
            int id;
            Console.Clear();
            
            switch (menuAction)
            {
                case 1: 
                    Console.Write("\nGeef gebruiker ID: ");
                    reader = Console.ReadLine();
                    id = Convert.ToInt32(reader);
                    Gebruiker gebruiker = ingelogdegebr.getGebruiker(id);
                    Console.WriteLine(String.Format("\nId: {0}\nGebruikersnaam: {1} \nVoornaam: {2} \nAchternaam: {3} \nGeboorteDatum: {4} ", gebruiker.id, gebruiker.gebruikersnaam, gebruiker.voornaam, gebruiker.achternaam, gebruiker.geboorteDatum));
                    break;
                
                case 2:
                    Console.Write("\nGeef gebruiker ID: ");
                    reader = Console.ReadLine();
                    id = Convert.ToInt32(reader);
                    Beheerder beheerder = ingelogdegebr.getBeheerder(id);
                    Console.WriteLine(String.Format("\nId: {0}\nVoornaam: {1} \nAchternaam: {2}", beheerder.id, beheerder.voornaam, beheerder.achternaam));
                    break;
                case 3:
                    Console.Write("\nGeef gebruiker ID: ");
                    reader = Console.ReadLine();
                    id = Convert.ToInt32(reader);
                    Medebeheerder medebeheerder = ingelogdegebr.getMedebeheerder(id);
                    Console.WriteLine(String.Format("\nId: {0}\nBeheerderID: {1}", medebeheerder.id, medebeheerder.beheerderID));
                    break;
                case 4:
                    Console.Write("\nGeef gebruiker ID: ");
                    reader = Console.ReadLine();
                    id = Convert.ToInt32(reader);
                    Admin admin = ingelogdegebr.getAdmin(id);
                    Console.WriteLine(String.Format("\nId: {0}\nVoornaam: {1} \nAchternaam: {2}", admin.id, admin.voornaam, admin.achternaam));
                    break;
                case 5:
                    Console.Write("\nGeef gebruiker ID: ");
                    reader = Console.ReadLine();
                    id = Convert.ToInt32(reader);
                    SuperAdmin SA = ingelogdegebr.getSuperAdmin(id);
                    Console.WriteLine(String.Format("\nId: {0}\nVoornaam: {1} \nAchternaam: {2}", SA.id, SA.voornaam, SA.achternaam));
                    break;
                case 6:
                    Console.Write("\nGeef gebruiker ID: ");
                    reader = Console.ReadLine();
                    id = Convert.ToInt32(reader);
                    Moderator moderator = ingelogdegebr.getModerator(id);
                    Console.WriteLine(String.Format("\nId: {0}\nVoornaam: {1} \nAchternaam: {2}", moderator.id, moderator.voornaam, moderator.achternaam));
                    break;
                case 7:
                    Console.Write("\nGeef gebruiker ID: ");
                    reader = Console.ReadLine();
                    id = Convert.ToInt32(reader);
                    Expert expert = ingelogdegebr.getExpert(id);
                    Console.WriteLine(String.Format("\nId: {0}\nVoornaam: {1} \nAchternaam: {2}", expert.id, expert.voornaam, expert.achternaam));
                    break;
                case 8:
                    Console.Write("\nGeef Antwoord ID: ");
                    reader = Console.ReadLine();
                    id = Convert.ToInt32(reader);
                    Antwoord antwoord = ingelogdegebr.getAntwoord(id);
                    DossierAntwoord dosantwoord;

                    if (antwoord is AgendaAntwoord)
                    {

                        Console.WriteLine(String.Format("\nAgenda Antwoord\nId: {0}\nInhoud: {1} \nextraInfo: {2}\ndatum: {3} \naantalStemmen: {4} \neditable: {5} \ngebruikerID: {6}, antwoord.antwoordID, antwoord.inhoud, antwoord.extraInfo, antwoord.datum, antwoord.aantalStemmen, antwoord.editable, antwoord.gebruikerID"));
                    }
                    else
                    {
                        dosantwoord = (DossierAntwoord)antwoord;
                        Console.WriteLine(String.Format("\nDossier Antwoord\nId: {0}\nInhoud: {1} \nextraInfo: {2}\ndatum: {3} \naantalStemmen: {4} \neditable: {5} \ngebruikerID: {6} \nAfbeeldingPath: {7} \npercentageVolledigheid: {8} \nStatusOnline: {9} \nExtravraag: {10} \nCommentID: {11}, dosantwoord.antwoordID, dosantwoord.inhoud, dosantwoord.extraInfo, dosantwoord.datum, dosantwoord.aantalStemmen, dosantwoord.editable, dosantwoord.gebruikerID, dosantwoord.afbeeldingPath, dosantwoord.percentageVolledigheid, dosantwoord.statusOnline, dosantwoord.extraVraag, dosantwoord.commentID"));
                    }
                    
                    break;
                default:
                    Console.WriteLine("Exit!");
                    menuaction = 0;
                    break;

                    
            }
            Console.WriteLine("");
            return menuaction;
        }

        private static int DetectMenuActionIngelogdeGebruiker(int menuAction)
        {
            int menuaction = 1;
            string reader = "";
            int id;
            Console.Clear();

            switch (menuAction)
            {
                case 1:
                    Console.Write("\nGeef gebruiker ID: ");
                    reader = Console.ReadLine();
                    id = Convert.ToInt32(reader);
                    Gebruiker gebruiker = ingelogdegebr.getGebruiker(id);
                    Console.WriteLine(String.Format("\nId: {0}\nGebruikersnaam: {1} \nVoornaam: {2} \nAchternaam: {3} \nGeboorteDatum: {4} ", gebruiker.id, gebruiker.gebruikersnaam, gebruiker.voornaam, gebruiker.achternaam, gebruiker.geboorteDatum));
                    break;

                case 2:
                    Console.Write("\nGeef gebruiker ID: ");
                    reader = Console.ReadLine();
                    id = Convert.ToInt32(reader);
                    Beheerder beheerder = ingelogdegebr.getBeheerder(id);
                    Console.WriteLine(String.Format("\nId: {0}\nVoornaam: {1} \nAchternaam: {2}", beheerder.id, beheerder.voornaam, beheerder.achternaam));
                    break;
                case 3:
                    Console.Write("\nGeef gebruiker ID: ");
                    reader = Console.ReadLine();
                    id = Convert.ToInt32(reader);
                    Medebeheerder medebeheerder = ingelogdegebr.getMedebeheerder(id);
                    Console.WriteLine(String.Format("\nId: {0}\nBeheerderID: {1}", medebeheerder.id, medebeheerder.beheerderID));
                    break;
                case 4:
                    Console.Write("\nGeef gebruiker ID: ");
                    reader = Console.ReadLine();
                    id = Convert.ToInt32(reader);
                    Admin admin = ingelogdegebr.getAdmin(id);
                    Console.WriteLine(String.Format("\nId: {0}\nVoornaam: {1} \nAchternaam: {2}", admin.id, admin.voornaam, admin.achternaam));
                    break;
                case 5:
                    Console.Write("\nGeef gebruiker ID: ");
                    reader = Console.ReadLine();
                    id = Convert.ToInt32(reader);
                    SuperAdmin SA = ingelogdegebr.getSuperAdmin(id);
                    Console.WriteLine(String.Format("\nId: {0}\nVoornaam: {1} \nAchternaam: {2}", SA.id, SA.voornaam, SA.achternaam));
                    break;
                case 6:
                    Console.Write("\nGeef gebruiker ID: ");
                    reader = Console.ReadLine();
                    id = Convert.ToInt32(reader);
                    Moderator moderator = ingelogdegebr.getModerator(id);
                    Console.WriteLine(String.Format("\nId: {0}\nVoornaam: {1} \nAchternaam: {2}", moderator.id, moderator.voornaam, moderator.achternaam));
                    break;
                case 7:
                    Console.Write("\nGeef gebruiker ID: ");
                    reader = Console.ReadLine();
                    id = Convert.ToInt32(reader);
                    Expert expert = ingelogdegebr.getExpert(id);
                    Console.WriteLine(String.Format("\nId: {0}\nVoornaam: {1} \nAchternaam: {2}", expert.id, expert.voornaam, expert.achternaam));
                    break;
                case 8:
                    Console.Write("\nGeef Antwoord ID: ");
                    reader = Console.ReadLine();
                    id = Convert.ToInt32(reader);
                    Antwoord antwoord = ingelogdegebr.getAntwoord(id);
                    DossierAntwoord dosantwoord;

                    if (antwoord is AgendaAntwoord)
                    {

                        Console.WriteLine(String.Format("\nAgenda Antwoord\nId: {0}\nInhoud: {1} \nextraInfo: {2}\ndatum: {3} \naantalStemmen: {4} \neditable: {5} \ngebruikerID: {6}, antwoord.antwoordID, antwoord.inhoud, antwoord.extraInfo, antwoord.datum, antwoord.aantalStemmen, antwoord.editable, antwoord.gebruikerID"));
                    }
                    else
                    {
                        dosantwoord = (DossierAntwoord)antwoord;
                        Console.WriteLine(String.Format("\nDossier Antwoord\nId: {0}\nInhoud: {1} \nextraInfo: {2}\ndatum: {3} \naantalStemmen: {4} \neditable: {5} \ngebruikerID: {6} \nAfbeeldingPath: {7} \npercentageVolledigheid: {8} \nStatusOnline: {9} \nExtravraag: {10} \nCommentID: {11}, dosantwoord.antwoordID, dosantwoord.inhoud, dosantwoord.extraInfo, dosantwoord.datum, dosantwoord.aantalStemmen, dosantwoord.editable, dosantwoord.gebruikerID, dosantwoord.afbeeldingPath, dosantwoord.percentageVolledigheid, dosantwoord.statusOnline, dosantwoord.extraVraag, dosantwoord.commentID"));
                    }

                    break;

                case 9:
                    Console.Write("\nGeef gebruiker ID: ");
                    reader = Console.ReadLine();
                    id = Convert.ToInt32(reader);
                    ingelogdegebr.deleteGebruiker(id);
                    break;
                default:
                    Console.WriteLine("Exit!");
                    menuaction = 0;
                    break;


            }
            Console.WriteLine("");
            return menuaction;
        }
    * }
    * */
    }

