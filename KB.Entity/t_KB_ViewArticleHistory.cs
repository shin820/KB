namespace KB.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_KB_ViewArticleHistory
    {
        public int Id { get; set; }

        public int UserType { get; set; }

        public int UserId { get; set; }

        public DateTime ViewTime { get; set; }

        public int ArticleId { get; set; }

        public virtual t_KB_Article t_KB_Article { get; set; }
    }
}
