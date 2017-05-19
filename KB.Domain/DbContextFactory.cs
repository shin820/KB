using Castle.MicroKernel;
using System.Data.Entity;
using System.Threading;
using System.Configuration;
using System.Security.Claims;
using KB.Infrastructure.Runtime.Security;

namespace KB.Domain
{
    public class DbContextFactory
    {
        public static DbContext Create(IKernel kernel)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["KBDataContext"].ConnectionString;

            ClaimsIdentity identity = Thread.CurrentPrincipal.Identity as ClaimsIdentity;
            if (identity != null)
            {
                int? sideId = identity.GetSideId();
                if (sideId != null)
                {
                    //connectionString = GetConnectionString(sideId.Value);
                    // trying switch to another data base at runtime.
                    connectionString = "data source=localhost;initial catalog=KB2;integrated security=True;multipleactiveresultsets=True;application name=EntityFramework";
                }
            }

            return new KBDataContext(connectionString);
        }
    }
}
