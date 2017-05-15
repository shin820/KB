using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.Dto.Article
{
    public class ArticleDetailResponse
    {
        public int Id { get; set; }

        public string Body { get; set; }

        public string CustomURL { get; set; }

        public int CategoryId { get; set; }

        public bool IfFeatured { get; set; }

        public short Status { get; set; }

        public string Title { get; set; }

        public int? Views { get; set; }

        public string Name { get; set; }

        public int? Index { get; set; }
    }
}
