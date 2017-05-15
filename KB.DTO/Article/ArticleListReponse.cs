using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.Dto.Article
{
    public class ArticleListReponse
    {
        public int Id { get; set; }

        public int KBId { get; set; }

        public int SiteId { get; set; }

        public string CustomURL { get; set; }

        public int CategoryId { get; set; }

        public bool IfFeatured { get; set; }

        public short Status { get; set; }

        public string Title { get; set; }

        public string Name { get; set; }
    }
}
