﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JPP.DAL.Interface;
using JPP.BL.Domain.Antwoorden;
using JPP.BL.Domain.Modules;
using JPP.BL.Domain.Vragen;
using System.Configuration;

namespace JPP.DAL.EF
{
    public class BeheerderSCEF : MedebeheerderSCEF, BeheerderHC
    {

        EFDbContext dbcontext = NietIngelogdeGebruikerSCEF.dbcontext;
   
    }
}
