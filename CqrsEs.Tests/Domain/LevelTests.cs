using FluentAssertions;
using NUnit.Framework;

namespace CqrsEs
{
    class LevelTests
    {
        [Test]
        public void ShouldAddNewLevel()
        {
            var levelId = new LevelId();
            var structureId = new StructureId();
            const string levelName = "New Level";

            LevelAddedEvent result = null;
            DomainEvents.Register((LevelAddedEvent evt) =>
            {
                result = evt;
            });

            var level = new Level(levelId, structureId, levelName);

            level.Id.Should().Be(levelId);
            level.Name.Should().Be(levelName);

            result.Should().NotBeNull("domain method should raise event");
            result.EntityId.Should().Be(levelId);
            result.StructureId.Should().Be(structureId);
            result.LevelName.Should().Be(levelName);
        }

        [Test]
        public void RenameLevel()
        {
            LevelRenamedEvent result = null;
            DomainEvents.Register((LevelRenamedEvent evt) =>
            {
                result = evt;
            });

            var level = new Level(new LevelId(), new StructureId(), "Old Name");
            level.Rename("New Name");

            level.Name.Should().Be("New Name");

            result.Should().NotBeNull("domain method should raise event");
            result.NewName.Should().Be("New Name");
        }
    }
}
