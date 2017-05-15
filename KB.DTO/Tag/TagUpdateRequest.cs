using System.ComponentModel.DataAnnotations;

namespace KB.Dto.Tag
{
    public class TagUpdateRequest
    {
        [Required]
        [StringLength(256)]
        public string Name { get; set; }
    }
}
