namespace CqrsEs
{
    public class CreateStructureCommand : ICommand
    {
        public OrganizationId OrganizationId { get; set; }
        public string StructureName { get; set; }
    }
}