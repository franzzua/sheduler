using System.ComponentModel.DataAnnotations.Schema;
using Sheduler.Contracts.Models;
// ReSharper disable EntityFramework.ModelValidation.UnlimitedStringLength
// ReSharper disable PropertyCanBeMadeInitOnly.Global
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace Sheduler.Storage.Database;

[Table("Invokes")]
public sealed class InvokeEntity
{

    public string Id { get; set; }

    public string ScheduleId { get; set; }
    
    public DateTime DateTime { get; set; }

    public static explicit operator TaskInvocation?(InvokeEntity? invoke)
    {
        if (invoke == null) return null;
        return new TaskInvocation(invoke.Id, invoke.DateTime);
    }
    
    public ScheduleEntity Schedule { get; set; }
}