using Microsoft.EntityFrameworkCore;

namespace Sheduler.Storage.Database;

public class ScheduleContext(string connectionString) : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(connectionString);
        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<ScheduleEntity> Schedules { get; set; }
    public DbSet<TaskEntity> Tasks { get; set; }
    public DbSet<InvokeEntity> Invokes { get; set; }
}