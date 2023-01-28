using System;
using doctrine_api.DataModels;
using Microsoft.EntityFrameworkCore;

namespace doctrine_api.Services.SQLServer
{
    public class DoctrinaStore : DbContext
    {
        public DoctrinaStore(DbContextOptions<DoctrinaStore> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { }

        public DbSet<Account> ACCOUNT { get; set; }
        public DbSet<Request> ASSISTANCE_REQUEST { get; set; }
    }
}

