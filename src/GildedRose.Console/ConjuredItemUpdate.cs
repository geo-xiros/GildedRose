namespace GildedRose.Console
{
    /// <summary>
    /// quality decreases twice as fase as normal items
    /// </summary>
    public class ConjuredItemUpdate : ItemUpdate
    {
        public ConjuredItemUpdate(Item item) : base(item) { }

        protected override void UpdateQuality()
        {
            Item.Quality -= (Item.SellIn < 0) ? 4 : 2;
        }
    }

}
