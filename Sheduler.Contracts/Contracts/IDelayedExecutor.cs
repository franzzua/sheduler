namespace Sheduler.Contracts.Contracts;

public interface IDelayedExecutor
{
    public Task<string> Invoke(TimeSpan delay, string timetableId);
    
    public Task Cancel(string token);
}