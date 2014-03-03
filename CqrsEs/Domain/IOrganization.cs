using System.Collections.Generic;

namespace CqrsEs
{
    public interface IOrganization
    {
        IStructure CreateStructure(string structureName, IEnumerable<IStructure> structures);
        IOrganization CreateDraft();
    }
}