using Castle.MicroKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KB.Entity;
using System.Data.Entity;

namespace KB.Repository
{
    public class DbContextFactory
    {
        public static DbContext Create(IKernel kernel)
        {
            return new KBDataContext();
        }
    }
}
