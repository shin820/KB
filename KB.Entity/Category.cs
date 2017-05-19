namespace KB.Entity
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Category : KBEntityBase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Index { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedTime { get; set; }

        public DateTime? ModifiedTime { get; set; }

        public int? ModifiedBy { get; set; }

        public int ParentId { get; set; }

        public virtual KnowledgeBase KnowlegeBase { get; set; }
    }
}
