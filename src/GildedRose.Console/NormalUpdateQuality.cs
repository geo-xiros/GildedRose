namespace GildedRose.Console
{
    /// <summary>
    /// quality decreases by one each day 
    /// and by two after sell date passes
    /// </summary>
    public class NormalUpdateQuality : ItemUpdate
    {
        public NormalUpdateQuality(Item item) : base(item) { }

        protected override void UpdateQuality()
        {
            Item.Quality -= (Item.SellIn < 0) ? 2 : 1;
        }
    }

}
