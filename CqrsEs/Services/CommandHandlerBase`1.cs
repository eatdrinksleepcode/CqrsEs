namespace CqrsEs
{
    public abstract class CommandHandlerBase<TCommand> : CommandHandlerBase, IHandleCommand<TCommand>
        where TCommand : ICommand
    {
        public abstract void Handle(TCommand command);
    }
}
