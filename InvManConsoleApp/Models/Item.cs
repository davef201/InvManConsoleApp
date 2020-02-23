using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvManConsoleApp.Models
{
    public abstract class Item
    {
        [Display(Name = "Product")]
        public string Name { get; set; }

        [Display(Name = "Days to Sell")]
        public int? SellIn { get; set; }
       
        public int? Quality { get; set; }

        public virtual void UpdateName()
        {

        }

        public virtual void UpdateSellIn() 
        {
            _ = SellIn != null ? SellIn -= 1 : SellIn;
        }

        public abstract void UpdateQuality();

        public void SetQualityBoundaries()
        {
            if (Quality < 0)
            {
                Quality = 0;
            } else if (Quality > 50)
            {
                Quality = 50;
            }
        }
    }
}
