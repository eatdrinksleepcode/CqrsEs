using System;
using System.Collections.Generic;
using System.Linq;

namespace CqrsEs
{
    public class Structure
    {
        private readonly StructureId id;

        public Structure(StructureId id)
        {
            this.id = id;
        }

        public void AddLevel(string levelName, IEnumerable<ILevel> existingLevels)
        {
            if (existingLevels.Any(l => l.Name == levelName))
            {
                throw new Exception();
            }
            DomainEvents.Raise(new LevelAddedEvent(id, new LevelId(), levelName));
        }
    }
}
