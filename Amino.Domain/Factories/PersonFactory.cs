using System;

namespace Amino.Domain.Factories
{
    public class PersonFactory : IPersonFactory
    {
        public Person CreateNewPerson(string firstName, string lastName, string address, string zipcode, string city, DateTime dateOfBirth)
        {
            var personsNameValue = new PersonsNameValue(firstName, lastName);
            var addressValue = new AddressValue(address, zipcode, city);
            var dateOfBirthValue = new DateOfBirthValue(dateOfBirth);

            return new Person(
                new UniqueId<Guid>(Guid.NewGuid()),
                new UniqueId<int>(new Random().Next()),
                personsNameValue,
                addressValue,
                dateOfBirthValue);
        }
    }
}
