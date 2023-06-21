namespace GildedRoseCalculator;
public class GildedRose
{
    IList<Item> Items;
    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }

    public void UpdateQuality()
    {
        for (var i = 0; i < Items.Count; i++)
        {
            if (Items[i].Name.Contains("Sulfuras", StringComparison.OrdinalIgnoreCase))
            {
                Items[i].Quality = 80;
                Items[i].SellIn -= 1;
                return;
            }

            if (Items[i].Name.Contains("Conjured", StringComparison.OrdinalIgnoreCase))
            {
                ProcessConjured(i);
                return;
            }
            
            if (Items[i].Name.Contains("Armour", StringComparison.OrdinalIgnoreCase))
            {
                ProcessArmour(i);
                return;
            }

            if (Items[i].Name.Contains("Backstage Passes", StringComparison.OrdinalIgnoreCase))
            {
                ProcessBackStagePasses(i);
                return;
            }

            if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
            {
                if (Items[i].Quality > 0)
                {
                    if (Items[i].Name != "Hand of Ragnaros")
                    {
                        Items[i].Quality = Items[i].Quality - 1;
                    }
                }
            }
            else
            {
                if (Items[i].Quality < 50)
                {
                    Items[i].Quality = Items[i].Quality + 1;

                    if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (Items[i].SellIn < 11)
                        {
                            if (Items[i].Quality < 50)
                            {
                                Items[i].Quality = Items[i].Quality + 1;
                            }
                        }

                        if (Items[i].SellIn < 6)
                        {
                            if (Items[i].Quality < 50)
                            {
                                Items[i].Quality = Items[i].Quality + 1;
                            }
                        }
                    }
                }
            }

            if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
            {
                Items[i].SellIn = Items[i].SellIn - 1;
            }

            if (Items[i].SellIn < 0)
            {
                if (Items[i].Name != "Aged Brie")
                {
                    if (Items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (Items[i].Quality > 0)
                        {
                            if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                            {
                                Items[i].Quality = Items[i].Quality - 1;
                            }
                        }
                    }
                    else
                    {
                        Items[i].Quality = Items[i].Quality - Items[i].Quality;
                    }
                }
                else
                {
                    if (Items[i].Quality < 50)
                    {
                        Items[i].Quality = Items[i].Quality + 1;
                    }
                }
            }

            ProcessMaxMinVqlue(Items[i]);
        }
    }

    private void ProcessConjured(int i)
    {
        Items[i].Quality = ClampValue(Items[i].Quality - 2, 0, 50);
        Items[i].SellIn = ClampValue(Items[i].SellIn - 1, 0, int.MaxValue);
    }
    
    private void ProcessArmour(int i)
    {
        int factor = 1;
        if (Items[i].SellIn == 0)
        {
            factor = 2;
        }
        
        
        Items[i].Quality = ClampValue(Items[i].Quality - (1 * factor), 0, 50);
        Items[i].SellIn = ClampValue(Items[i].SellIn - 1, 0, int.MaxValue);
    }
    
    private void ProcessBackStagePasses(int i)
    {
        int factor = 1;
        if (Items[i].SellIn <= 10)
        {
            factor = 2;
        }
        if (Items[i].SellIn <= 5)
        {
            factor = 3;
        }
        Items[i].Quality = ClampValue(Items[i].Quality + (1 * factor), 0, 50);
        Items[i].SellIn = ClampValue(Items[i].SellIn - 1, 0, int.MaxValue);
    }

    private int ClampValue(int value, int min, int max)
    {
        if (value <= min)
            return min;
        if (value >= max)
            return max;

        return value;
    }

    private void ProcessMaxMinVqlue(Item item)
    {
        if (item.Quality > 50)
        {
            item.Quality = 50;
        }
        
        if (item.SellIn < 0)
        {
            item.SellIn = 0;
        }
    }
}

