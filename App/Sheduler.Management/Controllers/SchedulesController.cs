using Microsoft.AspNetCore.Mvc;
using Sheduler.App;

namespace Sheduler.Management.Controllers;

[ApiController]
[Route("[controller]")]
public class SchedulesController(AppService app) : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<ScheduleViewModel>> GetAll() => 
        await app.GetAll();

    [HttpGet]
    [Route("{id}")]
    public async Task<ScheduleViewModel> Get(string id) => 
        await app.Get(id);
    
    [HttpPost]
    public async Task<IActionResult> Create(ScheduleViewModel viewModel)
    {
        await app.CreateSchedule(viewModel);
        return NoContent();
    }
}