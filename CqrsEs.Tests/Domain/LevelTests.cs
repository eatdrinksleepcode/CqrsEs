using FluentAssertions;
using NUnit.Framework;

namespace CqrsEs
{
    class LevelTests
    {
        [Test]
        public void ShouldAddNewLevel()
        {
            var structureId = new StructureId();
            const string levelName = "New Level";

            LevelAddedEvent result = null;
            DomainEvents.Register((LevelAddedEvent evt) =>
            {
                result = evt;
            });

            new Level(new LevelId(), structureId, levelName);

            result.Should().NotBeNull("domain method should raise event");
            result.StructureId.Should().Be(structureId);
            result.LevelName.Should().Be(levelName);
        }
    }
}
