using PhongBank.DTO.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhongBank.DTO.Requests
{
    public class UpdateCustomerRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public bool Validate()
        {
            return Id != 0;
        }
    }
}
