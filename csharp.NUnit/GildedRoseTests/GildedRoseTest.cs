using System.Collections.Generic;
using GildedRoseKata;
using NUnit.Framework;

namespace GildedRoseTests;

public class GildedRoseTest
{
    #region DefaultItem

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

    #endregion

    #region Sulfuras

    [Test]
    public void SulfurasNeverSells()
    {
        var items = new List<Item> { new Item { Name = GildedRoseConstants.Sulfuras, SellIn = 10, Quality = 10 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].SellIn, Is.EqualTo(10));
    }

    [Test]
    public void SulfurasIsAlwaysQuality80()
    {
        var items = new List<Item> { new Item { Name = GildedRoseConstants.Sulfuras, SellIn = 10, Quality = 10 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(80));
    }

    #endregion

    #region AgedBrie

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
    public void AgedBrieImpvrovesByTwoWhenSellInDateExceeded()
    {
        var items = new List<Item> { new Item { Name = GildedRoseConstants.AgedBrie, SellIn = 0, Quality = 10 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(12));
        Assert.That(items[0].SellIn, Is.EqualTo(-1));
    }

    #endregion

    #region BackstagePasses

    [Test]
    public void BackstagePassesQualityZeroIfSellInDateExceeded()
    {
        var items = new List<Item> { new Item { Name = GildedRoseConstants.BackstagePasses, SellIn = 0, Quality = 10 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(0));
        Assert.That(items[0].SellIn, Is.EqualTo(-1));
    }

    [Test]
    public void BackstagePassesQualityPlus1IfSellInDateAboveTen()
    {
        var items = new List<Item> { new Item { Name = GildedRoseConstants.BackstagePasses, SellIn = 20, Quality = 10 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(11));
        Assert.That(items[0].SellIn, Is.EqualTo(19));
    }

    [Test]
    public void BackstagePassesQualityPlus2IfSellInDateUnderTen()
    {
        var items = new List<Item> { new Item { Name = GildedRoseConstants.BackstagePasses, SellIn = 10, Quality = 10 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(12));
        Assert.That(items[0].SellIn, Is.EqualTo(9));
    }

    [Test]
    public void BackstagePassesQualityPlus3IfSellInDateUnderFive()
    {
        var items = new List<Item> { new Item { Name = GildedRoseConstants.BackstagePasses, SellIn = 5, Quality = 10 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(13));
        Assert.That(items[0].SellIn, Is.EqualTo(4));
    }

    #endregion

    #region Conjured

    [Test]
    public void ConjuredItemDegradesByOneWhenSellInDateNotExceeded()
    {
        //TODO: Issue 001: Is the verified test data not in line with the assignment?
        var items = new List<Item> { new Item { Name = "Conjured", SellIn = 10, Quality = 10 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(9));
        Assert.That(items[0].SellIn, Is.EqualTo(9));
    }

    [Test]
    public void ConjuredItemDegradesByTwoWhenSellInDateExceeded()
    {
        // TODO: Issue 001: Is the verified test data not in line with the assignment?
        var items = new List<Item> { new Item { Name = "Conjured", SellIn = 0, Quality = 10 } };
        var app = new GildedRose(items);
        app.UpdateQuality();
        Assert.That(items[0].Quality, Is.EqualTo(8));
        Assert.That(items[0].SellIn, Is.EqualTo(-1));
    }

    #endregion

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
}