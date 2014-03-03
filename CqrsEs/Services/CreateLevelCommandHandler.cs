namespace CqrsEs
{
    public class CreateLevelCommandHandler : CommandHandlerBase<CreateLevelCommand>
    {
        public override void Handle(CreateLevelCommand command)
        {
            var structure = Repository.GetStructure(command.StructureId);
            var levels = Repository.GetLevels(command.StructureId);
            structure.CreateLevel(command.LevelName, levels);
        }
    }
}
