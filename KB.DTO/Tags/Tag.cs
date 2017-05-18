using System.ComponentModel.DataAnnotations;

namespace KB.Object.Tags
{
    public class Tag
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
