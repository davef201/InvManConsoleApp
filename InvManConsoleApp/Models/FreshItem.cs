using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvManConsoleApp.Models
{
    public class FreshItem : Item
    {
        public override void UpdateQuality()
        {
            if (SellIn >= 0)
            {
                Quality = Quality - 2;
            } else
            {
                Quality = Quality - 4;
            }
            SetQualityBoundaries();
        }

    }
}
