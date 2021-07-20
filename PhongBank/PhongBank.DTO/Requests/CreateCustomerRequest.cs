using System;
using System.Collections.Generic;
using System.Text;

namespace PhongBank.DTO.Requests
{
    public class CreateCustomerRequest
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public bool Validate()
        {
            return !string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Address);
        }
    }
}
