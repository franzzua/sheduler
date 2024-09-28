using Sheduler.Contracts.Models;

namespace Sheduler.Contracts.Contracts;

public interface ITaskService
{
    Task UpdateTask(Schedule schedule);
    Task Run(Schedule schedule);
}