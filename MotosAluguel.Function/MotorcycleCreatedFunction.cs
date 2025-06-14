using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace MotosAluguel.Function
{
    public class MotorcycleCreatedFunction
    {
        private readonly ILogger _logger;

        public MotorcycleCreatedFunction(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<MotorcycleCreatedFunction>();
        }

        [Function(nameof(MotorcycleCreatedFunction))]
        public async Task Run(
       [ServiceBusTrigger("motorcycle.created","motorcycle.2024", Connection = "ServiceBusConnection")]
        ServiceBusReceivedMessage message)
        {
            await Task.Yield();

            _logger.LogInformation("Message Body: {body}", message.Body);

            _logger.LogInformation("User Email successfuly sent!");
        }

        [Function("ABC")]
        public async Task RunV2(
       [ServiceBusTrigger("motorcycle.created", Connection = "ServiceBusConnection")]
        ServiceBusReceivedMessage message)
        {
            await Task.Yield();

            _logger.LogInformation("Message Body: {body}", message.Body);

            _logger.LogInformation("User Email successfuly sent!");
        }
    }
}
