using Google.Cloud.Functions.Framework;
using Google.Cloud.Functions.Hosting;
using Microsoft.AspNetCore.Http;
using Sheduler.App;
using Sheduler.Contracts.Contracts;
using Sheduler.Domain.Services;

namespace Sheduler.Worker;

[FunctionsStartup(typeof(Startup))]
public class Worker(AppService appService) : IHttpFunction
{
    public async Task HandleAsync(HttpContext context)
    {
        var id = context.Request.Query["id"];
        await appService.RunSchedule(id.First()!);
        
    }
}