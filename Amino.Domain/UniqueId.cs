namespace Amino.Domain
{
    public class UniqueId<T>
    {
        public UniqueId(T id)
        {
            Id = id;
        }

        public T Id { get; private set; }

        public static implicit operator T(UniqueId<T> uniqueId)
        {
            return uniqueId.Id;
        }
    }
}
