namespace KB.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public class Tag : KBEntity
    {
        public Tag()
        {
            ArticleTags = new HashSet<ArticleTags>();
        }

        public int Id { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedTime { get; set; }

        public string Name { get; set; }

        public virtual ICollection<ArticleTags> ArticleTags { get; set; }

        public virtual KnowledgeBase KnowledgeBase { get; set; }
    }
}
