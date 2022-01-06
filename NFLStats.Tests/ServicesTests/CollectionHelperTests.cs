using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFLStats.Services.Helpers;
using NFLStats.Tests.PersistenceTests;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NFLStats.Tests.ServicesTests
{
    [TestClass]
    public class CollectionHelperTests
    {
        [TestMethod]
        public void SortRecords_ReturnsSortedListDescending_ByDefault_ArgumentsValid() 
        {
            var records = FileDataStoreTests.GetCollectionRushingRecords();

            var sorted = records.SortRecords("Yards");

            Assert.AreEqual(11, sorted.Count());
            Assert.IsTrue(sorted.First().PlayerName.Equals("Mark Ingram"));
            Assert.IsTrue(sorted.Last().PlayerName.Equals("Reggie Bush"));
        }

        [TestMethod]
        public void SortRecords_ReturnsSortedListAscending_ArgumentsValid()
        {
            var records = FileDataStoreTests.GetCollectionRushingRecords();

            var sorted = records.SortRecords("Yards", true);

            Assert.AreEqual(11, sorted.Count());
            Assert.IsTrue(sorted.Last().PlayerName.Equals("Mark Ingram"));
            Assert.IsTrue(sorted.First().PlayerName.Equals("Reggie Bush"));
        }

        [TestMethod]
        public void SortRecords_ReturnsEmptyList_EmptyListAsArgument()
        {
            var records = new List<RushingRecords>();

            var sorted = records.SortRecords("Yards");

            Assert.AreEqual(0, sorted.Count());
            Assert.IsFalse(sorted.Any());
        }

        [TestMethod]
        public void PageRecords_ReturnsEmptyList_EmptyListAsArgument()
        {
            var records = new List<RushingRecords>();

            var page = records.PageRecords(10, 1);

            Assert.AreEqual(0, page.Count());
            Assert.IsFalse(page.Any());
        }

        [TestMethod]
        public void PageRecords_ReturnsTenRecords_PageOneRequested()
        {
            var records = FileDataStoreTests.GetCollectionRushingRecords();

            var page = records.PageRecords(10, 1);

            Assert.AreEqual(10, page.Count());

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PageRecords_ThrowsArgumentOutOfRangeException_NegativePageNumber()
        {
            var records = FileDataStoreTests.GetCollectionRushingRecords();

            records.PageRecords(10, -1);

        }
    }

    internal class RushingRecords
    {
    }
}
