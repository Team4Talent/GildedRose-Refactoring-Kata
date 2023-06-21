namespace GildedRoseKata;

public class StandardItem : ICustomItem
{
    private readonly Item _item;

    public StandardItem(Item item)
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