using System;
using System.Linq;
using System.Collections.Generic;
using BusinessCore.ItemsQuality;

namespace BusinessCore
{
    public class GildedRose
    {
        private readonly IList<Item> Items;

        public GildedRose(IList<Item> Items)
        {
            if (Items.Any(t => t.SellIn < 0))
                throw new ArgumentOutOfRangeException("SellIn can't be less than zero.");

            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                StrategyBase strategy;

                if (item.Name.Contains("Aged Brie")) strategy = new AgedBrie(item);
                else if (item.Name.Contains("Sulfuras")) strategy = new Sulfuras(item);
                else if (item.Name.Contains("Backstage")) strategy = new BackstagePass(item);
                else strategy = new StandardItem(item);

                strategy.UpdateQuality();
            }
        }
    }
}