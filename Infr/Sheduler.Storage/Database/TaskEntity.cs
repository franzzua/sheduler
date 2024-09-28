using System.ComponentModel.DataAnnotations.Schema;

namespace Sheduler.Storage.Database;

[Table("Tasks")]
public class TaskEntity 
{
    public string Id { get; set; }
    public string ScheduleId { get; set; }

    public string CronExpression { get; set; }
    
    public string Url { get; set; }
    
    public DateTime LastInvocation { get; set; }
    
    public virtual ScheduleEntity Schedule { get; set; }
}