namespace CqrsEs
{
    public class RenameLevelCommand : ICommand
    {
        public LevelId LevelId { get; set; }
        public string NewLevelName { get; set; }
    }
}
