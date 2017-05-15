namespace KB.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_KB_OptimizationIdea
    {
        public int Id { get; set; }

        public int ArctileId { get; set; }

        [Required]
        [StringLength(1024)]
        public string OptimizationIdea { get; set; }

        public DateTime Submitted { get; set; }

        public int AgentId { get; set; }

        public int? KBId { get; set; }

        public int SiteId { get; set; }

        public virtual t_KB_Article t_KB_Article { get; set; }
    }
}
