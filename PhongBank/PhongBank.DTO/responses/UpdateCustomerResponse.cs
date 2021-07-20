﻿using PhongBank.DTO.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhongBank.DTO.responses
{
    public class UpdateCustomerResponse
    {
        public UpdateCustomerResponse(CustomerDisplayModel customerDisplayModel)
        {
            Id = customerDisplayModel.Id;
            Name = customerDisplayModel.Name;
            Address = customerDisplayModel.Address;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
