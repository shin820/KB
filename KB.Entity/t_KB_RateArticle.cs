namespace KB.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_KB_RateArticle
    {
        public int Id { get; set; }

        public short RateType { get; set; }

        public DateTime RateTime { get; set; }

        public int? TriggeredChatTimes { get; set; }

        public int? TriggeredMessages { get; set; }

        public int? VisitorId { get; set; }

        public int? ArticleId { get; set; }

        public int SiteId { get; set; }

        public int KBId { get; set; }

        public virtual t_KB_Article t_KB_Article { get; set; }
    }
}
