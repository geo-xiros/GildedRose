namespace GildedRose.Console
{
    /// <summary>
    /// factory to get for each item the appropriate updater 
    /// </summary>
    public static class ItemUpdaterFactory
    {
        public static IItemUpdater GetItemUpdater(Item item)
        {
            switch (item.Name)
            {
                case "Sulfuras, Hand of Ragnaros":
                    return new NeverUpdateQuality(item);
                case "Aged Brie":
                    return new AgedUpdateQuality(item);
                case "Backstage passes to a TAFKAL80ETC concert":
                    return new BackstagePassUpdateQuality(item);
                case "Conjured Mana Cake":
                    return new ConjuredUpdateQuality(item);
                default:
                    return new NormalUpdateQuality(item);
            }
        }
    }
}
