using NUnit.Framework;

namespace GildedRoseCalculator.Test;

[TestFixture]
public class GildedRoseTest
{
    // [Test]
    // public void foo()
    // {
    //     IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
    //     GildedRose app = new GildedRose(Items);
    //     app.UpdateQuality();
    //     Assert.AreEqual("fixme", Items[0].Name);
    // }
    
    [Test]
    //on the end of 50days quality should be 50
    public void BRI_When_50_Days_Then_Quality_50()
    {
        //Arange
        var listItems = new List<Item>
        {
            new Item()
            {
                Name = "Aged Brie",
                Quality = 0,
                SellIn = 50
            }
        };

        var gildRose = new GildedRose(listItems);

        //Act
        for (int i = 0; i <50; i++)
        {
            gildRose.UpdateQuality();
        }
        //Asserts
        Assert.AreEqual(50, listItems[0].Quality);
        Assert.AreEqual(0, listItems[0].SellIn);

    }
    
    [Test]
    //on the end of 50days quality should be 50
    public void BRI_When_100_Days_Then_Quality_50()
    {
        //Arange
        var listItems = new List<Item>
        {
            new Item()
            {
                Name = "Aged Brie",
                Quality = 0,
                SellIn = 50
            }
        };

        var gildRose = new GildedRose(listItems);

        //Act
        for (int i = 0; i <100; i++)
        {
            gildRose.UpdateQuality();
        }
        //Asserts
        Assert.AreEqual(50, listItems[0].Quality);
        Assert.AreEqual(0, listItems[0].SellIn);
    }
    
    [Test]
    public void itemUnknown_With_quality_5_When_10_Days_Then_Quality_0()
    {
        //Arange
        var listItems = new List<Item>
        {
            new Item()
            {
                Name = "Armour",
                Quality = 5,
                SellIn = 10
            }
        };

        var gildRose = new GildedRose(listItems);

        //Act
        for (int i = 0; i < 10; i++)
        {
            gildRose.UpdateQuality();
        }
        
        //Asserts
        Assert.AreEqual(0, listItems[0].Quality);
        Assert.AreEqual(0, listItems[0].SellIn);
    }
    
    [Test]
    public void Sulfuras_With_quality_50_When_10_Days_Then_Quality_80()
    {
        //Arange
        var listItems = new List<Item>
        {
            new Item()
            {
                Name = "Sulfuras",
                Quality = 50,
                SellIn = 10
            }
        };

        var gildRose = new GildedRose(listItems);

        //Act
        for (int i = 0; i < 10; i++)
        {
            gildRose.UpdateQuality();
        }
        
        //Asserts
        Assert.AreEqual(80, listItems[0].Quality);
        Assert.AreEqual(0, listItems[0].SellIn);
    }

    [TestCaseSource(nameof(TestCases))]
    public void UpdateQuality_ForTestCase_ReturnsExpectedResult(string name, int quality, int days, int expectedQuality, int expectedDaysLeft)
    {
        //Arrange
        var listItems = new List<Item>()
        {
            new Item()
            {
                Name = name,
                Quality = quality,
                SellIn = days
            }
        };

        var sut = new GildedRose(listItems);
        
        //Act
        for (int i = 0; i < days; i++)
        {
            sut.UpdateQuality();
        }
        
        //Assert
        Assert.AreEqual(expectedQuality, listItems[0].Quality);
        Assert.AreEqual(expectedDaysLeft, listItems[0].SellIn);
    }
    
    

    private static IEnumerable<TestCaseData> TestCases = new[]
    {
        //name, quality, days, expectedQuality, expectedDaysLeft
        new TestCaseData("Conjured", 50, 10, 30, 0),
        new TestCaseData("Sulfuras", 50,10,80,0),
        new TestCaseData("Armour", 5,10,0,0),
        new TestCaseData("Aged Brie", 0,50,50,0),
        new TestCaseData("Aged Brie", 0,100,50,0),
        
    };
}
