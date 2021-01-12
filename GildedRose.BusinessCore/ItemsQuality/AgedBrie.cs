namespace BusinessCore.ItemsQuality
{
    public class AgedBrie : StrategyBase
    {
        public AgedBrie(Item item) : base(item) { }

        public override void UpdateQuality()
        {
            Item.Quality = Item.Quality + 1;
            Item.SellIn = Item.SellIn - 1;

            if (Item.SellIn < 0) 
                Item.Quality = Item.Quality + 1;

            if (Item.Quality > QUALITY_MAX_VALUE) 
                Item.Quality = QUALITY_MAX_VALUE;
        }
    }
}