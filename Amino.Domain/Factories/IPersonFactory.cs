using System;

namespace Amino.Domain.Factories
{
    public interface IPersonFactory
    {
        Person CreateNewPerson(string firstName, string lastName, string address, string zipcode,  string city, DateTime dateOfBirth);
    }
}
