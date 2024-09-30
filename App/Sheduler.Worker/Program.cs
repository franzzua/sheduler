using Sheduler.App;
using Sheduler.Worker;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Configuration.AddJsonFile("/etc/appsettings", true, true);
builder.Services.AddApp(builder.Configuration);

var test = new HttpClient();
var res = await test.GetAsync("https://google.com");
Console.WriteLine($"https://google.com say {res.StatusCode}");

var app = builder.Build();

app.Map("/", Worker.HandleAsync);

app.Run();


