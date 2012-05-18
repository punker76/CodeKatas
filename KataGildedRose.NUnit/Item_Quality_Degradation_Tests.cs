namespace Kata.Item_Quality_Degradation_Tests {
  using System;
  using NUnit.Framework;

  [TestFixture]
  public class When_Item_Is_Conjured {
    [Test]
    public void Then_Degrades_Twice_As_Fast() {
      var quality = Store.UpdateItemQuality(_item).Quality;
      Assert.AreEqual(4, quality);
    }

    Item _item = new Item(N_.Cake) { 
      SellIn = 3,
      Quality = 6
    };
  }

  [TestFixture]
  public class When_Item_Has_Quality_Of_Zero {
    [Test]
    public void Then_Quality_Doesnt_Degrade_Below_Zero() {
      var quality = Store.UpdateItemQuality(
        new Item { Quality = 1 }
      ).Quality;
      Assert.AreEqual(0, quality);
    }
  }

  [TestFixture]
  public class When_Item_Is_Sulfuras {
    [Test]
    public void Then_Quality_Doesnt_Change_At_All() {
      var quality = Store.UpdateItemQuality(
        new Item(N_.Sulfuras) { Quality = 4 }
      ).Quality;
      Assert.AreEqual(4, quality);
    }

    [Test]
    public void Then_SellIn_Doesnt_Change_At_All() {
      var sellin = Store.UpdateItemQuality(
        new Item(N_.Sulfuras) { SellIn = 3 }
      ).SellIn;
      Assert.AreEqual(3, sellin);
    }
  }
}
