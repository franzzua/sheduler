using Google.Cloud.Functions.Hosting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Sheduler.Domain;
using Sheduler.Storage;
using Sheduler.Timers.GoogleQueue;

namespace Sheduler.Worker;

public class Startup : FunctionsStartup
{
    // Virtual methods in the base class are overridden
    // here to perform customization.

    public override void ConfigureServices(WebHostBuilderContext context, IServiceCollection services)
    {
        services.AddDomain();
        services.AddStorage(context.Configuration);
        services.AddGoogleQueueTimers(context.Configuration);
        base.ConfigureServices(context, services);
    }
}