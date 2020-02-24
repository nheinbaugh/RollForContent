using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RollForContent.GeneratorService;
using RollForContent.Models.Requests;

namespace RollForContent.Api
{
    public class Generator
    {
        private readonly IRecipeResolver recipeResolver;
        private readonly ILogger log;

        public Generator(IRecipeResolver _recipeResolver, ILogger<Generator> log)
        {
            this.recipeResolver = _recipeResolver;
            this.log = log;
        }

        [FunctionName("Generator")]
        public async Task<IActionResult> GenerateContentFromRecipe(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] ContentGenerationRequest input)
        {
            try
            {
                this.log.LogInformation("C# HTTP trigger function processed a request.");
                var bob = JsonConvert.DeserializeObject<ContentGenerationRequest>(JsonConvert.SerializeObject(input));

                var content = await this.recipeResolver.GenerateContent(input.RecipeName, input.AppliedTags);
                return content != null
                    ? (ActionResult)new OkObjectResult(content)
                    : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }
    }
}
