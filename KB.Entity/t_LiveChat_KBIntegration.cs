namespace KB.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_LiveChat_KBIntegration
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SiteId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CampaignId { get; set; }

        [Key]
        [Column(Order = 2)]
        public bool IfEnable { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int KBId { get; set; }

        [Key]
        [Column(Order = 4)]
        public bool IfCanSearchKBBeforeOffLine { get; set; }

        [Key]
        [Column(Order = 5)]
        public bool IfCanSerachKBeforeChattingOrPreChat { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaxCountsOfKBArticlesToShow { get; set; }
    }
}
