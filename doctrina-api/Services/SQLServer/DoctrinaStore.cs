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
        public DbSet<Student> STUDENT { get; set; }
        public DbSet<Tutor> TUTOR { get; set; }

        public DbSet<Qualification> QUALIFICATIONS { get; set; }
        public DbSet<Degree> DEGREE { get; set; }

        public DbSet<AssistanceReuest> ASSISTANCE_REQUEST { get; set; }
        public DbSet<Attachments> ATTACHMENTS { get; set; }
        public DbSet<AssistanceProposals> ASSISTANCE_PROPOSALS { get; set; }
    }
}

