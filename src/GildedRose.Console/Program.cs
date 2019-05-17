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
                ItemUpdaterFactory.GetItemUpdater(item).Update();
            }
        }

        public void UpdateQualityFor(int times)
        {
            for (; times > 0; times--)
                UpdateQuality();
        }

        public Item this[string name] => Items.FirstOrDefault(i => i.Name.Equals(name));

    }
}
