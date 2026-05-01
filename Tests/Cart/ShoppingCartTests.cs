using Playwright_Framework.Fixtures;
using static Microsoft.Playwright.Assertions;


namespace Playwright_Framework.Tests.Cart;

[TestClass]
[TestCategory("Smoke")]
public class ShoppingCartTests : TestBase
{
    [TestMethod]
    [TestCategory("Smoke")]
    [DataRow("Books", "Computing and Internet","10.00")]
    public async Task User_Can_Add_Product_To_Cart(string category, string productName, string expectedPrice)
    {
        // Arrange & Act
        var productDetails = await NavigateToProductDetailsPageAsync(category, productName);

        await Expect(productDetails.ProductTitle).ToContainTextAsync(productName);
        await productDetails.AddToCartAsync();

        var shoppingCartPage = await productDetails.OpenShoppingCartAsync();
        var priceFromPage = await shoppingCartPage.GetFirstItemPriceAsync();


        // Assert
        Assert.AreEqual(expectedPrice, priceFromPage);
    }


    [TestMethod]
    [TestCategory("Smoke")]
    [DataRow("Books", "Computing and Internet", "2")]
    public async Task Cart_Count_Should_Update(string category, string productName, string itemCount)
    {
        // Arrange
        var productDetails = await NavigateToProductDetailsPageAsync(category, productName);
        int initialCartCount = await productDetails.HeaderLinks.GetShoppingCartItemCountAsync();

        // Act
        await productDetails.SetQuantityAsync(itemCount);
        await productDetails.AddToCartAsync();

        int updatedCartCount = await productDetails.HeaderLinks.GetShoppingCartItemCountAsync();

        // Assert
        Assert.AreEqual(initialCartCount + int.Parse(itemCount), updatedCartCount);
    }


    [TestMethod]
    [TestCategory("Smoke")]
    [DataRow("Books", "Computing and Internet", "5")]
    public async Task User_Can_Remove_Product_From_Cart(string category, string productName, string itemCount)
    {
        // Arrange
        var productDetails = await NavigateToProductDetailsPageAsync(category, productName);

        // Act
        await productDetails.SetQuantityAsync(itemCount);
        await productDetails.AddToCartAsync();

        int updatedCartCount = await productDetails.HeaderLinks.GetShoppingCartItemCountAsync();

        // Need to Remove...
    }
}
