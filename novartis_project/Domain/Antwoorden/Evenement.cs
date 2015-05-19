using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace JPP.BL.Domain.Antwoorden
{
    public class Evenement
    {
        [Key]
        public int ID { get; set; }
        public string title { get; set; }
        public string evenementText { get; set; }
        public string locatie { get; set; }
        public DateTime startDatum { get; set; }
        public DateTime eindDatum { get; set; }
        public string urlFacebookEvent { get; set; }
  
    }
}
