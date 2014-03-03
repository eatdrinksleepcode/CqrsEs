using System.Collections.Generic;

namespace CqrsEs
{
    public class Level : ILevel
    {
        private LevelId id;
        private string name;

        public Level(LevelId id, StructureId ownerId, string name)
        {
            Raise(new LevelAddedEvent(ownerId, id, name));
        }

        private void Raise(IDomainEvent evt)
        {
            ApplyLocal(evt);
            DomainEvents.Raise((dynamic)evt);
        }

        private void ApplyLocal(IDomainEvent evt)
        {
            Apply((dynamic) evt);
        }

        public Level(IEnumerable<IDomainEvent> events)
        {
            foreach (var evt in events)
            {
                ApplyLocal(evt);
            }
        }

        public LevelId Id
        {
            get { return id; }
        }

        public string Name
        {
            get { return name; }
        }

        public void Rename(string newName)
        {
            Raise(new LevelRenamedEvent(this.Id, newName));
        }

        private void Apply(LevelAddedEvent evt)
        {
            this.id = evt.EntityId;
            this.name = evt.LevelName;
        }

        private void Apply(LevelRenamedEvent evt)
        {
            this.name = evt.NewName;
        }
    }
}
