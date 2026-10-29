using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Task_Management_Api.Data;

namespace Task_Management_Api.PostgreSqlMigrations;

public class PostgreSqlDesignTimeFactory
    : IDesignTimeDbContextFactory<PostgreSqlTaskManagementDbContext>
{
    public PostgreSqlTaskManagementDbContext CreateDbContext(
        string[] args)
    {
        var optionsBuilder =
            new DbContextOptionsBuilder<PostgreSqlTaskManagementDbContext>();


        var connectionString =
            Environment.GetEnvironmentVariable(
                "ConnectionStrings__DefaultConnection")
            ?? throw new InvalidOperationException(
                "Set the ConnectionStrings__DefaultConnection environment variable.");

        optionsBuilder.UseNpgsql(
            connectionString,
            options => options.MigrationsHistoryTable(
                "__EFMigrationsHistory",
                "public"));

        return new PostgreSqlTaskManagementDbContext(
            optionsBuilder.Options);
    }
}
