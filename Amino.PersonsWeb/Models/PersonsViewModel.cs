using System;

namespace Amino.PersonsWeb.Models
{
    public class PersonsViewModel
    {
        public Guid Id
        {
            get; set;
        }

        public int UserId
        {
            get; set;
        }

        public string Fullname
        {
            get; set;
        }

        public string Address
        {
            get; set;
        }

        public string ZipCodeAndCity
        {
            get; set;
        }

        public string Birthdate
        {
            get; set;
        }
    }
}