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
    public static class GetCustomersFunction
    {
        [FunctionName("GetCustomers")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "customers")]
            HttpRequest req,
            [Inject] ICustomerService customerService,
            ILogger logger)
        {
            logger.LogInformation($"Calling {nameof(GetCustomersFunction)} : {DateTime.UtcNow}");

            var operationResult = await customerService.GetCustomersAsync().ConfigureAwait(false);

            if (operationResult.Status)
            {
                return new OkObjectResult(operationResult.Data);
            }

            logger.LogError(operationResult.Message);
            return new BadRequestObjectResult(operationResult.Message);
        }
    }
}
