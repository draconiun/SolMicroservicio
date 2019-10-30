using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FacturaFunctionApp
{
    public static class AzureServiceHandler
    {
        [FunctionName("FacturaFunctionApp")]
        public static void Run([ServiceBusTrigger("pedidosender", "azfunction", Connection = "AzureWebJobsStorage")]string mySbMsg, ILogger log)
        {
            log.LogInformation($"C# ServiceBus topic trigger function processed message: {mySbMsg}");
        }
    }
}
