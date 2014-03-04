namespace CqrsEs
{
    public abstract class DomainEvent<TId> : IDomainEvent<TId>
    {
        protected DomainEvent(OrganizationId organizationId, TId entityId)
        {
            EntityId = entityId;
            OrganizationId = organizationId;
        }

        public OrganizationId OrganizationId { get; private set; }
        public TId EntityId { get; private set; }
    }
}
