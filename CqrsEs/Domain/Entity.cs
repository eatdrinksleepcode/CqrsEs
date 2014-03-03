using ReflectionMagic;

namespace CqrsEs
{
    public class Entity
    {
        protected void Raise(IDomainEvent evt)
        {
            ApplyLocal(evt);
            DomainEvents.Raise((dynamic)evt);
        }

        protected void ApplyLocal(IDomainEvent evt)
        {
            this.AsDynamic().Apply(evt);
        }
    }
}