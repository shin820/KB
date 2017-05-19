using KB.ApplicationService.Dto.Tags;
using System.Collections.Generic;

namespace KB.ApplicationService.Dto.Articles
{
    public class ArticleDetail
    {
        public int Id { get; set; }

        public int KBId { get; set; }

        public int SiteId { get; set; }

        public string Body { get; set; }

        public string CustomURL { get; set; }

        public int CategoryId { get; set; }

        public bool IfFeatured { get; set; }

        public short Status { get; set; }

        public string Title { get; set; }

        public int? Views { get; set; }

        public string Name { get; set; }

        public int? Index { get; set; }

        public List<TagInfo> Tags { get; set; }
    }
}
