namespace CqrsEs
{
    public class StructureCreatedEvent : IDomainEvent<StructureId>
    {
        public StructureCreatedEvent(StructureId structureId)
        {
            this.EntityId = structureId;
        }

        public StructureId EntityId { get; private set; }
    }
}
