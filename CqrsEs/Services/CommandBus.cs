using Ninject;
using Ninject.Parameters;

namespace CqrsEs
{
    public class CommandBus
    {
        private readonly EventStore eventStore;
        private readonly IKernel kernel;

        public CommandBus(EventStore eventStore, IKernel kernel)
        {
            this.eventStore = eventStore;
            this.kernel = kernel;
        }

        public void DeliverCommand<TCommand>(TCommand command) where TCommand : ICommand
        {
            DomainEvents.Register((DraftCreatedEvent it) => eventStore.Add(it.EntityId, it));
            DomainEvents.Register(
                (IDomainEvent it) => { if (!(it is DraftCreatedEvent)) eventStore.Add(command.OrganizationId, it); });
            var handler = kernel.Get<IHandleCommand<TCommand>>(new Parameter("OrganizationId", command.OrganizationId, true));
            handler.Handle(command);
            DomainEvents.ClearCallbacks();
        }
    }
}
