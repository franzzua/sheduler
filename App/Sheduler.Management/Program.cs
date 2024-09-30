using Sheduler.App;
using Sheduler.Management;
using Sheduler.Management.Controllers;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Configuration.AddJsonFile("/home/appsettings", true, true);
builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});
builder.Services.AddApp(builder.Configuration);

var test = new HttpClient();
var res = await test.GetAsync("https://google.com");
Console.WriteLine($"https://google.com say {res.StatusCode}");

#if DEBUG
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endif

var app = builder.Build();

#if DEBUG
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.Services.SaveSwaggerJson();
}
#endif

SchedulesController.Map(app);

app.Run();