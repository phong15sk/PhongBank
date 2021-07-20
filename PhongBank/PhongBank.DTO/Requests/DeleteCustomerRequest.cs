using System;
using System.Collections.Generic;
using System.Text;

namespace PhongBank.DTO.Requests
{
    public class DeleteCustomerRequest
    {
        public DeleteCustomerRequest(int id)
        {
            Id = id;
        }
        public int Id { get; set; }

        public bool Validate()
        {
            return Id != 0;
        }
    }
}
