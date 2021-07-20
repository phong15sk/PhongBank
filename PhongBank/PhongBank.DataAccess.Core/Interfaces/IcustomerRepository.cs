using PhongBank.Core;
using PhongBank.DataAccess.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhongBank.DataAccess.Core.Interfaces
{
    public interface IcustomerRepository
    {
        Task<OperationResult<List<Customer>>> GetCustomersAsync();
        Task<OperationResult<Customer>> GetCustomerAsync(int customerId);
        Task<OperationResult<Customer>> CreateCustomerAsync(Customer customer);
        Task<OperationResult<Customer>> UpdateCustomerAsync(Customer customer);
        Task<OperationResult> DeleteCustomerAsync(int customerId);
    }
}
