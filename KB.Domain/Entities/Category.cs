namespace KB.Domain.Entities
{
    using System;

    public class Category : KBEntity
    {
        public int Id { get; private set; }

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
