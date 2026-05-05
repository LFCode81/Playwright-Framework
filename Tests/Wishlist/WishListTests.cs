using Playwright_Framework.Fixtures;
using static Microsoft.Playwright.Assertions;

namespace Playwright_Framework.Tests.Wishlist;

[TestClass]
public class WishListTests : TestBase
{
    [TestMethod]
    [TestCategory("Smoke")]
    [TestCategory("Wishlist")]
    public async Task User_Can_Open_Wishlist()
    {
        //Arrange & act
        var wishlistPage = await NavigateToWishlistPageAsync();


        //Assert
        await Expect(wishlistPage.Header).ToBeVisibleAsync();

    }
}
