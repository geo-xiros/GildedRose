namespace GildedRose.Console
{
    public abstract class ItemUpdate : IItemUpdater
    {
        protected Item Item;
        public ItemUpdate(Item item) { Item = item; }

        public void Update()
        {
            UpdateSellIn();
            UpdateQuality();
            ValidateQuality();
        }

        protected abstract void UpdateQuality();

        /// <summary>
        /// decrease sellin for each day
        /// </summary>
        private void UpdateSellIn()
        {
            Item.SellIn--;
        }

        /// <summary>
        /// after updating quality value should not be below zero or above fifty
        /// </summary>
        private void ValidateQuality()
        {
            if (Item.Quality < 0)
                Item.Quality = 0;
            else if (Item.Quality > 50)
                Item.Quality = 50;
        }
    }

}
