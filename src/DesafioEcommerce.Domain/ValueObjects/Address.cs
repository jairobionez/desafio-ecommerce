using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DesafioEcommerce.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public Address(string street, string city, string state, string zipCode, string neighborhood, string number)
        {
            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
            Neighborhood = neighborhood;
            Number = number;
        }
                
        public string Street { get; private set; }

        public string City { get; private set; }

        public string State { get; private set; }

        public string ZipCode { get; private set; }

        public string Neighborhood { get; private set; }

        public string Number { get; private set; }
    }
}
