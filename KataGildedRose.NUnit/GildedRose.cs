namespace Kata {
  using System;
  using System.Collections.Generic;

  public static class Names {
    public static string Vest = "+5 Dexterity Vest";
    public static string AgedBrie = "Aged Brie";
    public static string Elixir = "Elixir of the Mongoose";
    public static string Sulfuras = "Sulfuras, Hand of Ragnaros";
    public static string ConcertTickets = "Backstage passes to a TAFKAL80ETC concert";
    public static string Cake = "Conjured Mana Cake";
  }

  class Program {
    public Store Store { get; set; }

    static void Main(string[] args)
    {
      System.Console.WriteLine("OMGHAI!");

      var app = new Program
      {
        Store = Store.Create(new [] {
          new Item (Names.Vest) { SellIn = 10, Quality = 20},
          new Item (Names.AgedBrie) { SellIn = 2, Quality = 0},
          new Item (Names.Elixir) { SellIn = 5, Quality = 7},
          new Item (Names.Sulfuras) { SellIn = 0, Quality = 80},
          new Item (Names.ConcertTickets) { SellIn = 15, Quality = 20},
          new Item (Names.Cake) { SellIn = 3, Quality = 6}
        }, i => Store.UpdateItemQuality(i))
      };

      app.Store.UpdateQuality();

      System.Console.ReadKey();
    }
  }

  public class Store {
    public static Store Create(IEnumerable<Item> items) {
      return new Store {
        Items = new List<Item>(items),
        _updateItemQuality = item => Store.UpdateItemQuality(item)
      };
    }

    public static Store Create(IEnumerable<Item> items, Func<Item, Item> updateItemQuality) {
      return new Store {
        Items = new List<Item>(items),
        _updateItemQuality = updateItemQuality
      };
    }

    public List<Item> Items { get; private set; }
    private Func<Item, Item> _updateItemQuality;

    public static Item UpdateItemQuality(Item item) {
      if (item.Name == "Sulfuras, Hand of Ragnaros")
        return item;

      if (item.Name == "Aged Brie" || item.Name == "Backstage passes to a TAFKAL80ETC concert")
      {
          if (item.Quality < 50)
          {
              item.Quality = item.Quality + 1;

              if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
              {
                  if (item.SellIn < 11)
                  {
                      if (item.Quality < 50)
                      {
                          item.Quality = item.Quality + 1;
                      }
                  }

                  if (item.SellIn < 6)
                  {
                      if (item.Quality < 50)
                      {
                          item.Quality = item.Quality + 1;
                      }
                  }
              }
          }
      } else
        item.Quality--;

      item.SellIn = item.SellIn - 1;

      if (item.SellIn < 0)
      {
          if (item.Name != "Aged Brie")
          {
              if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
              {
                  if (item.Quality > 0)
                  {
                      if (item.Name != "Sulfuras, Hand of Ragnaros")
                      {
                          item.Quality = item.Quality - 1;
                      }
                  }
              }
              else
              {
                  item.Quality = item.Quality - item.Quality;
              }
          }
          else
          {
              if (item.Quality < 50)
              {
                  item.Quality = item.Quality + 1;
              }
          }
      }

      return item;
    }

    public void UpdateQuality() {
      for (var i = 0; i < Items.Count; i++) {
        var item = Items[i];
        _updateItemQuality(item);
      }
    }
  }
}
