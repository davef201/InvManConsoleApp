using InvManConsoleApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvManConsoleAppTest.UnitTests
{
    [TestClass]
    public class ItemSellInTest
    {
        [TestMethod]
        public void UpdateSellIn_Fresh_ReduceBy1()
        {
            Item item = new FreshItem();
            item.SellIn = 1;
            item.UpdateSellIn();
            Assert.AreEqual(0, item.SellIn);

        }

        [TestMethod]
        public void UpdateSellIn_Soap_SameValue()
        {
            Item item = new Soap();
            item.SellIn = 1;
            item.UpdateSellIn();
            Assert.AreEqual(1, item.SellIn);

        }

        [TestMethod]
        public void UpdateSellIn_InvalidItem_Null()
        {
            Item item = new InvalidItem();
            item.SellIn = 1;
            item.UpdateSellIn();
            Assert.IsNull(item.SellIn);

        }
    }
}
