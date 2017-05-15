namespace KB.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_KB_ArticlesTagsRelation
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ArticleId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TagId { get; set; }

        public int SiteId { get; set; }

        public int KBId { get; set; }

        public virtual t_KB_Article t_KB_Article { get; set; }

        public virtual t_KB_Tag t_KB_Tag { get; set; }
    }
}
