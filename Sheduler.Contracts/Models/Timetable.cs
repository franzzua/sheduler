namespace Sheduler.Contracts.Models;

public record Timetable(string CronExpression) : Trigger()
{
    public override TriggerType Type => TriggerType.Timetable;
}