namespace GildedRose.Console
{
    /// <summary>
    /// quality increases every day by one
    /// by two for the last ten days before sell date
    /// by three for the last five days before sell date
    /// and gets to zero after sell date
    /// </summary>
    public class BackstagePassUpdateQuality : ItemUpdate
    {
        public BackstagePassUpdateQuality(Item item) : base(item) { }
        protected override void UpdateQuality()
        {
            if (Item.SellIn < 0)
                Item.Quality = -Item.Quality;
            else if (Item.SellIn < 5)
                Item.Quality += 3;
            else if (Item.SellIn < 10)
                Item.Quality += 2;
            else
                Item.Quality++;
        }
    }

}
