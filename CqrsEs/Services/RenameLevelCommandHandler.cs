namespace CqrsEs
{
    public class RenameLevelCommandHandler : CommandHandlerBase<RenameLevelCommand>
    {
        public override void Handle(RenameLevelCommand command)
        {
            var level = Repository.GetLevel(command.LevelId);
            level.Rename(command.NewLevelName);
        }
    }
}
