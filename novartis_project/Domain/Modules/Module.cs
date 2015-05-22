using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JPP.BL.Domain.Vragen;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JPP.BL.Domain.Modules
{
    public class Module
    {
       

        [Key]
        public int ID { get; set; }
        [Required]
        public string naam { get; set; }
        public Boolean status { get; set; }
        [Required]
        public DateTime beginDatum { get; set; }
        [Required]
        public DateTime eindDatum { get; set; }

        public string adminNaam { get; set; }


        public virtual CentraleVraag centraleVraag { get; set; }
        public virtual Beloning beloning { get; set; }
        public virtual Organisatie organisatie { get; set; }
        public virtual Thema thema { get; set; }
        
      
    }
}
