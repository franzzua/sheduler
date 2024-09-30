using Google.Cloud.Tasks.V2;
using Google.Protobuf.WellKnownTypes;
using Sheduler.Contracts.Contracts;
using Task = System.Threading.Tasks.Task;
using CloudTask = Google.Cloud.Tasks.V2.Task;
using HttpMethod = Google.Cloud.Tasks.V2.HttpMethod;

namespace Sheduler.Timers.GoogleQueue;

public class GoogleTaskExecutor(
    QueueName queueName,
    string handler
    ) : IDelayedExecutor
{
    private readonly CloudTasksClient _client = CloudTasksClient.Create();


    public async Task<string> Invoke(TimeSpan delay, string timetableId)
    {
        try
        {
            var task = await _client.CreateTaskAsync(new CreateTaskRequest
            {
                Task = new CloudTask
                {
                    ScheduleTime = Timestamp.FromDateTime(DateTime.UtcNow + delay),
                    HttpRequest = new HttpRequest
                    {
                        Url = handler + $"?id={timetableId}",
                        HttpMethod = HttpMethod.Get,
                    }
                },
                ParentAsQueueName = queueName
            });
            return task.Name;
        }
        catch(Exception ex)
        {
            throw new Exception($"Failed to create task, {queueName}", ex);
        }
    }

    public async Task Cancel(string token)
    {
        try
        {
            await _client.DeleteTaskAsync(token);
        }
        catch
        {
            
        }
    }
}

