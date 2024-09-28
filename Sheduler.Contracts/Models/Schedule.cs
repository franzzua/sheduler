namespace Sheduler.Contracts.Models;

public record Schedule(
    string Id,
    string Name,
    string? Description,
    IReadOnlyList<ScheduledTask> Tasks
    );