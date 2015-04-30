using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace JPP.DAL.EF
{
    public class Repository : IAdminRepository
    {

        private EFDbContext edc;

        public Repository()
        {
            edc = new EFDbContext();

        }
      

    }
}
