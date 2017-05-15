namespace KB.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_KB_KnowledgeBase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_KB_KnowledgeBase()
        {
            t_KB_Article = new HashSet<t_KB_Article>();
            t_KB_ArticleIdea = new HashSet<t_KB_ArticleIdea>();
            t_KB_Category = new HashSet<t_KB_Category>();
            t_KB_Image = new HashSet<t_KB_Image>();
            t_KB_PageTemplate = new HashSet<t_KB_PageTemplate>();
            t_KB_Tag = new HashSet<t_KB_Tag>();
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

        [StringLength(256)]
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_KB_Article> t_KB_Article { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_KB_ArticleIdea> t_KB_ArticleIdea { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_KB_Category> t_KB_Category { get; set; }

        public virtual t_KB_Comm100System t_KB_Comm100System { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_KB_Image> t_KB_Image { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_KB_PageTemplate> t_KB_PageTemplate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_KB_Tag> t_KB_Tag { get; set; }
    }
}
