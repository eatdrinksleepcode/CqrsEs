using System.Collections.Generic;
using System.Linq;

namespace CqrsEs
{
    public class EventStore
    {
        private readonly IList<EventContext> events = new List<EventContext>();

        public void Add(OrganizationId organizationId, IDomainEvent domainEvent)
        {
            events.Add(new EventContext(organizationId, domainEvent));
        }

        public IQueryable<IDomainEvent> GetEvents(OrganizationId organizationId)
        {
            var results = GetEvents(organizationId, null);
            var createdEvent = results.FirstOrDefault() as DraftCreatedEvent;
            if (null != createdEvent)
            {
                results = GetEvents(createdEvent.SourceId, createdEvent).Concat(results);
            }
            return results;
        }

        private IQueryable<IDomainEvent> GetEvents(OrganizationId organizationId, IDomainEvent createdEvent)
        {
            return (from context in events.TakeWhile(it => it.DomainEvent != createdEvent)
                    where context.OrganizationId == organizationId
                    select context.DomainEvent).AsQueryable();
        }
    }

    public class EventContext
    {
        private readonly OrganizationId organizationId;
        private readonly IDomainEvent domainEvent;

        public EventContext(OrganizationId organizationId, IDomainEvent domainEvent)
        {
            this.organizationId = organizationId;
            this.domainEvent = domainEvent;
        }

        public IDomainEvent DomainEvent
        {
            get { return domainEvent; }
        }

        public OrganizationId OrganizationId
        {
            get { return organizationId; }
        }
    }
}
