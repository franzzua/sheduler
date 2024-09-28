namespace Sheduler.Contracts.Models;

public record User(
    string Id,
    IReadOnlyList<Schedule> Schedules,
    IReadOnlyList<Login> Logins)
{
    
}