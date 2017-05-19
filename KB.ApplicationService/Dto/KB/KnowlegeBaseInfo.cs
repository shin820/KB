using System.ComponentModel.DataAnnotations;

namespace KB.Application.Dto.KB
{
    public class KnowlegeBaseInfo
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

        public int SiteId { get; }

        [StringLength(256)]
        public string Name { get; set; }
    }
}
