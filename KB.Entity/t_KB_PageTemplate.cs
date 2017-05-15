namespace KB.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_KB_PageTemplate
    {
        public int Id { get; set; }

        [Required]
        [StringLength(1024)]
        public string Title { get; set; }

        [Required]
        public string Body { get; set; }

        [Required]
        [StringLength(1024)]
        public string CustomURL { get; set; }

        public DateTime CreatedTime { get; set; }

        public DateTime? LastUpdatedTime { get; set; }

        public short Status { get; set; }

        public int? LastUpdateBy { get; set; }

        public int? CreatedBy { get; set; }

        public short? TemplateType { get; set; }

        public int KBId { get; set; }

        public int SiteId { get; set; }

        public virtual t_KB_KnowledgeBase t_KB_KnowledgeBase { get; set; }
    }
}
