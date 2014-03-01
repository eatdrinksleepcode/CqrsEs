using System.Collections.Generic;

namespace CqrsEs
{
    public interface IStructure
    {
        void AddLevel(IEnumerable<ILevel> levels, string levelName);
    }
}