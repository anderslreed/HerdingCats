using HerdingCats.Data;

using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HerdingCatsTests.Db;

public class SqliteMemoryDbTestContext : TestContext
{
    private readonly SqliteConnection _connection = new("DataSource=:memory:");

    public SqliteMemoryDbTestContext() : base()
    {
        _connection.Open();
        Services.AddDbContextFactory<KittyDbContext>(builder => builder.UseSqlite(_connection));
        GetDbContext().Database.EnsureCreated();
    }

    public KittyDbContext GetDbContext() => Services.GetRequiredService<IDbContextFactory<KittyDbContext>>().CreateDbContext();
}
