using Playwright_Framework.Fixtures;
using static Microsoft.Playwright.Assertions;

namespace Playwright_Framework.Tests.ProductDetails;

[TestClass]
[TestCategory("ProductDetails")]
public class ProductDetailsTest : TestBase
{
    [TestMethod]
    [TestCategory("Smoke")]
    [DataRow("Books", "Computing and Internet")]
   
    public async Task User_Can_Open_Product_Details(string category, string productName)
    {
        // Arrange & Act
        var productDetails = await NavigateToProductDetailsPageAsync(category, productName);
      

        // Assert
        await Expect(productDetails.ProductTitle).ToContainTextAsync(productName);
    }


}
