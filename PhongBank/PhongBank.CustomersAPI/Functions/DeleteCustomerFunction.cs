using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using AzureFunctions.Autofac;
using PhongBank.Services;
using PhongBank.DTO.Requests;

namespace PhongBank.CustomersAPI.Functions
{
    [DependencyInjectionConfig(typeof(ApiBootstrapper))]
    public static class DeleteCustomerFunction
    {
        [FunctionName("DeleteCustomer")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "customers/{id}")]
            HttpRequest req,
            string id,
            [Inject] ICustomerService customerService,
            ILogger logger
        )
        {
            logger.LogInformation($"Calling {nameof(DeleteCustomerFunction)}");

            if (!int.TryParse(id, out var customerId))
            {
                logger.LogError($"Error: Invalid request, id must be integer: {id}");
                return new BadRequestObjectResult($"Invalid request, id must be integer: {id}");
            }

            var deleteCustomerRequest = new DeleteCustomerRequest(customerId);
            var isValid = deleteCustomerRequest.Validate();

            if (!isValid)
            {
                logger.LogError("Error: Invalid request");
                return new BadRequestObjectResult("Invalid request");
            }

            var operationResult = await customerService.DeleteCustomerAsync(deleteCustomerRequest).ConfigureAwait(false);

            if (operationResult.Status)
            {
                return new OkObjectResult("Customer deleted successfully");
            }

            return new BadRequestObjectResult(operationResult.Message);
        }
    }
}
