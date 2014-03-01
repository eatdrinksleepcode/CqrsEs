namespace CqrsEs
{
    public class AddStructureCommandHandler : CommandHandlerBase, IHandleCommand<AddStructureCommand>
    {
        public void Handle(AddStructureCommand command)
        {
            var organization = Repository.GetOrganization(command.OrganizationId);
            var structures = Repository.GetStructures(command.OrganizationId);
            organization.AddStructure(structures, command.StructureName);
        }
    }
}
