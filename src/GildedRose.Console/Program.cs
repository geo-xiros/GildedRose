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
                if (item.Name == "Sulfuras, Hand of Ragnaros") continue;

                item.SellIn--;

                switch (item.Name)
                {
                    case "Aged Brie":
                        AgedQualityUpdate(item);
                        break;
                    case "Backstage passes to a TAFKAL80ETC concert":
                        BackstagePassQualityUpdate(item);
                        break;
                    case "Conjured Mana Cake":
                        ConjuredQualityUpdate(item);
                        break;
                    default:
                        NormalQualityUpdate(item);
                        break;
                }


                if (item.Quality < 0) item.Quality = 0;
                else if (item.Quality > 50) item.Quality = 50;
            }
        }
        private void NormalQualityUpdate(Item item)
        {
            item.Quality -= (item.SellIn < 0) ? 2 : 1;
        }
        private void ConjuredQualityUpdate(Item item)
        {
            item.Quality -= (item.SellIn < 0) ? 4 : 2;
        }
        private void BackstagePassQualityUpdate(Item item)
        {
            if (item.SellIn < 0)
                item.Quality = -item.Quality;
            else if (item.SellIn < 5)
                item.Quality += 3;
            else if (item.SellIn < 10)
                item.Quality += 2;
            else
                item.Quality++;
        }
        private void AgedQualityUpdate(Item item)
        {
            item.Quality += (item.SellIn < 0) ? 2 : 1;
        }

        public void UpdateQualityFor(int times)
        {
            for (; times > 0; times--)
                UpdateQuality();
        }
        public Item this[string name] => Items.FirstOrDefault(i => i.Name.Equals(name));

    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

}
