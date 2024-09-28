using Sheduler.Contracts.Contracts;

namespace Sheduler.Tests.Mocks;

public class MockExecutor : IExecutor
{
    public Dictionary<string, IReadOnlyList<DateTime>> Invocations = new();
    
    public async Task Invoke(string url, IReadOnlyList<DateTime> dateTimes)
    {
        if (Invocations.ContainsKey(url))
        {
            Invocations[url] = Invocations[url].Concat(dateTimes).ToList();
        }
        else
        {
            Invocations.Add(url, dateTimes.ToList());
        }
    }
}