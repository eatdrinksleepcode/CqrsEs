namespace CqrsEs
{
    public class AddLevelCommand : ICommand
    {
        public StructureId StructureId { get; set; }
        public string LevelName { get; set; }
    }
}