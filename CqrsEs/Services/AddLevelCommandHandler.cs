namespace CqrsEs
{
    public class AddLevelCommandHandler : CommandHandlerBase<AddLevelCommand>
    {
        public override void Handle(AddLevelCommand command)
        {
            var structure = Repository.GetStructure(command.StructureId);
            var levels = Repository.GetLevels(command.StructureId);
            structure.AddLevel(levels, command.LevelName);
        }
    }
}
