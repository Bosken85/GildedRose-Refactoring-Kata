using System.Collections.Generic;
using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Test]
    public void DefaultItemDegradesByOneWhenSellInDateNotExceeded()
    {
        var items = new List<Item> { new Item { Name = "foo", SellIn = 10, Quality = 10 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(9));
        Assert.That(items[0].SellIn, Is.EqualTo(9));
    }

    [Test]
    public void DefaultItemDegradesByTwoWhenSellInDateExceeded()
    {
        var items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 10 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(8));
        Assert.That(items[0].SellIn, Is.EqualTo(-1));
    }

    [Test]
    public void AgedBrieImpvrovesByOneWhenSellInDateNotExceeded()
    {
        var items = new List<Item> { new Item { Name = GildedRoseConstants.AgedBrie, SellIn = 10, Quality = 10 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(11));
        Assert.That(items[0].SellIn, Is.EqualTo(9));
    }

    [Test]
    public void SulfurasNeverSells()
    {
        var items = new List<Item> { new Item { Name = GildedRoseConstants.Sulfuras, SellIn = 10, Quality = 10 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].SellIn, Is.EqualTo(10));
    }

    [Test]
    public void SulfurasNeverIsAlwaysQuality80()
    {
        var items = new List<Item> { new Item { Name = GildedRoseConstants.Sulfuras, SellIn = 10, Quality = 10 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(80));
    }

    [Test]
    public void AgedBrieImpvrovesByTwoWhenSellInDateExceeded()
    {
        var items = new List<Item> { new Item { Name = GildedRoseConstants.AgedBrie, SellIn = 0, Quality = 10 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(12));
        Assert.That(items[0].SellIn, Is.EqualTo(-1));
    }

    [Test]
    public void EachItemExceptSulfurasCantBeLowerThan0()
    {
        var items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = -1 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(0));
        Assert.That(items[0].SellIn, Is.EqualTo(-1));
    }

    [Test]
    public void EachItemExceptSulfurasCantBeHigherThan50()
    {
        var items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 60 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(50));
        Assert.That(items[0].SellIn, Is.EqualTo(-1));
    }

    [Test]
    public void Foo()
    {
        var items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Name, Is.EqualTo("foo"));
    }
}