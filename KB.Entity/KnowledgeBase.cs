namespace KB.Entity
{
    using System.Collections.Generic;

    public class KnowledgeBase
    {
        public KnowledgeBase()
        {
            Articles = new HashSet<Article>();
            Categorys = new HashSet<Category>();
            Tags= new HashSet<Tag>();
        }

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

        public string Name { get; set; }

        public virtual ICollection<Article> Articles { get; set; }

        public virtual ICollection<Category> Categorys { get; set; }

        public virtual Comm100System Comm100System { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}
