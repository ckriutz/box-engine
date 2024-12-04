using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace boxenginefunctions
{
    public class boxsbqueue
    {
        private readonly ILogger<boxsbqueue> _logger;
        private readonly SharedData _sharedData;

        public boxsbqueue(ILogger<boxsbqueue> logger, SharedData sharedData)
        {
            _logger = logger;
            _sharedData = sharedData;
        }

        [Function(nameof(boxsbqueue))]
        public async Task Run(
            [ServiceBusTrigger("boxservicebusqueue", Connection = "AzureWebJobsServiceBus")]
            ServiceBusReceivedMessage message,
            ServiceBusMessageActions messageActions)
        {
            _logger.LogInformation("Message ID: {id}", message.MessageId);
            _logger.LogInformation("Message Body: {body}", message.Body);
            _logger.LogInformation("Message Content-Type: {contentType}", message.ContentType);


            var inventoryItem = System.Text.Json.JsonSerializer.Deserialize<Inventory>(message.Body.ToString());
            if (inventoryItem != null)
            {
                _sharedData.InventoryList.Add(inventoryItem);
            }
            else
            {
                _logger.LogError("Failed to deserialize message body to InventoryItem.");
            }

            // Complete the message
            await messageActions.CompleteMessageAsync(message);
        }
    }
}
