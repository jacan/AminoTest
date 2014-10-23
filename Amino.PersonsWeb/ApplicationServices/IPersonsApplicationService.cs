using System;
using System.Collections.Generic;
using Amino.PersonsWeb.Models;

namespace Amino.PersonsWeb.ApplicationServices
{
    public interface IPersonsApplicationService
    {
        IEnumerable<PersonsViewModel> GetPersons();
        void CreatePerson(CreatePersonViewModel createdPersonViewModel);

        ViewPersonViewModel GetPerson(Guid IdOfPerson);
    }
}
