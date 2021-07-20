using PhongBank.DTO.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhongBank.DTO.responses
{
    public class GetCustomerResponse
    {
        public GetCustomerResponse(List<CustomerDisplayModel> customerDisplayModels)
        {
            getCustomerResponses = new List<CustomerDisplayModel>();
            foreach (var item in customerDisplayModels)
            {
                var CustomerResponse = new CustomerDisplayModel();
                CustomerResponse.Id = item.Id;
                CustomerResponse.Name = item.Name;
                CustomerResponse.Address = item.Address;
                getCustomerResponses.Add(CustomerResponse);
            }
        }
    
        public List<CustomerDisplayModel> getCustomerResponses; 
    }
}
