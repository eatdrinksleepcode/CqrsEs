namespace CqrsEs
{
    public class Level : ILevel
    {
        private readonly LevelId id;

        public Level(LevelId id, StructureId ownerId, string name)
        {
            this.id = id;
            this.Name = name;

            DomainEvents.Raise(new LevelAddedEvent(ownerId, id, name));
        }

        public string Name { get; private set; }

        public LevelId Id
        {
            get { return id; }
        }
    }
}