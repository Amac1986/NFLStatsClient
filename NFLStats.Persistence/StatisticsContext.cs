using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NFLStats.Model.Models;

namespace NFLStats.Persistence
{
    public class StatisticsContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public StatisticsContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public DbSet<Player> Players { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<Rush> Rushing { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("StatisticsDB");

            optionsBuilder.UseSqlite(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Position>(entity => {
                entity.HasIndex(e => e.PostionCode).IsUnique();
            });

            builder.Entity<Team>(entity => {
                entity.HasIndex(e => e.Name).IsUnique();
            });
        }
    }
}
