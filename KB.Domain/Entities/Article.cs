namespace KB.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Article : KBEntity
    {
        public Article()
        {
            ArticleTags = new List<ArticleTag>();
        }

        public int Id { get; private set; }

        public string Body { get; set; }

        public string CustomURL { get; set; }

        public int CategoryId { get; set; }

        public bool IfFeatured { get; set; }

        public DateTime CreatedTime { get; set; }

        public int CreatedBy { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedTime { get; set; }

        public short Status { get; private set; }

        public string Title { get; set; }

        public int? Views { get; set; }

        public string Name { get; set; }

        public int? Index { get; set; }

        public virtual IList<ArticleTag> ArticleTags { get; set; }

        public virtual KnowledgeBase KnowledgeBase { get; set; }

        public void AddTag(int tagId)
        {
            ArticleTags.Add(
                new ArticleTag
                {
                    ArticleId = Id,
                    TagId = tagId,
                    KBId = KBId,
                    SiteId = SiteId
                });
        }

        public void RemoveTag(int tagId)
        {
            var tag = this.ArticleTags
                .FirstOrDefault(t => t.ArticleId == this.Id && t.TagId == tagId);
            if (tag != null)
            {
                this.ArticleTags.Remove(tag);
            }
        }
    }
}
