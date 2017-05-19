namespace KB.Domain
{
    using System.Data.Entity;
    using KB.Domain.Entities;

    public class KBDataContext : DbContext
    {
        public KBDataContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }

        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<ArticleTags> ArticleTags { get; set; }
        public virtual DbSet<Category> Categorys { get; set; }
        public virtual DbSet<Comm100System> Comm100Systems { get; set; }
        public virtual DbSet<KnowledgeBase> KnowledgeBases { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Article>()
                .ToTable("t_KB_Article")
                .HasMany(e => e.ArticleTags)
                .WithRequired(e => e.Article)
                .HasForeignKey(e => e.ArticleId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Article>()
                .Property(t => t.Body).IsRequired();
            modelBuilder.Entity<Article>()
                .Property(t => t.CustomURL).IsRequired().HasMaxLength(1024);
            modelBuilder.Entity<Article>()
                .Property(t => t.Title).IsRequired().HasMaxLength(1024);
            modelBuilder.Entity<Article>()
                .Property(t => t.Name).IsRequired();

            modelBuilder.Entity<Category>().ToTable("t_KB_Category");
            modelBuilder.Entity<Category>()
                        .Property(t => t.Name).IsRequired().HasMaxLength(256);

            modelBuilder.Entity<Comm100System>()
                .ToTable("t_KB_Comm100System")
                .HasMany(e => e.KnowledgeBases)
                .WithOptional(e => e.Comm100System)
                .HasForeignKey(e => e.SystemId);

            modelBuilder.Entity<KnowledgeBase>().ToTable("t_KB_KnowledgeBase");
            modelBuilder.Entity<KnowledgeBase>().Property(t => t.Name).HasMaxLength(256);
            modelBuilder.Entity<KnowledgeBase>()
                .HasMany(e => e.Articles)
                .WithRequired(e => e.KnowledgeBase)
                .HasForeignKey(e => e.KBId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KnowledgeBase>()
                .HasMany(e => e.Categorys)
                .WithRequired(e => e.KnowlegeBase)
                .HasForeignKey(e => e.KBId);

            modelBuilder.Entity<KnowledgeBase>()
                .HasMany(e => e.Tags)
                .WithRequired(e => e.KnowledgeBase)
                .HasForeignKey(e => e.KBId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tag>()
                .ToTable("t_KB_Tag")
                .HasMany(e => e.ArticleTags)
                .WithRequired(e => e.Tag)
                .HasForeignKey(e => e.TagId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tag>()
                .Property(t => t.Name)
                .IsRequired().HasMaxLength(256);

            modelBuilder.Entity<ArticleTags>()
                .ToTable("t_KB_ArticlesTagsRelation");
            modelBuilder.Entity<ArticleTags>()
                .HasKey(t => new { t.ArticleId, t.TagId });
        }
    }
}
