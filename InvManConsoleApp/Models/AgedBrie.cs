using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvManConsoleApp.Models
{
    public class AgedBrie : Item
    {
        public override void UpdateQuality()
        {
            if (Quality < 50)
            {
                Quality = Quality + 1;

            }
        }

    }
}
