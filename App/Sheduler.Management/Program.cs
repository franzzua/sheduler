using Sheduler.App;
using Sheduler.Domain;
using Sheduler.Management;
using Sheduler.Storage;
using Sheduler.Timers.GoogleQueue;

var builder = WebApplication.CreateBuilder(args);

// builder.Configuration.AddJsonFile("appsettings.json", true, true);
builder.Services.AddDomain();
builder.Services.AddGoogleQueueTimers(builder.Configuration);
builder.Services.AddStorage(builder.Configuration);
builder.Services.AddScoped<AppService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.Services.SaveSwaggerJson();
}
// var group = app.MapGroup("/schedules");
//
// group.MapGet("/", GetAll);
// group.MapGet("/:id", (string id, AppService app) => app.Get(id));
//
// group.MapPost("/", (ScheduleViewModel viewModel, AppService app) => app.CreateSchedule(viewModel));


app.Run();


