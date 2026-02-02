using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TecOS.Infrastructure.Data.Context;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

        optionsBuilder.UseNpgsql("Host=tecos-db-prod.ci1maokya2t3.us-east-1.rds.amazonaws.com;Database=tecosdb;Username=postgres;Password=GokuDBZSSJ7");
        
        return new ApplicationDbContext(optionsBuilder.Options);
    }
}