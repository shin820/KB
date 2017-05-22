namespace KB.Domain.Entities
{
    public abstract class KBEntity
    {
        public int SiteId { get; protected internal set; }

        public int KBId { get; protected internal set; }
    }
}
