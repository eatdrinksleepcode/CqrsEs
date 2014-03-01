namespace CqrsEs
{
    public class LevelAddedEvent : IDomainEvent
    {
        private readonly StructureId structureId;
        private readonly LevelId levelId;
        private readonly string levelName;

        public LevelAddedEvent(StructureId structureId, LevelId levelId, string levelName)
        {
            this.structureId = structureId;
            this.levelId = levelId;
            this.levelName = levelName;
        }

        public StructureId StructureId { get { return structureId; } }
        public LevelId LevelId { get { return levelId; } }
        public string LevelName { get { return levelName; } }
    }
}