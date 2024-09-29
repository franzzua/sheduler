using Sheduler.App;
using Sheduler.Management;
using Sheduler.Management.Controllers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApp(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.Services.SaveSwaggerJson();
}

SchedulesController.Map(app);

app.Run();


