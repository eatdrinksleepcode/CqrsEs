using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace CqrsEs
{
    class StructureTests
    {
        [Test]
        public void ShouldRefuseToCreateLevelWithNonUniqueName()
        {
            var structureId = new StructureId();
            const string levelName = "New Level";

            var structure = new Structure(structureId);
            var existingLevels = new[] { structure.CreateLevel(levelName, Enumerable.Empty<ILevel>()) };

            LevelCreatedEvent result = null;
            DomainEvents.Register((LevelCreatedEvent evt) =>
            {
                result = evt;
            });

            structure.Invoking(it => it.CreateLevel(levelName, existingLevels)).ShouldThrow<Exception>("level names must be unique");
            result.Should().BeNull("domain event should not be raised if validation fails");
        }

        [Test]
        public void ShouldGenerateUniqueIdForNewLevel()
        {
            var structureId = new StructureId();

            var structure = new Structure(structureId);
            var level1 = structure.CreateLevel("Level 1", Enumerable.Empty<ILevel>());
            var existingLevels = new[] { level1 };
            var level2 = structure.CreateLevel("Level 2", existingLevels);

            level1.Id.Should().NotBe(level2.Id);
        }
    }
}
