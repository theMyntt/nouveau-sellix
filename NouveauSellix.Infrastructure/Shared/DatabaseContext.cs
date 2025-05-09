using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NouveauSellix.Infrastructure.Users.Tables;
using NouveauSellix.Infrastructure.Users.Tables.Configurations;

namespace NouveauSellix.Infrastructure.Shared
{
    public class DatabaseContext : DbContext
    {
        public DbSet<UserTable> Users { get; set; }

        public DatabaseContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserTableConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
