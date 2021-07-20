using System;
using System.Collections.Generic;
using System.Text;

namespace PhongBank.DTO.Requests
{
    public class GetCustomerRequest
    {
        public int Id { get; set; }

        public bool Validate()
        {
            return Id != 0;
        }
    }
}
