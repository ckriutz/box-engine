using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace boxenginefunctions
{
    public class boxtimer
    {
        private readonly ILogger _logger;
        private readonly SharedData _sharedData;

        public boxtimer(ILoggerFactory loggerFactory, SharedData sharedData)
        {
            _logger = loggerFactory.CreateLogger<boxtimer>();
            _sharedData = sharedData;
        }

        [Function("boxtimer")]
        public void Run([TimerTrigger("* * * * *")] TimerInfo myTimer)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            var random = new Random();
            int index = random.Next(_sharedData.InventoryList.Count);
            Inventory i = _sharedData.InventoryList.ElementAt(index);
            i.Quantity++;
            _sharedData.InventoryList[index] = i;
            
            if (myTimer.ScheduleStatus is not null)
            {
                _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
            }
        }
    }
}
