namespace Ms.WhatIsUnitTestingSamples.Domain.Test;

public class CustomerTestLondon
{

    [Fact]
    public void Purchase_Done_Correct_Whene_Store_Has_Enough_Inventory()
    {
        var customer = new Customer();
        var product = new Product()
        {
            Name = "Livan"
        };
        var store = new StoreForValidPurchase();
         var result = customer.Purchase(store, product, 10);
        Assert.True(result);
    }
    [Fact]
    public void Purchase_Failed_Where_Store_Has_Not_Enough_Inventory()
    {
        var customer = new Customer();
        var product = new Product()
        {
            Name = "Livan"
        };
        var store = new StoreForFailedPurchase();
        var result = customer.Purchase(store, product, 10);
        Assert.False(result);

    }
}