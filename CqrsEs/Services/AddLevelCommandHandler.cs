namespace CqrsEs
{
    public class AddLevelCommandHandler : CommandHandlerBase, IHandleCommand<AddLevelCommand>
    {
        public void Handle(AddLevelCommand command)
        {
            var structure = Repository.GetStructure(command.StructureId);
            var levels = Repository.GetLevels(command.StructureId);
            structure.AddLevel(levels, command.LevelName);
        }
    }
}
