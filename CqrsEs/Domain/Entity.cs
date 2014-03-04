using System.Collections;
using System.Collections.Generic;
using ReflectionMagic;

namespace CqrsEs
{
    public class Entity
    {
        protected Entity()
        {
        }

        protected Entity(IEnumerable<IDomainEvent> events)
        {
            foreach (var evt in events)
            {
                ApplyLocal(evt);
            }
        }

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