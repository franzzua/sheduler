using System.ComponentModel.DataAnnotations.Schema;
using Sheduler.Contracts.Models;

namespace Sheduler.Storage.Database;

[Table("Invokes")]
public class InvokeEntity
{

    public string Id { get; set; }

    public string ScheduleId { get; set; }
    
    public DateTime DateTime { get; set; }

    public static explicit operator TaskInvocation?(InvokeEntity? invoke)
    {
        if (invoke == null) return null;
        return new TaskInvocation(invoke.Id, invoke.DateTime);
    }
    
    public virtual ScheduleEntity Schedule { get; set; }
}