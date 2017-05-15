namespace KB.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_KB_ArticleIdea
    {
        public int Id { get; set; }

        public short Status { get; set; }

        [Required]
        [StringLength(256)]
        public string NewArticleRequest { get; set; }

        public short Type { get; set; }

        public DateTime SubmittedTime { get; set; }

        public int KBId { get; set; }

        public int SiteId { get; set; }

        public virtual t_KB_KnowledgeBase t_KB_KnowledgeBase { get; set; }
    }
}
