using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvManConsoleApp.Models
{
    public class FrozenItem : Item
    {
        public override void UpdateQuality()
        {
            if (SellIn >= 0)
            {
                Quality = Quality - 1;
            }
            else
            {
                Quality = Quality - 2;
            }
            SetQualityBoundaries();
        }

    }
}
