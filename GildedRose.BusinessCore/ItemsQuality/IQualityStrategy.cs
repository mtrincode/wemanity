namespace BusinessCore.ItemsQuality
{
    public interface IQualityStrategy
    {
        Item Item { get; set; }
        void UpdateQuality();
    }
}