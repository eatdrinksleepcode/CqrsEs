namespace CqrsEs
{
    public class RenameLevelCommandHandler : CommandHandlerBase, IHandleCommand<RenameLevelCommand>
    {
        public void Handle(RenameLevelCommand command)
        {
            var level = Repository.GetLevel(command.LevelId);
            level.Rename(command.NewLevelName);
        }
    }
}
