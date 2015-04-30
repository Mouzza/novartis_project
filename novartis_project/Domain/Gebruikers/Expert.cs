using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace JPP.BL.Domain.Gebruikers
{
    public class Expert
    {
        [Key]
        public virtual Gebruiker gebruiker { get; set; }
        public int expertId { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public virtual ICollection<ExpertVraag> expertVraag { get; set; }
    }
}
