namespace CqrsEs
{
    public class CreateStructureCommand : OrganizationCommandBase
    {
        public string StructureName { get; set; }
    }
}