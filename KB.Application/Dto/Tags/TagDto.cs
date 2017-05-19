using System.ComponentModel.DataAnnotations;

namespace KB.Application.Dto.Tags
{
    public class TagDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        [Required]
        public int KBId { get; set; }

        public int SiteId { get; set; }
    }
}
