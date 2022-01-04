using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using NFLStats.Model.Models;
using NFLStats.Services.Interfaces;
using NFLStats.Services.Services;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NFLStats.Tests.ServicesTests;

[TestClass]
public class StatisticsServiceTests
{
    [TestMethod]
    public void GetPagedRushingRecords_ReturnsRecordsSortedByYards_WhenArgumentsValid() 
    {
        var sut = CreateBasicSUT();
        var pageNumber = 1;
        var sortBy = "Yards";
        var playerFilter = "";


        var records = sut.GetPagedRushingRecords(pageNumber, sortBy, playerFilter);

        Assert.IsTrue(records.Any());
        Assert.AreEqual(10, records.Count());
        Assert.IsTrue(records.First().PlayerName.Equals("Mark Ingram"));

    }

    private StatisticsService CreateBasicSUT() 
    {
        IDataStore dataStore = Mock.Of<IDataStore>(d => d.GetRushingRecords() == GetCollectionRushingRecords());
        var inMemorySettings = new Dictionary<string, string> {{ "ViewSettings:PageSize", "10"}};

        IConfiguration configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings)
            .Build();

        return new StatisticsService(configuration, dataStore);
    }

    private IEnumerable<RushingRecord> GetCollectionRushingRecords()
    {

        return new List<RushingRecord>() {
            new RushingRecord() {
            PlayerName="Joe Banyard",
            Team="JAX",
            Position="RB",
            Attempts=2,
            AttemptsPerGame=2,
            Yds=7,
            AverageYards=3.5,
            YardsPerGame=7,
            TouchDowns=0,
            Lng="7",
            FirstDowns=0,
            PercentageFirstDowns=0,
            Runs20Plus+=0,
            Runs40Plus+=0,
            Fumbles=0
            },
            new RushingRecord() {
            PlayerName="Shaun Hill",
            TeamName="MIN",
            Position="QB",
            Attempts=5,
            AttemptsPerGame=1.7,
            Yds=5,
            AverageYards=1,
            YardsPerGame=1.7,
            TouchDowns=0,
            Lng="9",
            FirstDowns=0,
            PercentageFirstDowns=0,
            Runs20Plus+=0,
            Runs40Plus+=0,
            Fumbles=0
            },
            new RushingRecord() {
            PlayerName="Breshad Perriman",
            Team="BAL",
            Position="WR",
            Attempts=1,
            AttemptsPerGame=0.1,
            Yds=2,
            AverageYards=2,
            YardsPerGame=0.1,
            TouchDowns=0,
            Lng="2",
            FirstDowns=0,
            PercentageFirstDowns=0,
            Runs20Plus+=0,
            Runs40Plus+=0,
            Fumbles=0
            },
            new RushingRecord() {
            PlayerName="Charlie Whitehurst",
            Team="CLE",
            Position="QB",
            Attempts=2,
            AttemptsPerGame=2,
            Yds=1,
            AverageYards=0.5,
            YardsPerGame=1,
            TouchDowns=0,
            Lng="2",
            FirstDowns=0,
            PercentageFirstDowns=0,
            Runs20Plus+=0,
            Runs40Plus+=0,
            Fumbles=0
            },
            new RushingRecord() {
            PlayerName="Lance Dunbar",
            Team="DAL",
            Position="RB",
            Attempts=9,
            AttemptsPerGame=0.7,
            Yds=31,
            AverageYards=3.4,
            YardsPerGame=2.4,
            TouchDowns=1,
            Lng="10",
            FirstDowns=3,
            PercentageFirstDowns=33.3,
            Runs20Plus+=0,
            Runs40Plus+=0,
            Fumbles=0
            },
            new RushingRecord() {
            PlayerName="Mark Ingram",
            Team="NO",
            Position="RB",
            Attempts=Runs20Plus5,
            AttemptsPerGame=12.8,
            Yds="1,043",
            AverageYards=5.1,
            YardsPerGame=65.2,
            TouchDowns=6,
            Lng="75T",
            FirstDowns=49,
            PercentageFirstDowns=23.9,
            Runs20Plus+=4,
            Runs40Plus+=2,
            Fumbles=2
            },
            new RushingRecord() {
            PlayerName="Reggie Bush",
            Team="BUF",
            Position="RB",
            Attempts=12,
            AttemptsPerGame=0.9,
            Yds=-3,
            AverageYards=-0.3,
            YardsPerGame=-0.2,
            TouchDowns=1,
            Lng=5,
            FirstDowns=2,
            PercentageFirstDowns=16.7,
            Runs20Plus+=0,
            Runs40Plus+=0,
            Fumbles=1
            },
            new RushingRecord() {
            PlayerName="Lucky Whitehead",
            Team="DAL",
            Position="WR",
            Attempts=10,
            AttemptsPerGame=0.7,
            Yds=82,
            AverageYards=8.2,
            YardsPerGame=5.5,
            TouchDowns=0,
            Lng="26",
            FirstDowns=4,
            PercentageFirstDowns=Runs40Plus,
            Runs20Plus+=1,
            Runs40Plus+=0,
            Fumbles=1
            },
            new RushingRecord() {
            PlayerName="Brett Hundley",
            Team="GB",
            Position="QB",
            Attempts=3,
            AttemptsPerGame=0.8,
            Yds=-2,
            AverageYards=-0.7,
            YardsPerGame=-0.5,
            TouchDowns=0,
            Lng=0,
            FirstDowns=0,
            PercentageFirstDowns=0,
            Runs20Plus+=0,
            Runs40Plus+=0,
            Fumbles=1
            },
            new RushingRecord() {
            PlayerName="Tyreek Hill",
            Team="KC",
            Position="WR",
            Attempts=24,
            AttemptsPerGame=1.5,
            Yds=267,
            AverageYards=11.1,
            YardsPerGame=16.7,
            TouchDowns=3,
            Lng="70T",
            FirstDowns=10,
            PercentageFirstDowns=41.7,
            Runs20Plus+=4,
            Runs40Plus+=2,
            Fumbles=0
            },
            new RushingRecord() {
            PlayerName="Randall Cobb",
            Team="GB",
            Position="WR",
            Attempts=10,
            AttemptsPerGame=0.8,
            Yds=33,
            AverageYards=3.3,
            YardsPerGame=2.5,
            TouchDowns=0,
            Lng="14",
            FirstDowns=4,
            PercentageFirstDowns=Runs40Plus,
            Runs20Plus+=0,
            Runs40Plus+=0,
            Fumbles=0
            }
        };
    }
}
