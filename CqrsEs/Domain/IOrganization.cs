using System.Collections.Generic;

namespace CqrsEs
{
    public interface IOrganization
    {
        void AddStructure(IEnumerable<IStructure> structures, string structureName);
    }
}