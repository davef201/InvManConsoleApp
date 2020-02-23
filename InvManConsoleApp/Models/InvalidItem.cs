using System;
using System.Collections.Generic;
using System.Text;

namespace InvManConsoleApp.Models
{
    public class InvalidItem : Item
    {
        public override void UpdateName()
        {
            Name = "NO SUCH ITEM";
        }

        public override void UpdateSellIn()
        {
            SellIn = null;
        }

        public override void UpdateQuality()
        {
            Quality = null;
        }
    }
}
