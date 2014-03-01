namespace CqrsEs
{
    public class AddStructureCommand : ICommand
    {
        public OrganizationId OrganizationId { get; set; }
        public string StructureName { get; set; }
    }
}