namespace BusinessCore.ItemsQuality
{
    public class BackstagePass : StrategyBase
    {        
        public BackstagePass(Item item) : base(item) { }

        public override void UpdateQuality()
        {
            Item.Quality = Item.Quality + 1;

            if (Item.SellIn < 11) 
                Item.Quality = Item.Quality + 1;

            if (Item.SellIn < 6) 
                Item.Quality = Item.Quality + 1;

            if (Item.Quality > QUALITY_MAX_VALUE) 
                Item.Quality = QUALITY_MAX_VALUE;

            Item.SellIn = Item.SellIn - 1;

            if (Item.SellIn < 0) 
                Item.Quality = 0;
        }
    }
}