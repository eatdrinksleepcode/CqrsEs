namespace CqrsEs
{
    public class DraftCreatedEvent : IDomainEvent<OrganizationId>
    {
        public DraftCreatedEvent(OrganizationId entityId, OrganizationId sourceId)
        {
            SourceId = sourceId;
            EntityId = entityId;
        }

        public OrganizationId SourceId { get; private set; }
        public OrganizationId EntityId { get; private set; }
    }
}
