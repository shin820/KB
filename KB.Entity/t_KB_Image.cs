namespace KB.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_KB_Image
    {
        public int Id { get; set; }

        [Required]
        [StringLength(1024)]
        public string FileName { get; set; }

        public int Height { get; set; }

        public DateTime? Modified { get; set; }

        public int Size { get; set; }

        public DateTime UploadTime { get; set; }

        public int Width { get; set; }

        [Column(TypeName = "image")]
        [Required]
        public byte[] Content { get; set; }

        public int KBId { get; set; }

        public int SiteId { get; set; }

        public virtual t_KB_KnowledgeBase t_KB_KnowledgeBase { get; set; }
    }
}
