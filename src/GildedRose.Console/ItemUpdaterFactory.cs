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
                    return new NoItemUpdate(item);
                case "Aged Brie":
                    return new AgedItemUpdate(item);
                case "Backstage passes to a TAFKAL80ETC concert":
                    return new BackstagePassItemUpdate(item);
                case "Conjured Mana Cake":
                    return new ConjuredItemUpdate(item);
                default:
                    return new NormalItemUpdate(item);
            }
        }
    }
}
