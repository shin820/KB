namespace KB.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_KB_Article
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_KB_Article()
        {
            t_KB_ArticlesTagsRelation = new HashSet<t_KB_ArticlesTagsRelation>();
            t_KB_OptimizationIdea = new HashSet<t_KB_OptimizationIdea>();
            t_KB_RateArticle = new HashSet<t_KB_RateArticle>();
            t_KB_ViewArticleHistory = new HashSet<t_KB_ViewArticleHistory>();
        }

        public int Id { get; set; }

        [Required]
        public string Body { get; set; }

        [Required]
        [StringLength(1024)]
        public string CustomURL { get; set; }

        public int CategoryId { get; set; }

        public bool IfFeatured { get; set; }

        public DateTime CreatedTime { get; set; }

        public int CreatedBy { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedTime { get; set; }

        public short Status { get; set; }

        [Required]
        [StringLength(2048)]
        public string Title { get; set; }

        public int? Views { get; set; }

        public int KBId { get; set; }

        [StringLength(256)]
        public string Name { get; set; }

        public int? Index { get; set; }

        public int SiteId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_KB_ArticlesTagsRelation> t_KB_ArticlesTagsRelation { get; set; }

        public virtual t_KB_KnowledgeBase t_KB_KnowledgeBase { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_KB_OptimizationIdea> t_KB_OptimizationIdea { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_KB_RateArticle> t_KB_RateArticle { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_KB_ViewArticleHistory> t_KB_ViewArticleHistory { get; set; }
    }
}
