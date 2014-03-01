using Moq;
using Ninject;
using NUnit.Framework;

namespace CqrsEs
{
    class AddStructureCommandHandlerTests : CommandHandlerTestsBase<AddStructureCommandHandler>
    {
        [Test]
        public void ShouldExecuteCommandOnDomain()
        {
            var organizationId = new OrganizationId();
            const string structureName = "New Structure";

            var organization = new Mock<IOrganization>();
            var structures = new[] {kernel.Get<IStructure>()};
            repository.Setup(repo => repo.GetOrganization(organizationId)).Returns(organization.Object);
            repository.Setup(repo => repo.GetStructures(organizationId)).Returns(structures);

            CreateHandler().Handle(new AddStructureCommand { OrganizationId = organizationId, StructureName = structureName});

            organization.Verify(o => o.AddStructure(structures, structureName));
        }
    }
}
