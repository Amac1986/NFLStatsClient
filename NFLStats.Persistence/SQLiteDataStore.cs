using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NFLStats.Model.ModelHelpers;
using NFLStats.Model.Models;
using NFLStats.Services.Helpers;
using NFLStats.Services.Interfaces;

namespace NFLStats.Persistence
{
    public class SQLiteDataStore : IDataStore
    {
        private readonly StatisticsContext _context;
        private readonly IConfiguration _configuration;

        public SQLiteDataStore(StatisticsContext context, IConfiguration configuration)
        {
            _configuration = configuration;
            _context = context;
            
            if (_context.Database.EnsureCreated()){
                var path = _configuration["DataSettings:Statistics:RushingFile"];

                var records = JsonConvert.DeserializeObject<IEnumerable<RushingRecord>>(File.ReadAllText(path));

                var positions = records
                    .Select(r => r.Position)
                    .Distinct()
                    .Select(p => new Position() { PostionCode = p});

                _context.Positions.AddRange(positions);
                _context.SaveChanges();


                var Teams = records
                    .Select(r => r.TeamName)
                    .Distinct()
                    .Select(t => new Team() { Name = t });

                _context.Teams.AddRange(Teams);
                _context.SaveChanges();



                var rushes = records
                    .Select(r => r.ToRush())
                    .Select(r => 
                    {
                        r.Player.Team = _context.Teams.Where(cr => cr.Name == r.Player.Team.Name).FirstOrDefault();
                        return r; 
                    })
                    .Select(r =>
                    {
                        r.Player.Position = _context.Positions.Where(cr => cr.PostionCode == r.Player.Position.PostionCode).FirstOrDefault();
                        return r;
                    });

                _context.Rushing.AddRange(rushes);
                _context.SaveChanges();
            };
        }
        public IEnumerable<RushingRecord> GetRushingRecords(string sortBy, string playerFilter, bool ascending = false)
        {
            return _context.Rushing
                .Include(r => r.Player)
                .Include(r => r.Player.Position)
                .Include(r => r.Player.Team)
                .Where(r => r.Player.Name.ToLowerInvariant().Contains(playerFilter.ToLowerInvariant()))
                .SortRecords(sortBy, ascending)
                .Select(r => r.ToRushingRecord());
        }

        public IEnumerable<RushingRecord> GetPagedRushingRecords(int pageNumber, int pageSize, string sortBy, string playerFilter, bool ascending = false) 
        {
            return _context.Rushing
                .Include(r => r.Player)
                .Include(r => r.Player.Position)
                .Include(r => r.Player.Team)
                .Where(r => r.Player.Name.ToLowerInvariant().Contains(playerFilter.ToLowerInvariant()))
                .SortRecords(sortBy, ascending)
                .PageRecords(pageSize, pageNumber)
                .Select(r => r.ToRushingRecord());
        }
    }
}
