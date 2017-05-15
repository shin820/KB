namespace KB.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_KB_Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        public int Index { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedTime { get; set; }

        public DateTime? ModifiedTime { get; set; }

        public int? ModifiedBy { get; set; }

        public int ParentId { get; set; }

        public int? KBId { get; set; }

        public int SiteId { get; set; }

        public virtual t_KB_KnowledgeBase t_KB_KnowledgeBase { get; set; }
    }
}
