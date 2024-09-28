namespace Sheduler.Contracts.Models;

public abstract record Trigger()
{
    public abstract TriggerType Type { get; }
}