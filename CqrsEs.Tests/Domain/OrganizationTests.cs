using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace CqrsEs
{
    class OrganizationTests
    {
        [Test]
        public void ShouldCreateNewOrganization()
        {
            var organizationId = new OrganizationId();

            DraftCreatedEvent result = null;
            DomainEvents.Register((DraftCreatedEvent evt) =>
            {
                result = evt;
            });

            var organization = new Organization(organizationId, null);

            result.Should().NotBeNull("domain method should raise event");
            result.EntityId.Should().Be(organizationId);
            result.SourceId.Should().Be(null);
        }

        [Test]
        public void ShouldCreateNewDraft()
        {
            var organizationId = new OrganizationId();
            var organization = new Organization(organizationId, null);

            DraftCreatedEvent result = null;
            DomainEvents.Register((DraftCreatedEvent evt) =>
            {
                result = evt;
            });

            var draft = organization.CreateDraft();

            result.Should().NotBeNull("domain method should raise event");
        }

        [Test]
        public void ShouldGenerateUniqueIdForNewStructure()
        {
            var organizationId = new OrganizationId();

            var organization = new Organization(organizationId, null);
            var structure1 = organization.CreateStructure("Structure 1", Enumerable.Empty<IStructure>());
            var existingStructures = new[] { structure1 };
            var structure2 = organization.CreateStructure("Structure 2", existingStructures);

            structure1.Id.Should().NotBe(structure2.Id);
        }
    }
}
