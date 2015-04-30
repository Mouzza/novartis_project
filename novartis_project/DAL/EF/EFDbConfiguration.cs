using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;

namespace JPP.DAL.EF
{
   public class EFDbConfiguration : DbConfiguration
    {

        public EFDbConfiguration()
        {
           
            this.SetDefaultConnectionFactory(new SqlConnectionFactory());
            this.SetProviderServices("System.Data.SqlClient", SqlProviderServices.Instance);

            this.SetDatabaseInitializer<EFDbContext>
                                                     (new EFDbInitializer());


        }

    }

}
