using System.Collections.Generic;

namespace CqrsEs
{
    public interface IOrganization
    {
        void CreateStructure(string structureName, IEnumerable<IStructure> structures);
    }
}