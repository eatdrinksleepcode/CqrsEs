namespace CqrsEs
{
    public class CreateLevelCommand : ICommand
    {
        public StructureId StructureId { get; set; }
        public string LevelName { get; set; }
    }
}