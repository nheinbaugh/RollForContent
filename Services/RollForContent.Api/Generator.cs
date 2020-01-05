using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RollForContent.Common;

namespace RollForContent.Api
{
    public class Generator
    {
        private readonly GlobalRandom random;
        private readonly ILogger log;

        public Generator(GlobalRandom random, ILogger<Generator> log)
        {
            this.random = random;
            this.log = log;
        }

        [FunctionName("Generator")]
        public async Task<IActionResult> GenerateContentFromRecipe(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req)
        {
            this.log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;
            var firstRnadom = this.random.Instance.Next(1, 5);
            var secondRandom = this.random.Instance.Next(1, 5);

            return name != null
                ? (ActionResult)new OkObjectResult($"Hello, {name}, {firstRnadom}, {secondRandom}")
                : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }
    }
}
