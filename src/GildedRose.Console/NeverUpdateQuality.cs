namespace GildedRose.Console
{
    /// <summary>
    /// items that never update quality
    /// </summary>
    public class NeverUpdateQuality : ItemUpdate
    {
        public NeverUpdateQuality(Item item) : base(item) { }
        protected override void UpdateSellIn() {/* No Action */}
        protected override void UpdateQuality() {/* No Action */}
        protected override void ValidateQuality() {/* No Action */}
    }

}
