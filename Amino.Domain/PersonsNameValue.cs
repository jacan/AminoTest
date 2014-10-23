namespace Amino.Domain
{
    public class PersonsNameValue
    {
        public PersonsNameValue(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public string Firstname { get; private set; }

        public string Lastname { get; private set; }

        public static implicit operator string(PersonsNameValue personsName)
        {
            return string.Format("{0} {1}", personsName.Firstname, personsName.Lastname);
        }
    }
}
