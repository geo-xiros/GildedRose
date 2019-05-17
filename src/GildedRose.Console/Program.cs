using System.Collections.Generic;
using System.Linq;

namespace GildedRose.Console
{
    public class Program
    {
        public Program() { }
        public Program(string name, int quality, int sellIn)
        {
            Items = new List<Item>() { new Item() { Name = name, Quality = quality, SellIn = sellIn } };
        }

        IList<Item> Items;
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
            {
                Items = new List<Item>
                        {
                            new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                            new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                            new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                            new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                            new Item
                                {
                                    Name = "Backstage passes to a TAFKAL80ETC concert",
                                    SellIn = 15,
                                    Quality = 20
                                },
                            new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                        }

            };

            app.UpdateQuality();

            System.Console.ReadKey();

        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {

                IItemUpdater updateQuality = new NormalUpdateQuality(item);

                switch (item.Name)
                {
                    case "Sulfuras, Hand of Ragnaros":
                        updateQuality = new NeverUpdateQuality(item);
                        break;
                    case "Aged Brie":
                        updateQuality = new AgedUpdateQuality(item);
                        break;
                    case "Backstage passes to a TAFKAL80ETC concert":
                        updateQuality = new BackstagePassUpdateQuality(item);
                        break;
                    case "Conjured Mana Cake":
                        updateQuality = new ConjuredUpdateQuality(item);
                        break;

                }
                updateQuality.Update();
            }
        }

        public void UpdateQualityFor(int times)
        {
            for (; times > 0; times--)
                UpdateQuality();
        }
        public Item this[string name] => Items.FirstOrDefault(i => i.Name.Equals(name));

    }
    public interface IItemUpdater
    {
        void Update();
    }


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
        protected virtual void UpdateSellIn()
        {
            Item.SellIn--;
        }

        /// <summary>
        /// after updating quality value should not be below zero or above fifty
        /// </summary>
        protected virtual void ValidateQuality()
        {
            if (Item.Quality < 0)
                Item.Quality = 0;
            else if (Item.Quality > 50)
                Item.Quality = 50;
        }
    }

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

    /// <summary>
    /// quality decreases twice as fase as normal items
    /// </summary>
    public class ConjuredUpdateQuality : ItemUpdate
    {
        public ConjuredUpdateQuality(Item item) : base(item) { }

        protected override void UpdateQuality()
        {
            Item.Quality -= (Item.SellIn < 0) ? 4 : 2;
        }
    }

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

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

}
