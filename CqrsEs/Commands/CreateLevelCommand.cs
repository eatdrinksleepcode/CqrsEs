namespace CqrsEs
{
    public class CreateLevelCommand : OrganizationCommandBase
    {
        public StructureId StructureId { get; set; }
        public string LevelName { get; set; }
    }
}