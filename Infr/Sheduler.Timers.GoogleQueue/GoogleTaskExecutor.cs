using Google.Cloud.Tasks.V2;
using Google.Protobuf.WellKnownTypes;
using Sheduler.Contracts.Contracts;
using Task = System.Threading.Tasks.Task;
using CloudTask = Google.Cloud.Tasks.V2.Task;
using HttpMethod = Google.Cloud.Tasks.V2.HttpMethod;

namespace Sheduler.Timers.GoogleQueue;

public class GoogleTaskExecutor(
    string queueName,
    string handler
    ) : IDelayedExecutor
{
    private readonly CloudTasksClient _client = CloudTasksClient.Create();

    private async Task<QueueName> GetQueueName()
    {
        return (await AsyncEnumerable.Create(_ => _client.ListQueuesAsync(new ListQueuesRequest
        {
            Filter = queueName
        }).GetAsyncEnumerator(_)).FirstAsync()).QueueName;
    }

    public async Task<string> Invoke(TimeSpan delay, string timetableId)
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
            ParentAsQueueName = await GetQueueName(),
        });
        return task.Name;
    }

    public async Task Cancel(string token)
    {
        await _client.DeleteTaskAsync(token);
    }
}