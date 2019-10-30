using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using System;

namespace FacturaFunctionApp
{
    public static class AzureServiceHandler
    {
        [FunctionName("FacturaFunctionAppV2")]
        public static void Run([ServiceBusTrigger("pedidosender", "azfunction", Connection = "ServiceBusConnectionString")]string mySbMsg, ILogger log)
        {
            log.LogInformation($"COMENZÓ EL TRIGGER {new DateTime().ToString("dd/MM/yyyy HH:mm:ss")}");
            log.LogInformation($"C# ServiceBus topic trigger function processed message: {mySbMsg}");
            log.LogInformation($"TERMINÓ EL TRIGGER {new DateTime().ToString("dd/MM/yyyy HH:mm:ss")}");
        }
    }
}
