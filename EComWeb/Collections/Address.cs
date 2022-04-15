namespace EComWeb.Collections
{
    public class Address
    {
        public Address(string street, string city, string state, string country, string zipcode)
        {
            Street = street;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipcode;
        }
        private Address (){}
        public string Street { get;  set; }

        public string City { get;  set; }

        public string State { get;  set; }

        public string Country { get;  set; }

        public string ZipCode { get;  set; }
    }
}