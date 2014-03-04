using System;
using System.Collections.Generic;
using System.Linq;

namespace CqrsEs
{
    public class Structure : Entity, IStructure
    {
        private StructureId id;

        public Structure(StructureId id)
        {
            Raise(new StructureCreatedEvent(id));
        }

        public Structure(IEnumerable<IDomainEvent<StructureId>> events)
            : base(events)
        {
        }

        public StructureId Id
        {
            get { return id; }
        }

        public ILevel CreateLevel(string levelName, IEnumerable<ILevel> existingLevels)
        {
            if (existingLevels.Any(l => l.Name == levelName))
            {
                throw new Exception();
            }
            return new Level(new LevelId(), id, levelName);
        }

        private void Apply(StructureCreatedEvent evt)
        {
            this.id = evt.EntityId;
        }
    }
}
