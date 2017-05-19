namespace KB.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public class Tag : KBEntity
    {
        public Tag()
        {
            ArticleTags = new HashSet<ArticleTag>();
        }

        public int Id { get; private set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedTime { get; set; }

        public string Name { get; set; }

        public virtual ICollection<ArticleTag> ArticleTags { get; set; }

        public virtual KnowledgeBase KnowledgeBase { get; set; }
    }
}
