using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.Dto.Tag
{
    public class TagDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        [Required]
        public int KBId { get; set; }

        [Required]
        public int SiteId { get; set; }
    }
}
