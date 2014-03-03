namespace CqrsEs
{
    public class LevelCreatedEvent : IDomainEvent<LevelId>
    {
        private readonly StructureId structureId;
        private readonly LevelId levelId;
        private readonly string levelName;

        public LevelCreatedEvent(StructureId structureId, LevelId levelId, string levelName)
        {
            this.structureId = structureId;
            this.levelId = levelId;
            this.levelName = levelName;
        }

        public StructureId StructureId { get { return structureId; } }
        public LevelId EntityId { get { return levelId; } }
        public string LevelName { get { return levelName; } }
    }
}