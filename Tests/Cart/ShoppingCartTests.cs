using Playwright_Framework.Extensions;
using Playwright_Framework.Fixtures;
using Playwright_Framework.Models;
using Playwright_Framework.TestDataProviders;
using static Microsoft.Playwright.Assertions;


namespace Playwright_Framework.Tests.Cart;

[TestClass]
[TestCategory("Smoke")]
public class ShoppingCartTests : TestBase
{
    [TestMethod]
    [TestCategory("Smoke")]
    [TestCategory("Cart")]
    [DataRow("Books", "Computing and Internet","10.00")]
    public async Task User_Can_Add_Product_To_Cart(string category, string productName, string expectedPrice)
    {
        // Arrange & Act
        var productDetails = await NavigateToProductDetailsPageAsync(category, productName);

        await Expect(productDetails.ProductTitle).ToContainTextAsync(productName);
        await productDetails.AddItemToCartAsync();

        var CartPage = await productDetails.OpenShoppingCartAsync();
        var priceFromPage = await CartPage.GetItemInCartAsync(productName);


        // Assert
        Assert.AreEqual(expectedPrice, priceFromPage);
    }

    [TestMethod]
    [TestCategory("Cart")]
    [TestCategory("Smoke")]
    [DataRow("Books", "Computing and Internet", "2")]
    public async Task Cart_Count_Should_Update(string category, string productName, string itemCount)
    {
        // Arrange
        var productDetails = await NavigateToProductDetailsPageAsync(category, productName);
        int initialCartCount = await productDetails.HeaderLinks.GetShoppingCartItemCountAsync();

        // Act
        await productDetails.SetQuantityAsync(itemCount);
        await productDetails.AddItemToCartAsync();

        int updatedCartCount = await productDetails.HeaderLinks.GetShoppingCartItemCountAsync();

        // Assert
        Assert.AreEqual(initialCartCount + int.Parse(itemCount), updatedCartCount);
    }

    [TestMethod]
    [DynamicData(nameof(CartTestDataProvider.CartRegressionCases), typeof(CartTestDataProvider))]
    [TestCategory("Regression")]
    [TestCategory("Cart")]
    public async Task User_Can_Add_Product_To_Cart( CartTestCase testCase )
    {
        // Arrange & Act
        var productDetails = await NavigateToProductDetailsPageAsync( testCase.Category, testCase.ProductName, testCase.SubCategory );

        await productDetails.AddItemToCartAsync();
        var cartPage = await productDetails.OpenShoppingCartAsync();
        var actualPrice = await cartPage.GetItemInCartAsync(testCase.ProductName);


        // Assert
        Assert.AreEqual(testCase.ExpectedPrice, actualPrice);

    }

    [TestMethod]
    [TestCategory("Cart")]
    [TestCategory("Regression")]
    [DynamicData(nameof(CartTestDataProvider.CartRegressionCases), typeof(CartTestDataProvider))]
    public async Task User_Can_Update_Product_Quantity_In_Cart( CartTestCase testCase )
    {
        // Arrange
        var productDetails = await NavigateToProductDetailsPageAsync(testCase.Category, testCase.ProductName, testCase.SubCategory);
       
        // Act 
        await productDetails.AddItemToCartAsync();
        var cartPage = await productDetails.OpenShoppingCartAsync();

        await cartPage.SetQuantityAsync(testCase.ProductName, "5");
        string actualTotal = await cartPage.GetSubTotalAsync();

        // Assert
        Assert.AreEqual( testCase.ExpectedPrice.ToDecimal() * 5, actualTotal.ToDecimal() );

    }

    [TestMethod]
    [TestCategory("Cart")]
    [TestCategory("Regression")]
    [DynamicData(nameof(CartTestDataProvider.CartRegressionCases), typeof(CartTestDataProvider))]
    public async Task User_Can_Remove_Product_From_Cart(CartTestCase testCase)
    {
        // Arrange
        var productDetails = await NavigateToProductDetailsPageAsync(testCase.Category, testCase.ProductName, testCase.SubCategory);

        // Act 
        await productDetails.AddItemToCartAsync();
        var cart = await productDetails.OpenShoppingCartAsync();
        await cart.RemoveProductFromCart(testCase.ProductName);

        // Assert
        await Expect(cart.EmptyCartMessage).ToContainTextAsync("Your Shopping Cart is empty!");

    }
}
