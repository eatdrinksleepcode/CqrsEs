namespace CqrsEs
{
    public class RenameLevelCommand : OrganizationCommandBase
    {
        public LevelId LevelId { get; set; }
        public string NewLevelName { get; set; }
    }
}
