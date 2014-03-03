using System.Collections.Generic;
using System.Linq;

namespace CqrsEs
{
    public class DomainRepository
    {
        private readonly IList<IDomainEvent> events;

        public DomainRepository(IEnumerable<IDomainEvent> events)
        {
            this.events = events.ToList();
        }

        public ILevel GetLevel(LevelId levelId)
        {
            return new Level(events.OfType<LevelAddedEvent>());
        }
    }
}
