namespace Ms.WhatIsUnitTestingSamples.Domain.Test;

public class StoreForValidPurchase : IStore
{
    public void AddProduct(Product product, int count)
    {
        throw new NotImplementedException();
    }

    public bool HasEnoughtInventory(Product product, int count)
    {
        return true;
    }

    public int Inventory(Product product)
    {
        throw new NotImplementedException();
    }

    public void RemoveProduct(Product product, int count)
    {

    }
}