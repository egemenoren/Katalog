using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katalog.Order.Application.Dtos
{
    public class AddressDto
    {
        public string District { get; private set; }
        public string City { get; private set; }
        public string Street { get; private set; }
        public string ZipCode { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string MobileNumber { get; private set; }
    }
}
