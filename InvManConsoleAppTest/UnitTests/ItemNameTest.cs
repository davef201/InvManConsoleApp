using InvManConsoleApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvManConsoleAppTest.UnitTests
{
    [TestClass]
    public class ItemNameTest
    {
        [TestMethod]
        public void UpdateName_Fresh_SameValue()
        {
            Item item = new FreshItem { Name = "a" };
            item.UpdateName();
            Assert.AreEqual("a", item.Name);
        }

        [TestMethod]
        public void UpdateName_InvalidItem_NoSuchItem()
        {
            Item item = new InvalidItem { Name = "a" };
            item.UpdateName();
            Assert.AreEqual("NO SUCH ITEM", item.Name);
        }
    }
}
