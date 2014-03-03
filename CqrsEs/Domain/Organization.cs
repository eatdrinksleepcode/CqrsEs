using System.Collections.Generic;

namespace CqrsEs
{
    public class Organization : Entity, IOrganization
    {
        private OrganizationId id;
        private OrganizationId sourceId;

        public Organization(OrganizationId id, OrganizationId sourceId)
        {
            Raise(new DraftCreatedEvent(id, sourceId));
        }

        public IStructure CreateStructure(string structureName, IEnumerable<IStructure> structures)
        {
            return new Structure(new StructureId());
        }

        public IOrganization CreateDraft()
        {
            var draftId = new OrganizationId();
            return new Organization(draftId, id);
        }

        private void Apply(DraftCreatedEvent evt)
        {
            this.id = evt.EntityId;
            this.sourceId = evt.SourceId;
        }
    }
}
