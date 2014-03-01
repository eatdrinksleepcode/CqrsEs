namespace CqrsEs
{
    public interface IHandleCommand
    {
    }

    public interface IHandleCommand<T> : IHandleCommand where T : ICommand
    {
        void Handle(T command);
    }
}