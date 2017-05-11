namespace KB.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class KBDataContext : DbContext
    {
        public KBDataContext()
            : base("name=KBDataContext")
        {
        }

        public virtual DbSet<t_KB_Article> t_KB_Article { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
