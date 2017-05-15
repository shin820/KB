namespace KB.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("t_ViewHistory{SiteId}")]
    public partial class t_ViewHistory_SiteId_
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        public long CookieIdOrUserId { get; set; }

        public short HistoryType { get; set; }

        public short AppType { get; set; }

        public int AppEntryId { get; set; }

        public DateTime ViewTime { get; set; }
    }
}
