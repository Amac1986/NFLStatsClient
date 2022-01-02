using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFLStats.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFLStats.Tests
{
    [TestClass]
    public class RushingRecordTests
    {
        [TestMethod]
        public void BuildHeadHtml_ReturnExpectedHtml()
        {
            var record = SingleRecord();
            var expectedHtml = ExpectedHeadHTML();

            var actual = record.GetHtmlHead();

            Assert.AreEqual(expectedHtml, actual);
        }

        [TestMethod]
        public void BuildHtml_ReturnsExpectedHtmlString()
        {
            var record = SingleRecord();
            var expectedHtml = ExpectedHtml();

            var actual = record.ToHtml("td");

            Assert.AreEqual(expectedHtml, actual);
        }

        [TestMethod]
        public void GetCSVHead_ReturnsExpectedCsvString()
        {
            var record = SingleRecord();
            var expectedCsv = ExpectedHeadCsv();

            var actual = record.GetCSVHead();

            Assert.AreEqual(expectedCsv, actual);
        }

        [TestMethod]
        public void ToCsv_ReturnsExpectedCsvString()
        {
            var record = SingleRecord();
            var expectedCsv = ExpectedCsv();

            var actual = record.ToCSV();

            Assert.AreEqual(expectedCsv, actual);
        }

        [TestMethod]
        public void ToCsv_ReturnsExpectedCsvString_WhenYardsExceed1000()
        {
            var record = SingleRecordYards1111();
            var expectedCsv = ExpectedCsv_Yards1111();

            var actual = record.ToCSV();

            Assert.AreEqual(expectedCsv, actual);
        }

        private static RushingRecord SingleRecord()
        {
            return new RushingRecord()
            {
                PlayerName = "Kenjon Barner",
                TeamName = "PHI",
                Position = "RB",
                Attempts = 27,
                AttemptsPerGame = 2.1f,
                AverageYards = 4.8f,
                YardsPerGame = 9.9f,
                Yds = "129",
                TouchDowns = 2,
                Lng = "19",
                FirstDowns = 9,
                PercentageFirstDowns = 33.3f,
                Runs20Plus = 0,
                Runs40Plus = 0,
                Fumbles = 0
            };
        }

        private static RushingRecord SingleRecordYards1111()
        {
            return new RushingRecord()
            {
                PlayerName = "Kenjon Barner",
                TeamName = "PHI",
                Position = "RB",
                Attempts = 27,
                AttemptsPerGame = 2.1f,
                AverageYards = 4.8f,
                YardsPerGame = 9.9f,
                Yds = "1,111",
                TouchDowns = 2,
                Lng = "19",
                FirstDowns = 9,
                PercentageFirstDowns = 33.3f,
                Runs20Plus = 0,
                Runs40Plus = 0,
                Fumbles = 0
            };
        }

        private static string ExpectedHeadHTML() 
        {
            return "<th data-column-name=\"PlayerName\">Player</th><th data-column-name=\"TeamName\">Team</th><th data-column-name=\"Position\">" +
                   "Pos</th><th data-column-name=\"Yards\">Yds</th><th data-column-name=\"Attempts\">Att</th><th data-column-name=\"AttemptsPerG" +
                   "ame\">Att/G</th><th data-column-name=\"AverageYards\">Avg</th><th data-column-name=\"YardsPerGame\">Yds/G</th><th data-column" +
                   "-name=\"TouchDowns\">TD</th><th data-column-name=\"LongestRun\">Lng</th><th data-column-name=\"FirstDowns\">1st</th><th data-" +
                   "column-name=\"PercentageFirstDowns\">1st%</th><th data-column-name=\"Runs20Plus\">20+</th><th data-column-name=\"Runs40Plus\">40+</th><th data-column-name=\"Fumbles\">FUM</th>";
        }

        private static string ExpectedHtml() 
        {
            return "<td>Kenjon Barner</td><td>PHI</td><td>RB</td><td>129</td><td>27</td><td>2.1</td><td>4.8</td><td>9.9</td><td>2</td><td>19</td><td>9</td><td>33.3</td><td>0</td><td>0</td><td>0</td>";
        }

        private static string ExpectedHeadCsv()
        {
            return "Player,Team,Pos,Yds,Att,Att/G,Avg,Yds/G,TD,Lng,1st,1st%,20+,40+,FUM";
        }

        private static string ExpectedCsv()
        {
            return "Kenjon Barner,PHI,RB,129,27,2.1,4.8,9.9,2,19,9,33.3,0,0,0";
        }

        private static string ExpectedCsv_Yards1111()
        {
            return "Kenjon Barner,PHI,RB,1111,27,2.1,4.8,9.9,2,19,9,33.3,0,0,0";
        }
    }
}
