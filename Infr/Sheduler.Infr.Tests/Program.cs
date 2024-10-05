using Microsoft.Extensions.DependencyInjection;
using Sheduler.Contracts.Contracts;
using Sheduler.Contracts.Models;
using Sheduler.Storage;

var cs = "Host=localhost;Database=schedules;Username=postgres;Password=password;Port=5432";

var scheduleStorage = new ServiceCollection().AddStorage(cs).BuildServiceProvider().GetService<IScheduleStorage>()!;


// var all = await scheduleStorage.GetAll();
// Assert.IsNotNull(all);

var schedule = new Schedule(
    Guid.NewGuid().ToString(), "Test Schedule", "", [ 
        new ScheduledTask("Test task", "*", "Uri", DateTime.UtcNow)
    ]
);
await scheduleStorage.CreateSchedule(schedule);
Console.WriteLine("Created!");

var storedSchedule = await scheduleStorage.Get(schedule.Id);
// Assert.IsNotNull(storedSchedule);
// Assert.AreEqual(schedule.Id, storedSchedule.Id);
// Assert.AreEqual(schedule.Name, storedSchedule.Name);
// Assert.AreEqual(schedule.Description, storedSchedule.Description);
// Assert.AreEqual(schedule.Tasks.Count, storedSchedule.Tasks.Count);
var scheduledTask = schedule.Tasks.First();
var storedTask = storedSchedule.Tasks.First();
// Assert.AreEqual(scheduledTask.Url, storedTask.Url);
// Assert.AreEqual(scheduledTask.CronExpression, storedTask.CronExpression);
// Assert.AreEqual((scheduledTask.LastInvocation - storedTask.LastInvocation).TotalSeconds, 0, 1);
var invoke = new TaskInvocation("Test invoacation", DateTime.UtcNow);
await scheduleStorage.UpdateNextInvocation(schedule, invoke);
var storedInvocation = await scheduleStorage.GetNextInvocation(schedule);
var tasks = await scheduleStorage.GetReadyTasks(schedule.Id);
// Assert.IsNotNull(tasks);
// Assert.AreEqual(tasks.Count, 1);
await scheduleStorage.UpdateTaskInvocation(tasks.First());
// Assert.IsNotNull(storedInvocation);
// Assert.AreEqual(invoke.Id, storedInvocation.Id);
// Assert.AreEqual((invoke.Time - storedInvocation.Time).TotalSeconds, 0, 1);
await scheduleStorage.Delete(schedule.Id);
Console.WriteLine("Success!");