﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace JPP.BL.Domain.Modules
{
    public class Beloning
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string naam { get; set; }
        [Required]
        public string beschrijving { get; set; }
        public virtual ICollection<Module> modules { get; set; }
    }
}
