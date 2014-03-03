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
        public void ShouldAddNewLevelWithUniqueName()
        {
            var structureId = new StructureId();
            const string levelName = "New Level";

            LevelAddedEvent result = null;
            DomainEvents.Register((LevelAddedEvent evt) =>
            {
                result = evt;
            });

            var structure = new Structure(structureId);
            structure.AddLevel(levelName, Enumerable.Empty<ILevel>());

            result.Should().NotBeNull();
            result.StructureId.Should().Be(structureId);
            result.LevelName.Should().Be(levelName);
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
    }
}
