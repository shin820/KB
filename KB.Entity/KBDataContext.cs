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
        public virtual DbSet<t_KB_ArticleIdea> t_KB_ArticleIdea { get; set; }
        public virtual DbSet<t_KB_ArticlesTagsRelation> t_KB_ArticlesTagsRelation { get; set; }
        public virtual DbSet<t_KB_Category> t_KB_Category { get; set; }
        public virtual DbSet<t_KB_Comm100System> t_KB_Comm100System { get; set; }
        public virtual DbSet<t_KB_Image> t_KB_Image { get; set; }
        public virtual DbSet<t_KB_KnowledgeBase> t_KB_KnowledgeBase { get; set; }
        public virtual DbSet<t_KB_OptimizationIdea> t_KB_OptimizationIdea { get; set; }
        public virtual DbSet<t_KB_PageTemplate> t_KB_PageTemplate { get; set; }
        public virtual DbSet<t_KB_RateArticle> t_KB_RateArticle { get; set; }
        public virtual DbSet<t_KB_RateArticleDetail> t_KB_RateArticleDetail { get; set; }
        public virtual DbSet<t_KB_Tag> t_KB_Tag { get; set; }
        public virtual DbSet<t_KB_ViewArticleHistory> t_KB_ViewArticleHistory { get; set; }
        public virtual DbSet<t_ViewHistory_SiteId_> t_ViewHistory_SiteId_ { get; set; }
        public virtual DbSet<t_LiveChat_KBIntegration> t_LiveChat_KBIntegration { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<t_KB_Article>()
                .HasMany(e => e.t_KB_ArticlesTagsRelation)
                .WithRequired(e => e.t_KB_Article)
                .HasForeignKey(e => e.ArticleId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_KB_Article>()
                .HasMany(e => e.t_KB_OptimizationIdea)
                .WithRequired(e => e.t_KB_Article)
                .HasForeignKey(e => e.ArctileId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_KB_Article>()
                .HasMany(e => e.t_KB_RateArticle)
                .WithOptional(e => e.t_KB_Article)
                .HasForeignKey(e => e.ArticleId);

            modelBuilder.Entity<t_KB_Article>()
                .HasMany(e => e.t_KB_ViewArticleHistory)
                .WithRequired(e => e.t_KB_Article)
                .HasForeignKey(e => e.ArticleId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_KB_Comm100System>()
                .HasMany(e => e.t_KB_KnowledgeBase)
                .WithOptional(e => e.t_KB_Comm100System)
                .HasForeignKey(e => e.SystemId);

            modelBuilder.Entity<t_KB_KnowledgeBase>()
                .HasMany(e => e.t_KB_Article)
                .WithRequired(e => e.t_KB_KnowledgeBase)
                .HasForeignKey(e => e.KBId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_KB_KnowledgeBase>()
                .HasMany(e => e.t_KB_ArticleIdea)
                .WithRequired(e => e.t_KB_KnowledgeBase)
                .HasForeignKey(e => e.KBId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_KB_KnowledgeBase>()
                .HasMany(e => e.t_KB_Category)
                .WithOptional(e => e.t_KB_KnowledgeBase)
                .HasForeignKey(e => e.KBId);

            modelBuilder.Entity<t_KB_KnowledgeBase>()
                .HasMany(e => e.t_KB_Image)
                .WithRequired(e => e.t_KB_KnowledgeBase)
                .HasForeignKey(e => e.KBId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_KB_KnowledgeBase>()
                .HasMany(e => e.t_KB_PageTemplate)
                .WithRequired(e => e.t_KB_KnowledgeBase)
                .HasForeignKey(e => e.KBId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_KB_KnowledgeBase>()
                .HasMany(e => e.t_KB_Tag)
                .WithRequired(e => e.t_KB_KnowledgeBase)
                .HasForeignKey(e => e.KBId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<t_KB_Tag>()
                .HasMany(e => e.t_KB_ArticlesTagsRelation)
                .WithRequired(e => e.t_KB_Tag)
                .HasForeignKey(e => e.TagId)
                .WillCascadeOnDelete(false);
        }
    }
}
