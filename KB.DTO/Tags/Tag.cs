using System.ComponentModel.DataAnnotations;

namespace KB.Object.Tags
{
    public class Tag
    {
        public Tag(int id, int siteId)
        {
            this.Id = id;
            this.SiteId = siteId;
        }

        public int Id { get; private set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        [Required]
        public int KBId { get; set; }

        public int SiteId { get; }
    }
}
