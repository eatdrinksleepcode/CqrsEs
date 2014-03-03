using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace CqrsEs
{
    class StructureTests
    {
        [SetUp]
        public void Before()
        {
            DomainEvents.ClearCallbacks();
        }

        [Test]
        public void ShouldRefuseToAddLevelWithNonUniqueName()
        {
            var structureId = new StructureId();
            const string levelName = "New Level";

            var structure = new Structure(structureId);
            var existingLevels = new[] { structure.AddLevel(levelName, Enumerable.Empty<ILevel>()) };

            LevelAddedEvent result = null;
            DomainEvents.Register((LevelAddedEvent evt) =>
            {
                result = evt;
            });

            structure.Invoking(it => it.AddLevel(levelName, existingLevels)).ShouldThrow<Exception>("level names must be unique");
            result.Should().BeNull("domain event should not be raised if validation fails");
        }

        [Test]
        public void ShouldGenerateUniqueIdForNewLevel()
        {
            var structureId = new StructureId();

            var structure = new Structure(structureId);
            var level1 = structure.AddLevel("Level 1", Enumerable.Empty<ILevel>());
            var existingLevels = new[] { level1 };
            var level2 = structure.AddLevel("Level 2", existingLevels);

            level1.Id.Should().NotBe(level2.Id);
        }
    }
}
