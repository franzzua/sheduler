using Sheduler.Contracts.Contracts;

namespace Sheduler.Domain.Services;

internal class ExecutorService : IExecutor
{
    private readonly HttpClient _httpClient = new();
    public async Task Invoke(string url, IReadOnlyList<DateTime> dateTimes)
    {
        var message = new HttpRequestMessage(HttpMethod.Get, url);
        foreach (var dateTime in dateTimes)
        {
            message.Headers.TryAddWithoutValidation("datetime", dateTime.ToFileTimeUtc().ToString());
            message.Headers.TryAddWithoutValidation("ngrok-skip-browser-warning", "*");
        }
        await _httpClient.SendAsync(message);
    }
}