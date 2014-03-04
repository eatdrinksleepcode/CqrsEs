namespace CqrsEs
{
    public class CreateStructureCommandHandler : CommandHandlerBase<CreateStructureCommand>
    {
        public override void Handle(CreateStructureCommand command)
        {
            var organization = Repository.GetOrganization(command.OrganizationId);
            var structures = Repository.GetStructures();
            organization.CreateStructure(command.StructureName, structures);
        }
    }
}
