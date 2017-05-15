namespace KB.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_KB_RateArticleDetail
    {
        public int Id { get; set; }

        public DateTime StartLiveChatDateTime { get; set; }

        public int? LiveChatId { get; set; }

        public int? VisitorId { get; set; }

        public int? AgentId { get; set; }

        public short? Type { get; set; }

        public int? RateArcticleId { get; set; }

        public int ArticleId { get; set; }
    }
}
