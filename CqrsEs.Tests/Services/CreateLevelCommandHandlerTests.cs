using Moq;
using Ninject;
using NUnit.Framework;

namespace CqrsEs
{
    class CreateLevelCommandHandlerTests : CommandHandlerTestsBase<CreateLevelCommandHandler>
    {
        [Test]
        public void ShouldExecuteCommandOnDomain()
        {
            var structureId = new StructureId();
            const string levelName = "New Level";

            var structure = new Mock<IStructure>();
            var levels = new[] { kernel.Get<ILevel>() };
            repository.Setup(repo => repo.GetStructure(structureId)).Returns(structure.Object);
            repository.Setup(repo => repo.GetLevels(structureId)).Returns(levels);

            CreateHandler().Handle(new CreateLevelCommand { StructureId = structureId, LevelName = levelName });

            structure.Verify(o => o.CreateLevel(levelName, levels));
        }
    }
}
