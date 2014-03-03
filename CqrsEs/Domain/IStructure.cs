using System.Collections.Generic;

namespace CqrsEs
{
    public interface IStructure
    {
        ILevel CreateLevel(string levelName, IEnumerable<ILevel> levels);
        StructureId Id { get; }
    }
}