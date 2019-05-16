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
            for (var i = 0; i < Items.Count; i++)
            {
                if (Items[i].Name == "Sulfuras, Hand of Ragnaros") continue;

                Items[i].SellIn--;

                switch (Items[i].Name)
                {
                    case "Aged Brie":
                        AgedQualityUpdate(i);
                        break;
                    case "Backstage passes to a TAFKAL80ETC concert":
                        BackstagePassQualityUpdate(i);
                        break;
                    default:
                        NormalQualityUpdate(i);
                        break;
                }


                if (Items[i].Quality < 0) Items[i].Quality = 0;
                else if (Items[i].Quality > 50) Items[i].Quality = 50;
            }
        }
        private void NormalQualityUpdate(int i)
        {
            Items[i].Quality--;
            if (Items[i].SellIn < 0) Items[i].Quality--;
        }
        private void BackstagePassQualityUpdate(int i)
        {
            if (Items[i].SellIn < 0)
                Items[i].Quality = -Items[i].Quality;
            else if (Items[i].SellIn < 5)
                Items[i].Quality += 3;
            else if (Items[i].SellIn < 10)
                Items[i].Quality += 2;
            else
                Items[i].Quality++;

        }
        private void AgedQualityUpdate(int i)
        {
            Items[i].Quality++;
            if (Items[i].SellIn < 0) Items[i].Quality++;
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
