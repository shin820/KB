using KB.Application.Dto.Tags;
using System.Collections.Generic;

namespace KB.Application.Dto.Articles
{
    public class ArticleDetailDto
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

        public List<TagDto> Tags { get; set; }
    }
}
