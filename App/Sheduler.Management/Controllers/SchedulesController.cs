using Sheduler.App;

namespace Sheduler.Management.Controllers;

public static class SchedulesController
{
    public static RouteGroupBuilder Map(WebApplication app)
    {
        var group = app.MapGroup("Schedules");
        group.MapGet("/", GetAll);
        group.MapGet("/:id", Get);
        group.MapPost("/", Create);
        return group;
    }

    private static async Task<ScheduleViewModel[]> GetAll(AppService app) => 
        (await app.GetAll()).ToArray();

    private static async Task<ScheduleViewModel?> Get(string id, AppService app) => 
        await app.Get(id);

    private static async Task<IResult> Create(ScheduleViewModel viewModel, AppService app)
    {
        await app.CreateSchedule(viewModel);
        return Results.NoContent();
    }
}

