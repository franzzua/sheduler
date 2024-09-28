namespace Sheduler.Contracts.Models;

public record ScheduledTask(string Id, string CronExpression, string Url, DateTime LastInvocation);