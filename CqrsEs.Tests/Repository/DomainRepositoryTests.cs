using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace CqrsEs.Repository
{
    class DomainRepositoryTests
    {
        [Test]
        public void ShouldReconstituteLevelFromCreatedEvent()
        {
            var events = new List<IDomainEvent>();
            DomainEvents.Register((IDomainEvent evt) => events.Add(evt));

            var levelId = new LevelId();
            var level = new Level(levelId, new StructureId(), "Level Name");

            var repo = new DomainRepository(events);

            var clonedLevel = repo.GetLevel(levelId);
            clonedLevel.ShouldBeEquivalentTo(level);
        }

        [Test]
        public void ShouldReconstituteSpecificLevelFromCreatedEvent()
        {
            var events = new List<IDomainEvent>();
            DomainEvents.Register((IDomainEvent evt) => events.Add(evt));

            var levelId1 = new LevelId();
            var level1 = new Level(levelId1, new StructureId(), "Level 1 Name");
            var levelId2 = new LevelId();
            var level2 = new Level(levelId2, new StructureId(), "Level 2 Name");

            var repo = new DomainRepository(events);

            var clonedLevel = repo.GetLevel(levelId1);
            clonedLevel.ShouldBeEquivalentTo(level1);
        }

        [Test]
        public void ShouldReconstituteLevelFromMultipleEvents()
        {
            var events = new List<IDomainEvent>();
            DomainEvents.Register((IDomainEvent evt) => events.Add(evt));

            var levelId = new LevelId();
            var level = new Level(levelId, new StructureId(), "Old Name");
            level.Rename("New Name");

            var repo = new DomainRepository(events);

            var clonedLevel = repo.GetLevel(levelId);
            clonedLevel.ShouldBeEquivalentTo(level);
        }

    }
}
