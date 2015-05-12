using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JPP.BL.Domain.Vragen;
using System.ComponentModel.DataAnnotations;
using JPP.BL.Domain.Gebruikers.SuperUser;
using System.ComponentModel.DataAnnotations.Schema;

namespace JPP.BL.Domain.Modules
{
    public class Module
    {
       

        [Key]
        public int ID { get; set; }
        public string naam { get; set; }
        public Boolean status { get; set; }
        public DateTime beginDatum { get; set; }
        public DateTime eindDatum { get; set; }

        public string adminNaam { get; set; }

        
        public int centraleVraagID { get; set; }
        [ForeignKey("centraleVraagID")]
        public virtual CentraleVraag centraleVraag { get; set; }
        public virtual Beloning beloning { get; set; }
        public virtual Organisatie organisatie { get; set; }
        public virtual Thema thema { get; set; }
        
      
    }
}
