using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PeopleManager.Data;

/// <summary>
/// Design-time factory so `dotnet ef migrations add` can instantiate AppDbContext
/// without launching the WinForms application.
/// </summary>
public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite("Data Source=people_designtime.db")
            .Options;
        return new AppDbContext(options);
    }
}
