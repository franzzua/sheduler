using Sheduler.App;
using Sheduler.Worker;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.AddApp(builder.Configuration);

var app = builder.Build();

app.Map("/", Worker.HandleAsync);

app.Run();


