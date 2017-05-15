using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.Dto.Article
{
    public class ArticleCreateRequest
    {
        [Required]
        public int KBId { get; set; }

        [Required]
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
