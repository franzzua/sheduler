using System.Collections.Concurrent;
using Sheduler.Contracts.Contracts;
using Timer = System.Threading.Timer;

namespace Sheduler.Timers.GoogleQueue;

public class ThreadTimerExecutor(
    string handler
): IDelayedExecutor
{
    private readonly HttpClient _httpClient = new();
    private readonly ConcurrentDictionary<string, Timer> _timers = new();

    public Task<string> Invoke(TimeSpan delay, string timetableId)
    {
        var id = Guid.NewGuid().ToString();
        _timers.TryAdd(id, new Timer(OnTimerElapsed, timetableId, delay, TimeSpan.MaxValue));
        return Task.FromResult(id);
    }

    public Task Cancel(string token)
    {
        _timers.Remove(token, out _);
        return Task.CompletedTask;
    }

    private void OnTimerElapsed(object? sender)
    {
        var timetableId = (string)sender!;
        _httpClient.GetAsync(handler + $"?id={timetableId}").GetAwaiter().GetResult();
    }
}