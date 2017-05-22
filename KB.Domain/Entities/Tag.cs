namespace KB.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Tag : KBEntity
    {
        public Tag()
        {
            ArticleTags = new HashSet<ArticleTag>();
        }

        public int Id { get; private set; }

        public int CreatedBy { get; protected internal set; }

        public DateTime CreatedTime { get; protected internal set; }

        public string Name { get; set; }

        public IList<Article> Articles
        {
            get
            {
                return this.ArticleTags.Select(t => t.Article).ToList();
            }
        }

        public virtual KnowledgeBase KnowledgeBase { get; set; }

        protected internal virtual ICollection<ArticleTag> ArticleTags { get; set; }
    }
}
