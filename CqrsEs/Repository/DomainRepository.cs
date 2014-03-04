using System.Collections.Generic;
using System.Linq;

namespace CqrsEs
{
    public class DomainRepository : IDomainRepository
    {
        private readonly OrganizationId organizationId;
        private readonly EventStore events;

        public DomainRepository(OrganizationId organizationId, EventStore events)
        {
            this.organizationId = organizationId;
            this.events = events;
        }

        public IOrganization GetOrganization(OrganizationId id)
        {
            return new Organization(GetEventsForId(id));
        }

        public IEnumerable<IStructure> GetStructures()
        {
            return GetOrganizationEvents().OfType<StructureCreatedEvent>()
                    .Select(it => GetStructure(it.EntityId));
        }

        private IQueryable<IDomainEvent> GetOrganizationEvents()
        {
            return events.GetEvents(organizationId);
        }

        public IStructure GetStructure(StructureId id)
        {
            return new Structure(GetEventsForId(id));
        }

        public IEnumerable<ILevel> GetLevels(StructureId structureId)
        {
            return GetOrganizationEvents().OfType<LevelCreatedEvent>()
                    .Where(it => it.StructureId == structureId)
                    .Select(it => GetLevel(it.EntityId));
        }

        public ILevel GetLevel(LevelId levelId)
        {
            return new Level(GetEventsForId(levelId));
        }

        private IEnumerable<IDomainEvent<TId>> GetEventsForId<TId>(TId levelId)
        {
            var domainEvents = GetOrganizationEvents().OfType<IDomainEvent<TId>>()
                .Where(evt => evt.EntityId.Equals(levelId));
            if (!domainEvents.Any())
            {
                throw new MissingEntityException(typeof(TId));
            }
            return domainEvents;
        }
    }
}
