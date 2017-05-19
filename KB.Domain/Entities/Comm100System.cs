namespace KB.Domain.Entities
{
    using System.Collections.Generic;

    public class Comm100System
    {
        public Comm100System()
        {
            KnowledgeBases = new HashSet<KnowledgeBase>();
        }

        public int Id { get; set; }

        public string Address { get; set; }

        public string Discription { get; set; }

        public string HelpDoc { get; set; }

        public string SysVersion { get; set; }

        public string Telephone { get; set; }

        public virtual ICollection<KnowledgeBase> KnowledgeBases { get; set; }
    }
}
