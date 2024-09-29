using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Sheduler.Storage.Db;

public class ScheduleContext(DbContextOptions<ScheduleContext> options) : DbContext(options)
{
    public DbSet<ScheduleEntity> Schedules { get; set; }
    public DbSet<TaskEntity> Tasks { get; set; }
    public DbSet<InvokeEntity> Invokes { get; set; }
}