namespace KB.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class t_KB_Comm100System
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public t_KB_Comm100System()
        {
            t_KB_KnowledgeBase = new HashSet<t_KB_KnowledgeBase>();
        }

        public int Id { get; set; }

        [StringLength(256)]
        public string Address { get; set; }

        [StringLength(256)]
        public string Discription { get; set; }

        [StringLength(256)]
        public string HelpDoc { get; set; }

        [StringLength(256)]
        public string SysVersion { get; set; }

        [StringLength(256)]
        public string Telephone { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<t_KB_KnowledgeBase> t_KB_KnowledgeBase { get; set; }
    }
}
