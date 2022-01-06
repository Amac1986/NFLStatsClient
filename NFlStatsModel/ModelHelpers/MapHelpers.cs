using NFLStats.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLStats.Model.ModelHelpers
{
    public static class MapHelpers
    {
        public static Rush ToRush(this RushingRecord record) 
        {
            return new Rush() {
                Player = new Player() { Name = record.PlayerName, Team = new Team() { Name = record.TeamName}, Position = new Position() { PostionCode = record.Position } },
                Yds = record.Yds,
                Attempts = record.Attempts,
                AttemptsPerGame = record.AttemptsPerGame,
                AverageYards = record.AverageYards,
                YardsPerGame = record.YardsPerGame,
                TouchDowns = record.TouchDowns,
                Lng = record.Lng,
                FirstDowns = record.FirstDowns,
                PercentageFirstDowns = record.PercentageFirstDowns,
                Runs20Plus = record.Runs20Plus,
                Runs40Plus = record.Runs40Plus,
                Fumbles = record.Fumbles
            };
        }

        public static RushingRecord ToRushingRecord(this Rush record)
        {
            return new RushingRecord()
            {
                PlayerName = record.Player.Name,
                Position = record.Player.Position.PostionCode,
                TeamName= record.Player.Team.Name,
                Yds = record.Yds,
                Attempts = record.Attempts,
                AttemptsPerGame = record.AttemptsPerGame,
                AverageYards = record.AverageYards,
                YardsPerGame = record.YardsPerGame,
                TouchDowns = record.TouchDowns,
                Lng = record.Lng,
                FirstDowns = record.FirstDowns,
                PercentageFirstDowns = record.PercentageFirstDowns,
                Runs20Plus = record.Runs20Plus,
                Runs40Plus = record.Runs40Plus,
                Fumbles = record.Fumbles
            };
        }
    }
}
