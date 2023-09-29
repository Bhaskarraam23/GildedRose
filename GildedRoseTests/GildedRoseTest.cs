using Xunit;
using System.Collections.Generic;
using GildedRoseKata;
using static GildedRoseKata.GildedRose;

namespace GildedRoseTests;
public class GildedRoseTest
{
    private Item CreateAndUpdate(int sellIn, int quality, string itemName)
    {
        IList<Item> Items = new List<Item> { new Item { Name = itemName, SellIn = sellIn, Quality = quality } };
        GildedRose app = new(Items);
        app.UpdateQuality();
        return Items[0];
    }
    [Fact]
    public void foo()
    {
        Item item = CreateAndUpdate(0, 0, "foo");
        Assert.Equal("foo", item.Name);
    }
    [Fact]
    public void SystemLowersValues()
    {
        Item item = CreateAndUpdate(15, 25, "foo");
        Assert.Equal(14, item.SellIn);
        Assert.Equal(24, item.Quality);
    }

    [Fact]
    public void Qdegrees()
    {
        Item item = CreateAndUpdate(0, 17, "foo");
        Assert.Equal(15, item.Quality);
    }
    [Fact]
    public void NeverNegative()
    {
        Item item = CreateAndUpdate(0, 0, "foo");
        Assert.Equal(0, item.Quality);
    }
    [Fact]
    public void AgedBrieIncreases()
    {
        Item item = CreateAndUpdate(15, 25, AgedBrie);
        Assert.Equal(26, item.Quality);
    }
    [Fact]
    public void NeverExpire()
    {
        Item item = CreateAndUpdate(0, 42, AgedBrie);
        Assert.Equal(-1, item.SellIn);
        Assert.Equal(44, item.Quality);
    }
    [Fact]
    public void BackstagePasses()
    {
        Item item = CreateAndUpdate(10, 48, BackstagePass);
        Assert.Equal(MaximumQuality, item.Quality);
        item = CreateAndUpdate(5, 49, BackstagePass);
        Assert.Equal(MaximumQuality, item.Quality);
        item = CreateAndUpdate(4, 30, BackstagePass);
        Assert.Equal(33, item.Quality);
        item = CreateAndUpdate(0, 30, BackstagePass);
        Assert.Equal(0, item.Quality);
        item = CreateAndUpdate(0, 30, BackstagePass);
        Assert.Equal(0, item.Quality);
    }

    [Fact]
    public void ConjuredItem()
    {
        Item item = CreateAndUpdate(15, 25, Conjured);
        Assert.Equal(23, item.Quality);
    }
    
}
