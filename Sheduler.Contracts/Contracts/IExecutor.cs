namespace Sheduler.Contracts.Contracts;

public interface IExecutor
{
    public Task Invoke(string url, IReadOnlyList<DateTime> dateTimes);
}