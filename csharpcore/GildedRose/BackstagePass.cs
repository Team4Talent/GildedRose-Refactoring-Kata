namespace GildedRoseKata;

public class BackstagePass : ICustomItem
{
    private readonly Item _item;

    public BackstagePass(Item item)
    {
        _item = item;
    }

    public Item Calculate()
    {
        _item.Quality++;

        if (_item.SellIn <= 10)
        {
            _item.Quality++;
        }

        if (_item.SellIn <= 5)
        {
            _item.Quality++;
        }

        if (_item.SellIn <= 0)
        {
            _item.Quality = 0;
        }

        _item.SellIn--;

        _item.QualityValidation();
        return _item;
    }
}