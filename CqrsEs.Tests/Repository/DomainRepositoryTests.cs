using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace CqrsEs.Repository
{
    class DomainRepositoryTests
    {
        [Test]
        public void ShouldReconstituteLevelFromEvents()
        {
            var events = new List<IDomainEvent>();
            DomainEvents.Register((IDomainEvent evt) => events.Add(evt));

            var structureId = new StructureId();
            var levelId = new LevelId();
            const string levelName = "Level Name";
            var level = new Level(levelId, structureId, levelName);

            var repo = new DomainRepository(events);

            var clonedLevel = repo.GetLevel(levelId);
            clonedLevel.ShouldBeEquivalentTo(level);
        }
    }
}
