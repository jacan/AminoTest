using System;

namespace Amino.Domain
{
    public class Person : AggregateRoot
    {
        public Person(UniqueId<Guid> id, UniqueId<int> userId , PersonsNameValue name, AddressValue address, DateOfBirthValue dateOfBirth)
        {
            Id = id;
            UserId = userId;
            Name = name;
            Address = address;
            DateOfBirth = dateOfBirth;
        }

        public int UserId { get; private set; }

        public DateOfBirthValue DateOfBirth { get; private set; }

        public AddressValue Address { get; private set; }

        public PersonsNameValue Name { get; private set; }
    }
}
