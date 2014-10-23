namespace Amino.Domain
{
    public class AddressValue
    {
        public AddressValue(string streetAddress, string zipCode, string city)
        {
            StreetAddress = streetAddress;
            ZipCode = zipCode;
            City = city;
        }

        public string StreetAddress { get; private set; }
        public string ZipCode { get; private set; }
        public string City { get; private set; }
    }
}
