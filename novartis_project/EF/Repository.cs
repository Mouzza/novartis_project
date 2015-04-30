using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace JPP.DAL.EF
{
    public class Repository : IAdminRespository
    {

        private EFDbContext edc;

        public Repository()
        {
            edc = new EFDbContext();

        }
      

    }
}
