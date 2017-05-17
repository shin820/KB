using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB.Dto.KB
{
    public class KBDto
    {
        public int Id { get; set; }

        public int KnowledgebaseHomePage { get; set; }

        public int? CampaignId { get; set; }

        public short Status { get; set; }

        public short Visibility { get; set; }

        public short IfAllowRateHelpfulOrNotHelpful { get; set; }

        public short? IfAddLiveChat { get; set; }

        public short? IfTriggerChat { get; set; }

        public int? SystemId { get; set; }

        public int SiteId { get; set; }

        [StringLength(256)]
        public string Name { get; set; }
    }
}
