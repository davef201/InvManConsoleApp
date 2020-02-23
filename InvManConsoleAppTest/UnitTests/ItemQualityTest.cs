using InvManConsoleApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InvManConsoleAppTest.UnitTests
{
    [TestClass]
    public class ItemQualityTest
    {
        [TestMethod]
        public void UpdateQuality_FreshInDate_ReduceBy2()
        {
            Item item = new FreshItem();
            item.SellIn = 0;
            item.Quality = 2;
            item.UpdateQuality();
            Assert.AreEqual(0, item.Quality);

        }

        [TestMethod]
        public void UpdateQuality_FreshNotInDate_ReduceBy4()
        {
            Item item = new FreshItem();
            item.SellIn = -1;
            item.Quality = 4;
            item.UpdateQuality();
            Assert.AreEqual(0, item.Quality);

        }

        [TestMethod]
        public void UpdateQuality_FrozenInDate_ReduceBy1()
        {
            Item item = new FrozenItem();
            item.SellIn = 0;
            item.Quality = 1;
            item.UpdateQuality();
            Assert.AreEqual(0, item.Quality);

        }

        [TestMethod]
        public void UpdateQuality_FrozenNotInDate_ReduceBy2()
        {
            Item item = new FrozenItem();
            item.SellIn = -1;
            item.Quality = 2;
            item.UpdateQuality();
            Assert.AreEqual(0, item.Quality);

        }

        [TestMethod]
        public void UpdateQuality_ChristmasCrackers_IncreaseBy1()
        {
            Item item = new ChristmasCrackers();
            item.SellIn = 11;
            item.Quality = 0;
            item.UpdateQuality();
            Assert.AreEqual(1, item.Quality);
        }

        [TestMethod]
        public void UpdateQuality_ChristmasCrackers_IncreaseByTwo()
        {
            Item item = new ChristmasCrackers();
            item.SellIn = 10;
            item.Quality = 0;
            item.UpdateQuality();
            Assert.AreEqual(2, item.Quality);

        }

        [TestMethod]
        public void UpdateQuality_ChristmasCrackers_IncreaseByThree()
        {
            Item item = new ChristmasCrackers();
            item.SellIn = 5;
            item.Quality = 0;
            item.UpdateQuality();
            Assert.AreEqual(3, item.Quality);

        }

        [TestMethod]
        public void UpdateQuality_ChristmasCrackers_ReduceTo0()
        {
            Item item = new ChristmasCrackers();
            item.SellIn = -1;
            item.Quality = 1;
            item.UpdateQuality();
            Assert.AreEqual(0, item.Quality);

        }


        [TestMethod]
        public void UpdateQuality_AgedBrie()
        {
            Item item = new AgedBrie();
            item.SellIn = 0;
            item.Quality = 1;
            item.UpdateQuality();
            Assert.AreEqual(2, item.Quality);
        }

        [TestMethod]
        public void UpdateQuality_Soap()
        {
            Item item = new Soap();
            item.Quality = 1;
            item.UpdateQuality();
            Assert.AreEqual(1, item.Quality);
        }

        [TestMethod]
        public void UpdateQuality_Negative_ReturnsZero()
        {
            Item item = new FreshItem();
            item.Quality = 0;
            item.UpdateQuality();
            Assert.AreEqual(0, item.Quality);
        }

        [TestMethod]
        public void UpdateQuality_GreaterThan50_ReturnsFifty()
        {
            Item item = new AgedBrie();
            item.Quality = 50;
            item.UpdateQuality();
            Assert.AreEqual(50, item.Quality);
        }

        [TestMethod]
        public void UpdateQuality_Soap_ReturnsSame()
        {
            Item item = new Soap();
            item.Quality = 1;
            item.UpdateQuality();
            Assert.AreEqual(1, item.Quality);
        }
    }
}
