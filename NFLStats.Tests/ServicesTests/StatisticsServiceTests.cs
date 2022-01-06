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
        var pageNumber = 1;
        var sortBy = "Yards";
        var playerFilter = "";
        var sut = CreateBasicSUT(sortBy, playerFilter, pageNumber);


        var records = sut.GetPagedRushingRecords(pageNumber, sortBy, playerFilter);

        Assert.AreEqual(10, records.Count());
        Assert.IsTrue(records.First().PlayerName.Equals("Mark Ingram"));
        Assert.IsTrue(records.Last().PlayerName.Equals("Brett Hundley"));
        Assert.IsFalse(records.Any(r => r.PlayerName == "Reggie Bush"));
    }

    [TestMethod]
    public void GetPagedRushingRecords_ReturnsRemainder_OnFinalPage()
    {
        
        var pageNumber = 2;
        var sortBy = "Yards";
        var playerFilter = "";
        var sut = CreateBasicSUT(sortBy, playerFilter, pageNumber);

        var records = sut.GetPagedRushingRecords(pageNumber, sortBy, playerFilter);

        Assert.AreEqual(1, records.Count());
        Assert.IsTrue(records.First().PlayerName.Equals("Reggie Bush"));
        Assert.IsTrue(records.Last().PlayerName.Equals("Reggie Bush"));
    }

    [TestMethod]
    public void GetPagedRushingRecords_ReturnsEmptySet_WhenPageExceedsRange()
    {
        var pageNumber = 3;
        var sortBy = "Yards";
        var playerFilter = "";
        var sut = CreateBasicSUT(sortBy, playerFilter, pageNumber);


        var records = sut.GetPagedRushingRecords(pageNumber, sortBy, playerFilter);

        Assert.AreEqual(0, records.Count());
        Assert.IsFalse(records.Any());
    }

    [TestMethod]
    public void GetRushingRecords_ReturnsRecordsSortedByYards_WhenArgumentsValid()
    {

        var sortBy = "Yards";
        var playerFilter = "";
        var pageNumber = 1;
        var sut = CreateBasicSUT(sortBy, playerFilter, pageNumber);


        var records = sut.GetRushingRecords(sortBy, playerFilter);

        Assert.AreEqual(11, records.Count());
        Assert.IsTrue(records.First().PlayerName.Equals("Mark Ingram"));
        Assert.IsTrue(records.Last().PlayerName.Equals("Reggie Bush"));
    }

    private StatisticsService CreateBasicSUT(string sortyBy, string playerFilter, int PageNumber) 
    {
        var dataStore = new Mock<IDataStore>();
        dataStore.Setup(d => d.GetRushingRecords(sortyBy, playerFilter, false)).Returns(GetCollectionRushingRecords);
        dataStore.Setup(d => d.GetPagedRushingRecords(PageNumber, 10, sortyBy, playerFilter, false)).Returns(GetCollectionRushingRecords);

        var inMemorySettings = new Dictionary<string, string> {{ "ViewSettings:PageSize", "10"}};

        IConfiguration configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings)
            .Build();

        return new StatisticsService(configuration, dataStore.Object);
    }

    internal static IEnumerable<RushingRecord> GetCollectionRushingRecords()
    {

        return new List<RushingRecord>() {
            new RushingRecord() {
                PlayerName="Joe Banyard",
                TeamName="JAX",
                Position="RB",
                Attempts=2,
                AttemptsPerGame=2f,
                Yds="7",
                AverageYards=3.5f,
                YardsPerGame=7f,
                TouchDowns=0,
                Lng="7",
                FirstDowns=0,
                PercentageFirstDowns=0f,
                Runs20Plus=0,
                Runs40Plus=0,
                Fumbles=0
            },
            new RushingRecord() {
                PlayerName="Shaun Hill",
                TeamName="MIN",
                Position="QB",
                Attempts=5,
                AttemptsPerGame=1.7f,
                Yds="5",
                AverageYards=1f,
                YardsPerGame=1.7f,
                TouchDowns=0,
                Lng="9",
                FirstDowns=0,
                PercentageFirstDowns=0f,
                Runs20Plus=0,
                Runs40Plus=0,
                Fumbles=0
            },
            new RushingRecord() {
                PlayerName="Breshad Perriman",
                TeamName="BAL",
                Position="WR",
                Attempts=1,
                AttemptsPerGame=0.1f,
                Yds="2",
                AverageYards=2f,
                YardsPerGame=0.1f,
                TouchDowns=0,
                Lng="2",
                FirstDowns=0,
                PercentageFirstDowns=0f,
                Runs20Plus=0,
                Runs40Plus=0,
                Fumbles=0
            },
            new RushingRecord() {
                PlayerName="Charlie Whitehurst",
                TeamName="CLE",
                Position="QB",
                Attempts=2,
                AttemptsPerGame=2f,
                Yds="1",
                AverageYards=0.5f,
                YardsPerGame=1f,
                TouchDowns=0,
                Lng="2",
                FirstDowns=0,
                PercentageFirstDowns=0f,
                Runs20Plus=0,
                Runs40Plus=0,
                Fumbles=0
            },
            new RushingRecord() {
                PlayerName="Lance Dunbar",
                TeamName="DAL",
                Position="RB",
                Attempts=9,
                AttemptsPerGame=0.7f,
                Yds="31",
                AverageYards=3.4f,
                YardsPerGame=2.4f,
                TouchDowns=1,
                Lng="10",
                FirstDowns=3,
                PercentageFirstDowns=33.3f,
                Runs20Plus=0,
                Runs40Plus=0,
                Fumbles=0
            },
            new RushingRecord() {
                PlayerName="Mark Ingram",
                TeamName="NO",
                Position="RB",
                Attempts=205,
                AttemptsPerGame=12.8f,
                Yds="1,043",
                AverageYards=5.1f,
                YardsPerGame=65.2f,
                TouchDowns=6,
                Lng="75T",
                FirstDowns=49,
                PercentageFirstDowns=23.9f,
                Runs20Plus=4,
                Runs40Plus=2,
                Fumbles=2
            },
            new RushingRecord() {
                PlayerName="Reggie Bush",
                TeamName="BUF",
                Position="RB",
                Attempts=12,
                AttemptsPerGame=0.9f,
                Yds="-3",
                AverageYards=-0.3f,
                YardsPerGame=-0.2f,
                TouchDowns=1,
                Lng="5",
                FirstDowns=2,
                PercentageFirstDowns=16.7f,
                Runs20Plus=0,
                Runs40Plus=0,
                Fumbles=1
            },
            new RushingRecord() {
                PlayerName="Lucky Whitehead",
                TeamName="DAL",
                Position="WR",
                Attempts=10,
                AttemptsPerGame=0.7f,
                Yds="82",
                AverageYards=8.2f,
                YardsPerGame=5.5f,
                TouchDowns=0,
                Lng="26",
                FirstDowns=4,
                PercentageFirstDowns=40f,
                Runs20Plus=1,
                Runs40Plus=0,
                Fumbles=1
            },
            new RushingRecord() {
                PlayerName="Brett Hundley",
                TeamName="GB",
                Position="QB",
                Attempts=3,
                AttemptsPerGame=0.8f,
                Yds="-2",
                AverageYards=-0.7f,
                YardsPerGame=-0.5f,
                TouchDowns=0,
                Lng="0",
                FirstDowns=0,
                PercentageFirstDowns=0f,
                Runs20Plus=0,
                Runs40Plus=0,
                Fumbles=1
            },
            new RushingRecord() {
                PlayerName="Tyreek Hill",
                TeamName="KC",
                Position="WR",
                Attempts=24,
                AttemptsPerGame=1.5f,
                Yds="267",
                AverageYards=11.1f,
                YardsPerGame=16.7f,
                TouchDowns=3,
                Lng="70T",
                FirstDowns=10,
                PercentageFirstDowns=41.7f,
                Runs20Plus=4,
                Runs40Plus=2,
                Fumbles=0
            },
            new RushingRecord() {
                PlayerName="Randall Cobb",
                TeamName="GB",
                Position="WR",
                Attempts=10,
                AttemptsPerGame=0.8f,
                Yds="33",
                AverageYards=3.3f,
                YardsPerGame=2.5f,
                TouchDowns=0,
                Lng="14",
                FirstDowns=4,
                PercentageFirstDowns=40f,
                Runs20Plus=0,
                Runs40Plus=0,
                Fumbles=0
            }
        };

    }
}
