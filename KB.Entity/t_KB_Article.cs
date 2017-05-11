namespace KB.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_KB_Article
    {
        public int Id { get; set; }

        [Required]
        public string Body { get; set; }

        [Required]
        [StringLength(1024)]
        public string CustomURL { get; set; }

        public int CategoryId { get; set; }

        public bool IfFeatured { get; set; }

        public DateTime CreatedTime { get; set; }

        public int CreatedBy { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedTime { get; set; }

        public short Status { get; set; }

        [Required]
        [StringLength(2048)]
        public string Title { get; set; }

        public int? Views { get; set; }

        [StringLength(256)]
        public string Name { get; set; }

        public int? Index { get; set; }
    }
}
