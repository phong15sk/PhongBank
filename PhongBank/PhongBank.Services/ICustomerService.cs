
using System.Collections.Generic;
using System.Threading.Tasks;
using PhongBank.Core;
using PhongBank.DTO.Models;
using PhongBank.DTO.Requests;
using PhongBank.DTO.responses;

namespace PhongBank.Services
{
    public interface ICustomerService
    {
        Task<OperationResult<CreateCustomerResponse>> CreateCustomerAsync(CreateCustomerRequest request);
        Task<OperationResult<UpdateCustomerResponse>> UpdateCustomerAsync(UpdateCustomerRequest request);
        Task<OperationResult<GetCustomerResponse>> GetCustomersAsync();
        Task<OperationResult<CustomerDisplayModel>> GetSpecificCustomerAsync(GetSpecificCustomerRequest request);
        Task<OperationResult> DeleteCustomerAsync(DeleteCustomerRequest request);
    }
}
