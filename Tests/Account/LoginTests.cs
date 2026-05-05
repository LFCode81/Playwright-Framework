using Playwright_Framework.Fixtures;
using static Microsoft.Playwright.Assertions;

namespace Playwright_Framework.Tests.Account;

[TestClass]
public class LoginTests : TestBase
{
    [TestMethod]
    [TestCategory("Smoke")]
    [TestCategory("Login")]
    public async Task User_Can_Open_Login_Page()
    {
        // Arrange & Act
        var loginPage = await NavigateToLoginPageAsync();
        // Assert
        await Expect(loginPage.LoginTitle).ToBeVisibleAsync();
    }

    [TestMethod]
    [TestCategory("Regression")]
    [TestCategory("Login")]
    public async Task User_Cannot_Login_With_Invalid_Credentials()
    {
        // Arrange
        var loginPage = await NavigateToLoginPageAsync();
        // Act
        await loginPage.LoginAsync("invalid_user@example.com", "invalidPassword");
        // Assert
        await Expect(loginPage.LoginErrorMessage).ToBeVisibleAsync();
    }
}
