using System.Collections.Generic;

namespace CqrsEs
{
    public interface IDomainRepository
    {
        IOrganization GetOrganization(OrganizationId id);
        IEnumerable<IStructure> GetStructures();
        IStructure GetStructure(StructureId id);
        IEnumerable<ILevel> GetLevels(StructureId structureId);
        ILevel GetLevel(LevelId id);
    }
}