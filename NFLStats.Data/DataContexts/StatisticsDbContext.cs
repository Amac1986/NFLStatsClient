using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NFLStats.Model.Models;

namespace NFLStats.Data
{
    public class StatisticsDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source =.; User ID = sa; Password = ********; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
            
        }

        public DbSet<RushingRecord> RushingRecords { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<Team> Teams { get; set; }


    }
}
