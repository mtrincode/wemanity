namespace BusinessCore.ItemsQuality
{
    public abstract class StrategyBase : IQualityStrategy
    {
        protected const int QUALITY_MAX_VALUE = 50;
        public Item Item { get; set; }

        public StrategyBase(Item item)
        {
            Item = item;
        }

        public virtual void UpdateQuality()
        {
            Item.Quality = Item.Quality - 1;
            Item.SellIn = Item.SellIn - 1;

            if (Item.SellIn < 0)
                Item.Quality = Item.Quality - 1;

            if (Item.Quality < 0)
                Item.Quality = 0;
        }
    }
}