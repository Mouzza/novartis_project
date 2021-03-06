﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace JPP.BL.Domain.Antwoorden
{
    public class DossierAntwoord:Antwoord
    {
        /* Erft over van antwoord maar heeft extra attributen nodig */
        public int layoutOption { get; set; }
        public string afbeeldingPath { get; set; }
        public byte[] afbeeldingByte { get; set; }
        public string textvak2 { get; set; }
        public string textvak3 { get; set; }
        public string foregroundColor { get; set; }
        public string backgroundColor {get; set; }
        public string TitleColor { get; set; }
        public string SubTitleColor { get; set; }
        public string backgroundImage { get; set; }
        public int percentageVolledigheid { get; set; }
        public string extraVraag { get; set; }
        public string googleMapsAdress{ get; set; }

        public virtual ICollection<Comment> comments { get; set; }
    }
}
