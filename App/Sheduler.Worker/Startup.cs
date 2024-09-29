using Google.Cloud.Functions.Hosting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sheduler.App;
using Sheduler.Domain;
using Sheduler.Storage;
using Sheduler.Timers.GoogleQueue;

namespace Sheduler.Worker;

public class Startup : FunctionsStartup
{
    // Virtual methods in the base class are overridden
    // here to perform customization.

    public override void ConfigureAppConfiguration(WebHostBuilderContext context, IConfigurationBuilder configuration)
    {
        configuration.AddJsonFile("appsettings.json");
        base.ConfigureAppConfiguration(context, configuration);
    }

    public override void ConfigureServices(WebHostBuilderContext context, IServiceCollection services)
    {
        services.AddDomain();
        services.AddStorage(context.Configuration);
        services.AddGoogleQueueTimers(context.Configuration);
        services.AddScoped<AppService>();
        base.ConfigureServices(context, services);
    }
}