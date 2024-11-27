using System;
using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    public readonly IList<Item> Items;

    public GildedRose(IList<Item> items)
    {
        ArgumentNullException.ThrowIfNull(items);

        this.Items = items;
    }

    public void UpdateQuality()
    {
        try
        {
            for (var i = 0; i < Items.Count; i++)
            {
                var item = Items[i];
                UpdateQuality(item);
            }
        }
        catch (Exception)
        {
            //Handle exception
        }
    }

    private void UpdateQuality(Item item)
    {
        try
        {
            string itemType = DeterminType(item);

            switch (itemType)
            {
                case GildedRoseConstants.AgedBrie:
                    item.Quality += item.SellIn <= 0 ? 2 : 1;
                    break;
                case GildedRoseConstants.BackstagePasses:
                    if (item.SellIn <= 0)
                    {
                        item.Quality = 0;
                    }
                    else if (item.SellIn <= 5)
                    {
                        item.Quality += 3;
                    }
                    else if (item.SellIn > 5 && item.SellIn <= 10)
                    {
                        item.Quality += 2;
                    }
                    else
                    {
                        item.Quality++;
                    }
                    break;
                case GildedRoseConstants.Sulfuras:
                    item.Quality = 80;
                    break;
                case GildedRoseConstants.Conjured:
                    item.Quality -= item.SellIn <= 0 ? 2 : 1;
                    break;
                default:
                    item.Quality -= item.SellIn <= 0 ? 2 : 1;
                    break;
            }

            if (!itemType.Equals(GildedRoseConstants.Sulfuras))
            {
                if (item.Quality < 0) { item.Quality = 0; }
                if (item.Quality > 50) { item.Quality = 50; }
                item.SellIn--;
            }
        }
        catch (Exception ex)
        {
            //Handle exception
        }
    }

    private string DeterminType(Item item)
    {
        return item.Name switch
        {
            string s when s.Contains("Aged Brie", StringComparison.OrdinalIgnoreCase) => "Aged Brie",
            string s when s.Contains("Backstage passes", StringComparison.OrdinalIgnoreCase) => "Backstage passes",
            string s when s.Contains("Sulfuras", StringComparison.OrdinalIgnoreCase) => "Sulfuras",
            string s when s.Contains("Conjured", StringComparison.OrdinalIgnoreCase) => "Conjured",
            _ => "Default"
        };
    }
}