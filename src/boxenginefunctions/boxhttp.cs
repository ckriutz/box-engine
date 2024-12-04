using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace boxenginefunctions
{
    public class boxhttp
    {
        private readonly ILogger<boxhttp> _logger;
        private readonly SharedData _sharedData;


        public boxhttp(ILogger<boxhttp> logger, SharedData sharedData)
        {
            _logger = logger;
            _sharedData = sharedData;
        }

        [Function("boxhttp")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
        {
            if (req.Method == "GET")
            {
                _logger.LogInformation("C# HTTP trigger function processed a GET request.");
                return new OkObjectResult(System.Text.Json.JsonSerializer.Serialize(_sharedData.InventoryList));
                //return new OkObjectResult("Hello, World!");
            }
            
            if (req.Method == "POST")
            {
                _logger.LogInformation("C# HTTP trigger function processed a POST request.");
                var reader = new StreamReader(req.Body);
                var body = reader.ReadToEnd();
                var inventory = System.Text.Json.JsonSerializer.Deserialize<Inventory>(body);
                _sharedData.InventoryList.Add(inventory);
                return new OkObjectResult(System.Text.Json.JsonSerializer.Serialize(_sharedData.InventoryList));
                //return new OkObjectResult("Hello, World!");
            }

            return new BadRequestObjectResult("I don't know what you want from me.");
        }
    }
}
