namespace KB.Domain.Entities
{
    public class ArticleTag : KBEntity
    {
        public int ArticleId { get; set; }

        public int TagId { get; set; }

        public virtual Article Article { get; set; }

        public virtual Tag Tag { get; set; }
    }
}
