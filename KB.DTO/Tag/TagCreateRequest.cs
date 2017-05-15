using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.Dto.Tag
{
    public class TagCreateRequest
    {
        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        public int KBId { get; set; }

        public int SiteId { get; set; }
    }
}
