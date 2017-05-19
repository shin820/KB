namespace KB.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Article : KBEntityBase
    {
        public Article()
        {
            ArticleTags = new HashSet<ArticleTags>();
        }

        public int Id { get; set; }

        public string Body { get; set; }

        public string CustomURL { get; set; }

        public int CategoryId { get; set; }

        public bool IfFeatured { get; set; }

        public DateTime CreatedTime { get; set; }

        public int CreatedBy { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedTime { get; set; }

        public short Status { get; set; }

        public string Title { get; set; }

        public int? Views { get; set; }

        public string Name { get; set; }

        public int? Index { get; set; }

        public virtual ICollection<ArticleTags> ArticleTags { get; set; }

        public virtual KnowledgeBase KnowledgeBase { get; set; }
    }
}
