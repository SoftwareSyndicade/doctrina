using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace doctrine_api.Services.SQLServer
{
    public class DoctrinaStoreFactory : IDesignTimeDbContextFactory<DoctrinaStore>
    {
        public DoctrinaStore CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            DbContextOptionsBuilder<DoctrinaStore> builder = new();

            var connectionString = configuration.GetConnectionString("DoctrinaStoreConnectionString");

            builder.UseSqlServer(connectionString);

            return new DoctrinaStore(builder.Options);
        }
    }
}

