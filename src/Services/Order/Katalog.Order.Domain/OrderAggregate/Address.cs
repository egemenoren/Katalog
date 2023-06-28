using Katalog.Order.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katalog.Order.Domain.OrderAggregate
{

    public class Address:ValueObject
    {
        public string District { get; private set; }
        public string City { get; private set; }
        public string Street { get; private set; }
        public string ZipCode { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string MobileNumber { get; private set; }

        public Address(string district, string city, string street, string zipCode, string name, string surname, string mobileNumber)
        {
            District = district;
            City = city;
            Street = street;
            ZipCode = zipCode;
            Name = name;
            Surname = surname;
            MobileNumber = mobileNumber;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return District;
            yield return City;
            yield return Street;
            yield return ZipCode;
            yield return Name;
            yield return Surname;
            yield return MobileNumber;
        }
    }
}
