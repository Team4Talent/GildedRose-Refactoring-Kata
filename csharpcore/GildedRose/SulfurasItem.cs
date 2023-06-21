namespace GildedRoseKata;

public class SulfurasItem : ICustomItem
{
    private readonly Item _item;

    public SulfurasItem(Item item)
    {
        _item = item;
    }

    public Item Calculate()
    {
        _item.Quality = 80;
        return _item;
    }
}