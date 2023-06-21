using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        [Theory]
        [InlineData(2, 0, 0, -1)]
        [InlineData(1, 0, 0, -1)]
        public void WhenSellInDateIsZeroQualityDecreasesByTwo_2(int quality, int sellIn, int qualityResult, int sellinResult)
        {
            IList<Item> Items = new List<Item> { new Item { Name = "fixme", SellIn = sellIn, Quality = quality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal("fixme", Items[0].Name);
            Assert.Equal(qualityResult, Items[0].Quality);
            Assert.Equal(sellinResult, Items[0].SellIn);
        }

        [Fact]
        public void ItemQualityReducesEachDay()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "fixme", SellIn = 1, Quality = 1 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal("fixme", Items[0].Name);
            Assert.Equal(0, Items[0].Quality);
            Assert.Equal(0, Items[0].SellIn);
        }

        [Fact]
        public void QualityCannotBeBelowZero()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "fixme", SellIn = 1, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal("fixme", Items[0].Name);
            Assert.Equal(0, Items[0].Quality);
            Assert.Equal(0, Items[0].SellIn);
        }

        [Theory]
        [InlineData(1, 2, 2, 1)]
        [InlineData(50, 2, 50, 1)]
        [InlineData(48, 0, 50, -1)]
        public void AgedBrieIncreasesQuality(int quality, int sellIn, int qualityResult, int sellinResult)
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = sellIn, Quality = quality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal("Aged Brie", Items[0].Name);
            Assert.Equal(qualityResult, Items[0].Quality);
            Assert.Equal(sellinResult, Items[0].SellIn);
        }

        [Theory]
        [InlineData(1, 2, 80, 2)]
        [InlineData(50, 2, 80, 2)]
        [InlineData(48, 0, 80, 0)]
        public void SulfurasQualityNeverChanges(int quality, int sellIn, int qualityResult, int sellinResult)
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras", SellIn = sellIn, Quality = quality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal("Sulfuras", Items[0].Name);
            Assert.Equal(qualityResult, Items[0].Quality);
            Assert.Equal(sellinResult, Items[0].SellIn);
        }

        // Backstage passes to a TAFKAL80ETC concert


        [Theory]
        [InlineData(1, 20, 2, 19)]
        [InlineData(1, 10, 3, 9)]
        [InlineData(1, 7, 3, 6)]
        [InlineData(1, 5, 4, 4)]
        [InlineData(1, 3, 4, 2)]
        [InlineData(1, 0, 0, -1)]
        public void BackstagePassQualityChanges(int quality, int sellIn, int qualityResult, int sellinResult)
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = quality } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal("Backstage passes to a TAFKAL80ETC concert", Items[0].Name);
            Assert.Equal(qualityResult, Items[0].Quality);
            Assert.Equal(sellinResult, Items[0].SellIn);
        }
    }
}
