namespace GildedRoseKata;

public static class ItemExtensions
{
    public static ICustomItem Convert(this Item item)
    {
        return item.Name switch
        {
            "Aged Brie" => new AgedBrie(item),
            "Sulfuras" => new SulfurasItem(item),
            "Backstage passes to a TAFKAL80ETC concert" => new BackstagePass(item),
            "Conjured" => new ConjuredItem(item),
            _ => new StandardItem(item)
        };
    }

    public static void QualityValidation(this Item item)
    {
        if (item.Quality < 0)
        {
            item.Quality = 0;
        }

        if (item.Quality > 50)
        {
            item.Quality = 50;
        }
    }
}