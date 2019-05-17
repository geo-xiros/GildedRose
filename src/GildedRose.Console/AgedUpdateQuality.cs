﻿namespace GildedRose.Console
{
    /// <summary>
    /// quality increases by one every day and 
    /// by two after sell date passes
    /// </summary>
    public class AgedUpdateQuality : ItemUpdate
    {
        public AgedUpdateQuality(Item item) : base(item) { }
        protected override void UpdateQuality()
        {
            Item.Quality += (Item.SellIn < 0) ? 2 : 1;
        }
    }

}
