namespace BusinessCore.ItemsQuality
{
    public class Sulfuras : StrategyBase
    {
        public Sulfuras(Item item) : base(item) { }

        public override void UpdateQuality()
        {
            // Empty on purpose since quality never changes
        }
    }
}