namespace GildedRose.Console
{
    /// <summary>
    /// items that never update quality
    /// </summary>
    public class NoItemUpdate : IItemUpdater
    {
        public void Update() {/* No Action */}
    }

}
