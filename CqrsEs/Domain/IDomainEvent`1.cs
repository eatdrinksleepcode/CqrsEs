namespace CqrsEs
{
    public interface IDomainEvent<out TId> : IDomainEvent
    {
        TId EntityId { get; }
    }
}
