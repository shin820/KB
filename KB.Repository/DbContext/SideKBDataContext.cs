using KB.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.Repository.DbContext
{
    public class SideKBDataContext : KBDataContext
    {
        private string _tableSuffix;
        public SideKBDataContext(string nameOrConnectionString, string tableSuffix)
            : base(nameOrConnectionString)
        {
            _tableSuffix = tableSuffix;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<t_ViewHistory>()
                .HasKey(t => t.Id).ToTable("t_ViewHistory" + _tableSuffix);
        }
    }
}
