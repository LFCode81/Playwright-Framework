using static Microsoft.Playwright.Assertions;
using Playwright_Framework.Fixtures;

namespace Playwright_Framework.Tests.Home
{
    [TestClass]
    public class HomePageTests : TestBase
    {
        [TestMethod]
        [TestCategory("Smoke")]
        public async Task HomePage_Should_Load_Successfully()
        {
            //Arrange & Act
            await Pages.Home.NavigateAsync();


            //Assert
            await Expect(Pages.Home.WelcomeHeading).ToBeVisibleAsync();

        }
    }
}
