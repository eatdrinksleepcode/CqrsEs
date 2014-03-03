namespace CqrsEs
{
    public class LevelRenamedEvent : IDomainEvent<LevelId>
    {
        public LevelRenamedEvent(LevelId entityId, string newName)
        {
            EntityId = entityId;
            NewName = newName;
        }

        public LevelId EntityId { get; private set; }
        public string NewName { get; private set; }
    }
}
