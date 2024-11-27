using System;
using System.Collections.Generic;

namespace GildedRoseKata;
public class Program
{
    public static void Main(string[] args)
    {
        int days = 2;
        if (args.Length > 0 )
            if (int.TryParse(args[0], out days))
            {
                /**What is the purpose of this +1? The validated test data depends on this code to validate,
                 * but it adds an additional day to the requested output since we start counting from index 0
                 * What is the desired behaviour here?
                **/
                days++;
            }

        var app = new GildedRose(Items);

        Console.WriteLine("OMGHAI!");
        for (var i = 0; i < days; i++)
        {
            Console.WriteLine($"-------- day {i} --------");
            Console.WriteLine(app.ToString());
            
            app.UpdateQuality();
        }
    }

    private static readonly IList<Item> Items = new List<Item>
        {
            new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
            new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
            new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
            new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
            new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
            new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 15,
                Quality = 20
            },
            new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 10,
                Quality = 49
            },
            new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 5,
                Quality = 49
            },
            new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
        };
}