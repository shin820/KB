namespace KB.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Tag : KBEntity
    {
        public Tag()
        {
            ArticleTags = new HashSet<ArticleTags>();
        }

        public int Id { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedTime { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        public virtual ICollection<ArticleTags> ArticleTags { get; set; }

        public virtual KnowledgeBase KnowledgeBase { get; set; }
    }
}
