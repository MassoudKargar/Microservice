namespace Ms.WhatIsUnitTestingSamples.Domain;

public class Customer
{
    private Dictionary<Product, int> _basket = new();

    public bool Purchase(IStore store, Product product, int count)
    {
        if (!store.HasEnoughtInventory(product, count)) return false;
        store.RemoveProduct(product, count);
        AddToBasket(product,count);
        return true;
    }


    private void AddToBasket(Product product, int count)
    {
        if (_basket.ContainsKey(product))
        {
            _basket[product] += count;
        }
        else
        {
            _basket[product] = count;
        }
    }

    public int Inventory(Product product)
    {
        return _basket.ContainsKey(product) ? _basket[product] : 0;
    }
}