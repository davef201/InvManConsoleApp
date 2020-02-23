using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvManConsoleApp.Models
{
    public class ChristmasCrackers : Item
    {
        public override void UpdateQuality()
        {
            if (SellIn <= 10)
            {
                if (SellIn <= 5)
                {
                    if (SellIn < 0)
                    {
                        Quality = 0;
                    } else
                    {
                        Quality = Quality + 3;
                    }

                } else
                {
                    Quality = Quality + 2;
                }

            } else
            {
                Quality = Quality + 1;
            }
        }

    }
}
