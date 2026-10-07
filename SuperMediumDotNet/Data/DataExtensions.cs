using Microsoft.EntityFrameworkCore;
using SuperMediumDotNet.Models;

namespace SuperMediumDotNet.Data;

public static class DataExtensions
{
    public static void MigrateDb(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<SuperMediumContext>();
        dbContext.Database.Migrate();
    }

    public static void InitializeDb(this WebApplicationBuilder builder)
    {
        var connString = builder.Configuration.GetConnectionString("SuperMedium");
        builder.Services.AddSqlite<SuperMediumContext>(connString,
            optionsAction: options => options.UseSeeding((context, _) =>
            {
                if (context.Set<Tag>().Any()) return;

                context.Set<Tag>().AddRange(
                    new Tag { Name = "Foo" },
                    new Tag { Name = "Bar" },
                    new Tag { Name = "Baz" }
                );

                context.SaveChanges();
            })
        );
    }
}