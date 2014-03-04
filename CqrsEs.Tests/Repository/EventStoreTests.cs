using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace CqrsEs.Repository
{
    class EventStoreTests
    {
        private readonly OrganizationId organizationId = new OrganizationId();
        private readonly StructureId structureId = new StructureId();
        private readonly OrganizationId draftId = new OrganizationId();

        [Test]
        public void ShouldResolveSimpleEventStream()
        {
            var eventStore = new EventStore();
            var events = new IDomainEvent[]
            {
                new DraftCreatedEvent(organizationId, null),
                new StructureCreatedEvent(structureId),
                new LevelCreatedEvent(structureId, new LevelId(), "Level"),
            };
            foreach (var domainEvent in events)
            {
                eventStore.Add(organizationId, domainEvent);
            }

            eventStore.GetEvents(organizationId).Should().Equal(events);
        }

        [Test]
        public void ShouldResolveComplexEventStream()
        {
            var eventStore = new EventStore();
            var events = new IDomainEvent[]
            {
                new DraftCreatedEvent(organizationId, null),
                new StructureCreatedEvent(structureId),
            };
            var draftEvents = new IDomainEvent[]
            {
                new DraftCreatedEvent(draftId, organizationId),
                new LevelCreatedEvent(structureId, new LevelId(), "Level"),
            };
            foreach (var domainEvent in events)
            {
                eventStore.Add(organizationId, domainEvent);
            }
            foreach (var domainEvent in draftEvents)
            {
                eventStore.Add(draftId, domainEvent);
            }

            eventStore.GetEvents(draftId).Should().Equal(events.Concat(draftEvents));
        }

        [Test]
        public void ShouldResolveSplitEventStream()
        {
            var eventStore = new EventStore();
            var events = new IDomainEvent[]
            {
                new DraftCreatedEvent(organizationId, null),
            };
            var draftEvents = new IDomainEvent[]
            {
                new DraftCreatedEvent(draftId, organizationId),
            };
            var afterDraftEvents = new IDomainEvent[]
            {
                new LevelCreatedEvent(structureId, new LevelId(), "Level"),
            };
            foreach (var domainEvent in events)
            {
                eventStore.Add(organizationId, domainEvent);
            }
            foreach (var domainEvent in draftEvents)
            {
                eventStore.Add(draftId, domainEvent);
            }
            foreach (var domainEvent in afterDraftEvents)
            {
                eventStore.Add(organizationId, domainEvent);
            }

            eventStore.GetEvents(draftId).Should().Equal(events.Concat(draftEvents));
        }
    }
}
