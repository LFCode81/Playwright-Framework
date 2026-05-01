using Playwright_Framework.Fixtures;
using static Microsoft.Playwright.Assertions;

namespace Playwright_Framework.Tests.Navigation;

[TestClass]
public class NavigationTests : TestBase
{
    [TestMethod]
    [TestCategory("Smoke")]
    [DataRow("Books")]
    [DataRow("Computers")]
    public async Task User_Can_Navigate_To_Category(string category)
    {
        //Arrange & Act
        var categoryPage = await NavigateToCategoryPageAsync(category);


        //Assert
        await Expect(categoryPage.PageTitle).ToHaveTextAsync(category);

    }
}
