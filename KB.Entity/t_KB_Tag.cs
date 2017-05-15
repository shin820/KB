namespace KB.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_KB_Tag
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_KB_Tag()
        {
            t_KB_ArticlesTagsRelation = new HashSet<t_KB_ArticlesTagsRelation>();
        }

        public int Id { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedTime { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        public int KBId { get; set; }

        public int SiteId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_KB_ArticlesTagsRelation> t_KB_ArticlesTagsRelation { get; set; }

        public virtual t_KB_KnowledgeBase t_KB_KnowledgeBase { get; set; }
    }
}
