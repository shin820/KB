using System.ComponentModel.DataAnnotations;

namespace KB.Application.Dto.Articles
{
    public class ArticleInfo
    {
        public int Id { get; set; }

        [Required]
        public int KBId { get; set; }

        public int SiteId { get; set; }

        [Required]
        public string Body { get; set; }

        [Required]
        [StringLength(1024)]
        public string CustomURL { get; set; }

        public int CategoryId { get; set; }

        public bool IfFeatured { get; set; }

        public short Status { get; set; }

        [Required]
        [StringLength(2048)]
        public string Title { get; set; }

        [StringLength(256)]
        public string Name { get; set; }

        public int? Index { get; set; }
    }
}
