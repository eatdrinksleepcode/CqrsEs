using Moq;
using NUnit.Framework;

namespace CqrsEs
{
    class RenameLevelCommandHandlerTests : CommandHandlerTestsBase<RenameLevelCommandHandler>
    {
        [Test]
        public void ShouldRenameLevel()
        {
            var levelId = new LevelId();
            const string newLevelName = "New Level";

            var level = new Mock<ILevel>();
            repository.Setup(repo => repo.GetLevel(levelId)).Returns(level.Object);

            CreateHandler().Handle(new RenameLevelCommand { LevelId = levelId, NewLevelName = newLevelName });

            level.Verify(it => it.Rename(newLevelName));
        }
    }
}
