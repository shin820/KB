using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.Entity
{
    public partial class KBDataContext : DbContext
    {
        public KBDataContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {

        }
    }
}
