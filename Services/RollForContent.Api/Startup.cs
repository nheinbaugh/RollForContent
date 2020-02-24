using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters.Json.Internal;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RollForContent.Api;
using RollForContent.Common;
using RollForContent.Data.Attribute;
using RollForContent.Data.Interfaces;
using RollForContent.Data.Recipes;
using RollForContent.GeneratorService;
using RollForContent.GeneratorService.Interfaces;

[assembly: FunctionsStartup(typeof(RollForContent.Api.Startup))]
namespace RollForContent.Api
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            // How is this workaround still required???? 
            // maybe I should follow up with the team: https://github.com/Azure/azure-functions-host/issues/3370
            builder.Services.AddTransient<IConfigureOptions<MvcOptions>, MvcJsonMvcOptionsSetup>();

            builder.Services.AddLogging();
            builder.Services.AddSingleton(s => { return new GlobalRandom(); });
            builder.Services.AddSingleton<INumericalAttributeProcessor, NumericalAttributeProcessor>();
            builder.Services.AddSingleton<IAttributeProcessor, AttributeProcessor>();
            builder.Services.AddSingleton<IRecipeResolver, RecipeResolver>();

            builder.Services.AddSingleton<IAttributeRepository, AttributeRepository>();
            builder.Services.AddSingleton<IRecipeRepository, RecipeRepository>();

        }
    }
}