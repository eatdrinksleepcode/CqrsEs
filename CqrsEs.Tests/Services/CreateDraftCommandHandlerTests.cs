using Moq;
using Ninject;
using NUnit.Framework;

namespace CqrsEs
{
    class CreateDraftCommandHandlerTests : CommandHandlerTestsBase<CreateDraftCommandHandler>
    {
        [Test]
        public void ShouldExecuteCommandOnDomain()
        {
            var sourceOrganizationId = new OrganizationId();

            var sourceOrganization = new Mock<IOrganization>();
            repository.Setup(repo => repo.GetOrganization(sourceOrganizationId)).Returns(sourceOrganization.Object);

            CreateHandler().Handle(new CreateDraftCommand { SourceId = sourceOrganizationId });

            sourceOrganization.Verify(o => o.CreateDraft());
        }
    }
}
