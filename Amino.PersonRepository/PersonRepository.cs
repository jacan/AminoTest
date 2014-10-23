using System;
using System.Linq;
using Amino.Domain.Repositories;
using Amino.PersonsRepository.Store;
using Castle.Core.Logging;

namespace Amino.PersonsRepository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ILogger _logger;
        public PersonRepository(ILogger logger)
        {
            _logger = logger;
        }
        
        public void CreatePerson(Domain.Person newPerson)
        {
            try
            {
                using (var personRepositoryModel = new PersonsRepositoryModel())
                {
                    var personDto = new Person
                    {
                        DomainId = newPerson.Id,
                        UserId = newPerson.UserId,
                        Firstname = newPerson.Name.Firstname,
                        Lastname = newPerson.Name.Lastname,
                        Address = newPerson.Address.StreetAddress,
                        ZipCode =
                            personRepositoryModel.ZipCodes.SingleOrDefault(
                                x => x.ZipCode1.Equals(newPerson.Address.ZipCode)),
                        DateOfBirth = newPerson.DateOfBirth.Date,
                    };

                    personRepositoryModel.People.Add(personDto);
                    personRepositoryModel.SaveChanges();
                }
            }
            catch(Exception e)
            {
                _logger.Error("Add person to persistence store failed!", e);
            }
        }
    }
}
