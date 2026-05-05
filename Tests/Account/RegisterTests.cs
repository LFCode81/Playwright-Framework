using Playwright_Framework.Fixtures;
using static Microsoft.Playwright.Assertions;
namespace Playwright_Framework.Tests.Account;


[TestClass]
public class RegisterTests : TestBase
{
    [TestMethod]
    [TestCategory("Smoke")]
    [TestCategory("Register")]
    public async Task User_Can_Open_Register_Page()
    {
        var registerPage = await NavigateToRegisterPageAsync();
        await Expect(registerPage.RegisterButton).ToBeVisibleAsync();
    }

    [TestMethod]
    [TestCategory("Regression")]
    [TestCategory("Register")]
    public async Task User_Can_Register_With_Unique_Email()
    {
        // Arrange & Act
        var register = await NavigateToRegisterPageAsync();
        await register.NewCustomerAsync("John", "Doe", "Male");

        // Assert
        await Expect(register.ContinueButton).ToBeVisibleAsync();
        // Verify that the user is logged in by checking for the presence of the account link with the registered email
        await Expect(Page.Locator("a.account").First).ToHaveTextAsync(register.Email);
    }
}
