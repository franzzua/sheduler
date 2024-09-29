using System.ComponentModel.DataAnnotations.Schema;
// ReSharper disable EntityFramework.ModelValidation.UnlimitedStringLength
// ReSharper disable PropertyCanBeMadeInitOnly.Global
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace Sheduler.Storage.Database;

[Table("Tasks")]
public sealed class TaskEntity 
{
    public string Id { get; set; }
    public string ScheduleId { get; set; }

    public string CronExpression { get; set; }
    
    public string Url { get; set; }
    
    public DateTime LastInvocation { get; set; }
    
    public ScheduleEntity Schedule { get; set; }
}