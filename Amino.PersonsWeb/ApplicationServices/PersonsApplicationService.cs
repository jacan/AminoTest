using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Amino.Domain;
using Amino.Domain.Factories;
using Amino.Domain.Repositories;
using Amino.PersonsRepository.Store;
using Amino.PersonsWeb.Models;
using Castle.Core.Logging;
using Microsoft.Ajax.Utilities;

namespace Amino.PersonsWeb.ApplicationServices
{
    public class PersonsApplicationService : IPersonsApplicationService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IPersonFactory _personFactory;
        private readonly ILogger _logger;

        public PersonsApplicationService(IPersonRepository personRepository, IPersonFactory personFactory, ILogger logger)
        {
            _personRepository = personRepository;
            _personFactory = personFactory;
            _logger = logger;
        }

        public IEnumerable<PersonsViewModel> GetPersons()
        {
            var personsViewModel = new List<PersonsViewModel>();

            try
            {
                using (var repositoryModel = new PersonsRepositoryModel())
                {
                    var persons = repositoryModel
                        .People
                        .OrderByDescending(person => person.Firstname)
                        .ToList();

                    personsViewModel.AddRange(persons.Select(x => new PersonsViewModel
                    {
                        Id = x.DomainId,
                        Fullname = string.Format("{0} {1}", x.Firstname, x.Lastname),
                        Address = x.Address,
                        UserId = x.UserId,
                        Birthdate = x.DateOfBirth.ToString("d. MMMM yyyy", CultureInfo.CurrentUICulture),
                        ZipCodeAndCity = string.Format("{0} {1}", x.ZipCode.ZipCode1, x.ZipCode.City),
                    }));
                }
            }
            catch (Exception e)
            {
                _logger.Error("ApplicationService PersonsService failed to retreive the list of persons", e);
            }

            return personsViewModel;
        }

        public void CreatePerson(CreatePersonViewModel createdPersonViewModel)
        {
            try
            {
                var person = _personFactory.CreateNewPerson(
                    createdPersonViewModel.Firstname,
                    createdPersonViewModel.Lastname,
                    createdPersonViewModel.Address,
                    createdPersonViewModel.SelectZipCode.SelectedZipCode,
                    string.Empty, //createdPersonViewModel.SelectZipCode.SelectedCity,
                    createdPersonViewModel.DateOfBirth);

                _personRepository.CreatePerson(person);
            }
            catch (Exception e)
            {
                _logger.Error("ApplicationService PersonsService failed to create new person", e);
            }
        }


        public ViewPersonViewModel GetPerson(Guid IdOfPerson)
        {
            var viewPersonViewmodel = new ViewPersonViewModel();

            try
            {
                using (var repositoryModel = new PersonsRepositoryModel())
                {
                    var person = repositoryModel.People.SingleOrDefault(x => x.DomainId == IdOfPerson);

                    person.IfNotNull(p =>
                    {
                        viewPersonViewmodel.UserId = person.UserId;
                        viewPersonViewmodel.Name = string.Format("{0} {1}", person.Firstname, person.Lastname);
                        viewPersonViewmodel.Address = person.Address;
                        viewPersonViewmodel.ZipCodeAndCity = string.Format("{0} {1}", person.ZipCode.ZipCode1, person.ZipCode.City);

                        // Somewhat a hack, but then again..
                        viewPersonViewmodel.DateOfBirthdayAndAge = string.Format("{0}, {1} år",
                            person.DateOfBirth.ToString("d MMMM yyyy"), new DateOfBirthValue(person.DateOfBirth).GetAge());
                    });
                }
            }
            catch (Exception e)
            {
                _logger.Error(string.Format("ApplicationService PersonsService failed to retreive inforamtion about a person with ID:", IdOfPerson), e);
            }

            return viewPersonViewmodel;
        }
    }
}