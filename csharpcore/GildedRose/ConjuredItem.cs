namespace GildedRoseKata;

public class ConjuredItem : ICustomItem
{
    private readonly Item _item;

    public ConjuredItem(Item item)
    {
        _item = item;
    }

    public Item Calculate()
    {
        _item.Quality--;

        if (_item.SellIn <= 0)
        {
            _item.Quality--;
        }
        _item.SellIn--;

        _item.QualityValidation();
        return _item;
    }
}