using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using RollForContent.Api;
using RollForContent.Common;

[assembly: FunctionsStartup(typeof(RollForContent.Api.Startup))]
namespace RollForContent.Api
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            System.Console.WriteLine("Hello world");
            //// The Microsoft.Extensions.DependencyInjection.ServiceCollection
            //// has extension methods provided by other .NET Core libraries to
            //// regsiter services with DI.
            //var serviceCollection = new ServiceCollection();

            //// The Microsoft.Extensions.Logging package provides this one-liner
            //// to add logging services.
            //serviceCollection.AddLogging();

            //var containerBuilder = new ContainerBuilder();

            //// Once you've registered everything in the ServiceCollection, call
            //// Populate to bring those registrations into Autofac. This is
            //// just like a foreach over the list of things in the collection
            //// to add them to Autofac.
            //containerBuilder.Populate(serviceCollection);

            //// Make your Autofac registrations. Order is important!
            //// If you make them BEFORE you call Populate, then the
            //// registrations in the ServiceCollection will override Autofac
            //// registrations; if you make them AFTER Populate, the Autofac
            //// registrations will override. You can make registrations
            //// before or after Populate, however you choose.
            //containerBuilder.RegisterType<GlobalRandom>().AsSelf();

            //// Creating a new AutofacServiceProvider makes the container
            //// available to your app using the Microsoft IServiceProvider
            //// interface so you can use those abstractions rather than
            //// binding directly to Autofac.
            //var container = containerBuilder.Build();
            //var serviceProvider = new AutofacServiceProvider(container);

            builder.Services.AddSingleton(s => { return new GlobalRandom(); });
            //builder.Services.AddSingleton<INumericalAttributeProcessor, NumericalAttributeProcessor>();

        }
    }
}