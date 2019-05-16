using Xunit;
using GildedRose.Console;

namespace GildedRose.Tests
{
    public class TestAssemblyTests
    {
        [Theory]
        [InlineData(5, 20, 1, 4)]
        [InlineData(5, 20, 2, 3)]
        [InlineData(5, 20, 5, 0)]
        [InlineData(5, 20, 10, -5)]
        public void SellInShouldDecreaseByDay(int sellIn, int quality, int updates, int expectedSellIn)
        {
            var gr = new Program("Test", quality, sellIn);

            gr.UpdateQualityFor(updates);

            Assert.Equal(expectedSellIn, gr["Test"].SellIn);

        }

        [Theory]
        [InlineData(5, 20, 1, 5)]
        [InlineData(5, 20, 2, 5)]
        [InlineData(5, 20, 5, 5)]
        [InlineData(5, 20, 10, 5)]
        public void SulfurasSellInShouldNotDecreaseByDay(int sellIn, int quality, int updates, int expectedSellIn)
        {
            var gr = new Program("Sulfuras, Hand of Ragnaros", quality, sellIn);

            gr.UpdateQualityFor(updates);

            Assert.Equal(expectedSellIn, gr["Sulfuras, Hand of Ragnaros"].SellIn);

        }

        [Theory]
        [InlineData(5, 20, 1, 19)]
        [InlineData(5, 20, 2, 18)]
        [InlineData(5, 20, 5, 15)]
        public void QualityShouldBeDegradededByOne(int sellIn, int quality, int updates, int expectedQuality)
        {
            var gr = new Program("Test", quality, sellIn);

            gr.UpdateQualityFor(updates);

            Assert.Equal(expectedQuality, gr["Test"].Quality);

        }

        [Theory]
        [InlineData(5, 20, 6, 13)]
        [InlineData(5, 20, 9, 7)]
        [InlineData(5, 20, 10, 5)]
        public void QualityShoulDecreaseTwiceAfterSellDatePasses(int sellIn, int quality, int updates, int expectedQuality)
        {
            var gr = new Program("Test", quality, sellIn);

            gr.UpdateQualityFor(updates);

            Assert.Equal(expectedQuality, gr["Test"].Quality);
        }

        [Theory]
        [InlineData(5, 5, 10, 0)]
        [InlineData(5, 20, 20, 0)]
        public void QualityShoulNeverGetNegative(int sellIn, int quality, int updates, int expectedQuality)
        {
            var gr = new Program("Test", quality, sellIn);

            gr.UpdateQualityFor(updates);

            Assert.Equal(expectedQuality, gr["Test"].Quality);
        }

        [Theory]
        [InlineData(5, 5, 2, 7)]
        [InlineData(5, 5, 4, 9)]
        [InlineData(5, 5, 5, 10)]
        public void AgedBrieQualityShouldIncreaseEveryDay(int sellIn, int quality, int updates, int expectedQuality)
        {
            var gr = new Program("Aged Brie", quality, sellIn);

            gr.UpdateQualityFor(updates);

            Assert.Equal(expectedQuality, gr["Aged Brie"].Quality);
        }

        [Theory]
        [InlineData(5, 5, 6, 12)]
        [InlineData(5, 5, 7, 14)]
        [InlineData(5, 5, 9, 18)]
        public void AgedBrieQualityShouldIncreaseTwiceAfterSellDatePassByDay(int sellIn, int quality, int updates, int expectedQuality)
        {
            var gr = new Program("Aged Brie", quality, sellIn);

            gr.UpdateQualityFor(updates);

            Assert.Equal(expectedQuality, gr["Aged Brie"].Quality);
        }

        [Theory]
        [InlineData(5, 45, 5, 50)]
        [InlineData(5, 45, 7, 50)]
        [InlineData(5, 45, 9, 50)]
        public void QualityShouldNeverIncreaseMoreThanFifty(int sellIn, int quality, int updates, int expectedQuality)
        {
            var gr = new Program("Aged Brie", quality, sellIn);

            gr.UpdateQualityFor(updates);

            Assert.Equal(expectedQuality, gr["Aged Brie"].Quality);
        }

        [Theory]
        [InlineData(5, 10, 2, 10)]
        [InlineData(5, 10, 10, 10)]
        [InlineData(5, 10, 7, 10)]
        public void SulfurasQualityShouldNeverChange(int sellIn, int quality, int updates, int expectedQuality)
        {
            var gr = new Program("Sulfuras, Hand of Ragnaros", quality, sellIn);

            gr.UpdateQualityFor(updates);

            Assert.Equal(expectedQuality, gr["Sulfuras, Hand of Ragnaros"].Quality);
        }

        [Theory]
        [InlineData(15, 20, 2, 22)]
        [InlineData(15, 20, 3, 23)]
        [InlineData(15, 20, 5, 25)]
        public void BackstageQualityShouldIncreaseByDay(int sellIn, int quality, int updates, int expectedQuality)
        {
            var gr = new Program("Backstage passes to a TAFKAL80ETC concert", quality, sellIn);

            gr.UpdateQualityFor(updates);

            Assert.Equal(expectedQuality, gr["Backstage passes to a TAFKAL80ETC concert"].Quality);
        }

        [Theory]
        [InlineData(15, 20, 6, 27)]
        [InlineData(15, 20, 7, 29)]
        [InlineData(15, 20, 8, 31)]
        [InlineData(15, 20, 10, 35)]
        public void BackstageQualityShouldIncreaseTwiceByDayForTheLastTenDaysBeforeSellDatePasses(int sellIn, int quality, int updates, int expectedQuality)
        {
            var gr = new Program("Backstage passes to a TAFKAL80ETC concert", quality, sellIn);

            gr.UpdateQualityFor(updates);

            Assert.Equal(expectedQuality, gr["Backstage passes to a TAFKAL80ETC concert"].Quality);
        }


        [Theory]
        [InlineData(15, 20, 11, 38)]
        [InlineData(15, 20, 12, 41)]
        [InlineData(15, 20, 13, 44)]
        [InlineData(15, 20, 14, 47)]
        [InlineData(15, 20, 15, 50)]
        public void BackstageQualityShouldIncreaseByThreeByDayForTheLastFiveDaysBeforeSellDatePasses(int sellIn, int quality, int updates, int expectedQuality)
        {
            var gr = new Program("Backstage passes to a TAFKAL80ETC concert", quality, sellIn);

            gr.UpdateQualityFor(updates);

            Assert.Equal(expectedQuality, gr["Backstage passes to a TAFKAL80ETC concert"].Quality);
        }

        [Theory]
        [InlineData(15, 20, 16, 0)]
        [InlineData(15, 20, 18, 0)]
        public void BackstageQualityShouldBeZeroAfterSellDatePasses(int sellIn, int quality, int updates, int expectedQuality)
        {
            var gr = new Program("Backstage passes to a TAFKAL80ETC concert", quality, sellIn);

            gr.UpdateQualityFor(updates);

            Assert.Equal(expectedQuality, gr["Backstage passes to a TAFKAL80ETC concert"].Quality);
        }

        [Theory]
        [InlineData(5, 20, 1, 18)]
        [InlineData(5, 20, 2, 16)]
        [InlineData(5, 20, 5, 10)]
        public void ConjuredQualityShouldBeDegradededByTwo(int sellIn, int quality, int updates, int expectedQuality)
        {
            var gr = new Program("Conjured Mana Cake", quality, sellIn);

            gr.UpdateQualityFor(updates);

            Assert.Equal(expectedQuality, gr["Conjured Mana Cake"].Quality);

        }

        [Theory]
        [InlineData(5, 20, 6, 6)]
        [InlineData(5, 20, 7, 2)]
        [InlineData(5, 20, 8, 0)]
        public void ConjuredQualityShoulDecreaseTwiceAsNormalItemsAfterSellDatePasses(int sellIn, int quality, int updates, int expectedQuality)
        {
            var gr = new Program("Conjured Mana Cake", quality, sellIn);

            gr.UpdateQualityFor(updates);

            Assert.Equal(expectedQuality, gr["Conjured Mana Cake"].Quality);
        }
    }
}