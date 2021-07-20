using PhongBank.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using PhongBank.DTO.Models;
using PhongBank.DTO.Requests;
using PhongBank.DTO.responses;
using PhongBank.DataAccess.Core.Models;
using PhongBank.DataAccess.Core.Interfaces;
using PhongBank.DataAccess.Dapper.Repositories;
using Microsoft.Extensions.Logging;

namespace PhongBank.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IcustomerRepository _customerRepository;
        private readonly ILogger<CustomerService> _logger;

        public CustomerService(CustomerRepository customerRepository, ILogger<CustomerService> logger)
        {
            if (customerRepository == null)
            {
                throw new ArgumentNullException(nameof(customerRepository));
            }

            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            _customerRepository = customerRepository;
            _logger = logger;
        }

        public async Task<OperationResult<CreateCustomerResponse>> CreateCustomerAsync(CreateCustomerRequest request)
        {
            _logger.LogInformation($"Calling {nameof(CreateCustomerAsync)}");

            var isValid = request.Validate();
            if (!isValid)
            {
                _logger.LogError("Error: Invalid request");
                return OperationResult<CreateCustomerResponse>.Failure("Invalid request. Cannot create customer");
            }

            var operationResult = await _customerRepository.CreateCustomerAsync(new Customer
            {
                Name = request.Name,
                Address = request.Address
            }).ConfigureAwait(false);

            if (operationResult.Status)
            {
                _logger.LogInformation("Customer created successfully");

                var createdCustomer = operationResult.Data;
                return OperationResult<CreateCustomerResponse>.Success(new CreateCustomerResponse(new CustomerDisplayModel(createdCustomer.Name, createdCustomer.Address)));
            }

            _logger.LogInformation("Error: Cannot create customer");
            return OperationResult<CreateCustomerResponse>.Failure("Error: Cannot create customer");
        }

        public async Task<OperationResult<UpdateCustomerResponse>> UpdateCustomerAsync(UpdateCustomerRequest request)
        {
            _logger.LogInformation($"Calling {nameof(UpdateCustomerAsync)}");

            var isValid = request.Validate();
            if (!isValid)
            {
                _logger.LogError("Error: Invalid request, cannot update customer");
                return OperationResult<UpdateCustomerResponse>.Failure("Invalid request, cannot update customer");
            }

            var operationResult = await _customerRepository.UpdateCustomerAsync(new Customer
            {
                Id = request.Id,
                Name = request.Name,
                Address = request.Address
            }).ConfigureAwait(false);

            if (operationResult.Status)
            {
                _logger.LogInformation("Customer updated successfully");

                var updatedCustomer = operationResult.Data;
                return OperationResult<UpdateCustomerResponse>.Success(new UpdateCustomerResponse(new CustomerDisplayModel(updatedCustomer.Name, updatedCustomer.Address)));
            }

            _logger.LogError("Error: Cannot update customer");
            return OperationResult<UpdateCustomerResponse>.Failure("Cannot update customer");
        }

        public async Task<OperationResult<GetCustomerResponse>> GetCustomersAsync()
        {
            

            var operationResult = await _customerRepository.GetCustomersAsync().ConfigureAwait(false);

            if (operationResult.Status)
            {
                _logger.LogInformation("Retrieved customers successfully");

                var displayCustomers = operationResult.Data.Select(x => new CustomerDisplayModel(x.Name, x.Address, x.Id)).ToList();
                return OperationResult<GetCustomerResponse>.Success(new GetCustomerResponse(displayCustomers));
            }

            _logger.LogError("Error: Cannot get customers");
            return OperationResult<GetCustomerResponse>.Failure("Cannot get customers");
        }

        public async Task<OperationResult<CustomerDisplayModel>> GetSpecificCustomerAsync(GetSpecificCustomerRequest request)
        {
            var isValid = request.Validate();

            if (!isValid)
            {
                _logger.LogError("Error: Invalid request");
                return OperationResult<CustomerDisplayModel>.Failure("Invalid request");
            }

            var operationResult = await _customerRepository.GetCustomerAsync(request.Id).ConfigureAwait(false);

            if (operationResult.Status)
            {
                _logger.LogInformation("Customer retrieved successfully");

                return OperationResult<CustomerDisplayModel>.Success(new CustomerDisplayModel(operationResult.Data.Name, operationResult.Data.Address));
            }

            _logger.LogError("Error: Cannot get specific customer");
            return OperationResult<CustomerDisplayModel>.Failure("Cannot get specific customer");
        }

        public async Task<OperationResult> DeleteCustomerAsync(DeleteCustomerRequest request)
        {
            var isValid = request.Validate();

            if (!isValid)
            {
                _logger.LogError("Error: Invalid request");

                return OperationResult.Failure("Invalid request");
            }

            var operationResult = await _customerRepository.DeleteCustomerAsync(request.Id).ConfigureAwait(false);

            if (operationResult.Status)
            {
                _logger.LogInformation("Customer deleted successfully");

                return OperationResult.Success();

            }

            _logger.LogError("Error: Cannot delete customer");

            return OperationResult.Failure("Cannot delete customer");
        }
    }
}
