using Microsoft.EntityFrameworkCore;

namespace EfMultiTable.Infrastructure;
public class MultiTableContext : DbContext
{
    private readonly string connectionString;
    private readonly Action<string> writeLine;

    public DbSet<LiveEntity> Live { get; set; }
    public DbSet<HistoryEntity> History { get; set; }

    public MultiTableContext(string connectionString/*, Action<string> writeLine*/)
    {
        this.connectionString = connectionString;
        this.writeLine = writeLine;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString)
            .EnableSensitiveDataLogging();
    }
}
