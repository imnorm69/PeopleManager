using Microsoft.EntityFrameworkCore;

namespace PeopleManager.Data;

/// <summary>
/// Factory for creating <see cref="AppDbContext"/> instances and managing database initialisation.
/// Use <see cref="Create"/> to obtain a fresh context per operation; dispose with <c>await using</c>.
/// The database is stored as a single SQLite file in %LOCALAPPDATA%\PeopleManager\.
/// </summary>
public static class DbFactory
{
    private static readonly string DbPath = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
        "PeopleManager",
        "people.db");

    /// <summary>Creates and returns a new <see cref="AppDbContext"/> instance.</summary>
    /// <remarks>Each call returns an independent context. Callers must dispose it (<c>await using</c>).</remarks>
    public static AppDbContext Create()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite($"Data Source={DbPath}")
            .Options;
        return new AppDbContext(options);
    }

    /// <summary>
    /// Ensures the database file and directory exist and all migrations are applied.
    /// Called once at application startup before the main window is shown.
    /// To add a schema change: dotnet ef migrations add &lt;MigrationName&gt;
    /// </summary>
    public static async Task InitializeDatabaseAsync()
    {
        Directory.CreateDirectory(Path.GetDirectoryName(DbPath)!);

        await using var ctx = Create();
        await ctx.Database.MigrateAsync();
    }
}
