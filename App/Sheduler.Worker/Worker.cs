using Sheduler.App;

namespace Sheduler.Worker;

public static class Worker
{
    public static async Task<IResult> HandleAsync(string id, AppService appService)
    {
        await appService.RunSchedule(id);
        return Results.NoContent();
    }
}