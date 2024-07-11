using HerdingCats.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HerdingCatsTests.Db;

public class SqliteMemoryDbTest : TestContext
{
    private readonly SqliteConnection _connection = new("DataSource=:memory:");

    public SqliteMemoryDbTest() : base()
    {
        _connection.Open();
        Services.AddDbContext<KittyDbContext>(builder => builder.UseSqlite(_connection));
    }
}
