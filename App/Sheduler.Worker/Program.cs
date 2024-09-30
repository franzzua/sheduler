using Sheduler.App;
using Sheduler.Worker;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Configuration.AddJsonFile("/home/appsettings", true, true);
builder.Services.AddApp(builder.Configuration);

var app = builder.Build();

app.Map("/", Worker.HandleAsync);

app.Run();


