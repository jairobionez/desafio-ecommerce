using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DesafioEcommerce.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public Address(string street, string city, string state, string zipCode, string neighborhood, int number)
        {
            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
            Neighborhood = neighborhood;
            Number = number;
        }
                
        [MaxLength(100)]
        [DisplayName("Rua")]
        public string Street { get; private set; }

        [MaxLength(100)]
        [DisplayName("Cidade")]
        public string City { get; private set; }

        [MaxLength(50)]
        [DisplayName("Estado")]
        public string State { get; private set; }

        [MaxLength(8)]
        [DisplayName("CEP")]
        public string ZipCode { get; private set; }

        [DisplayName("Bairro")]
        [MaxLength(30)]
        public string Neighborhood { get; private set; }

        [DisplayName("Numero")]
        public int Number { get; private set; }
    }
}
