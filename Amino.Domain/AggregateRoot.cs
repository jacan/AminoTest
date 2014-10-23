using System;

namespace Amino.Domain
{
    public abstract class AggregateRoot
    {
        public UniqueId<Guid> Id
        {
            get; 
            protected set;
        }
    }
}
