namespace Ms.WhatIsUnitTestingSamples.Domain.Test;

public class CustomerTestClassic
{
    [Fact]
    public void Purchase_Done_Correct_Whene_Store_Has_Enough_Inventory()
    {
        var customer = new Customer();
        var store = new Store();
        var product = new Product()
        {
            Name = "Livan"
        };
        store.AddProduct(product, 100);

        var result = customer.Purchase(store, product, 10);
        Assert.True(result);
        Assert.Equal(90, store.Inventory(product));
        Assert.Equal(10, customer.Inventory(product));
    }

    [Fact]
    public void Purchase_Failed_Where_Store_Has_Not_Enough_Inventory()
    {
        var customer = new Customer();
        var store = new Store();
        var product = new Product()
        {
            Name = "Livan"
        };
        store.AddProduct(product, 20);

        var result = customer.Purchase(store, product, 30);
        Assert.False(result);
        Assert.Equal(20, store.Inventory(product));
        Assert.Equal(0, customer.Inventory(product));
    }
}