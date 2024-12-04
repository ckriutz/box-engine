using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace boxenginefunctions
{
    public class boxblob
    {
        private readonly ILogger<boxblob> _logger;

        public boxblob(ILogger<boxblob> logger)
        {
            _logger = logger;
        }

        [Function(nameof(boxblob))]
        public async Task Run([BlobTrigger("things/{name}", Connection = "BlobStorageConnString")] Stream stream, string name)
        {
            using var blobStreamReader = new StreamReader(stream);
            var content = await blobStreamReader.ReadToEndAsync();
            _logger.LogInformation($"C# Blob trigger function Processed blob\n Name: {name} \n Data: {content}");
        }
    }
}
