using System.Diagnostics.CodeAnalysis;
using Microsoft.Playwright;
using Playwright_Framework.Utilities;

namespace Playwright_Framework.Pages
{
    public class RegisterPage(IPage page) : BasePage(page)
    {
        public ILocator FirstNameInput => Page.GetByRole(AriaRole.Textbox, new() { Name = "First name:" });
        public ILocator LastNameInput => Page.GetByRole(AriaRole.Textbox, new() { Name = "Last name:" });
        public ILocator EmailInput => Page.GetByRole(AriaRole.Textbox, new() { Name = "Email:" });
        public ILocator PasswordInput => Page.GetByRole(AriaRole.Textbox, new() { Name = "Password:" }).First;
        public ILocator ConfirmPasswordInput => Page.GetByRole(AriaRole.Textbox, new() { Name = "Confirm password:" });

        public ILocator RegisterButton => Page.GetByRole(AriaRole.Button, new() { Name = "Register" });

        public ILocator MaleRadioButton => Page.GetByRole(AriaRole.Radio, new() { Name = "Male", Exact = true });
        public ILocator FemaleRadioButton => Page.GetByRole(AriaRole.Radio, new() { Name = "Female", Exact = true });

        public ILocator ContinueButton => Page.GetByRole(AriaRole.Button, new() { Name = "Continue" });

        public string Email { get; } = TestDataHelpers.TestData.UniqueEmail();
        public string Password { get; } = TestDataHelpers.TestData.UniquePassword();

        public async Task NewCustomerAsync(string firstName, string lastName, string gender)
        {

            await FirstNameInput.FillAsync(firstName);
            await LastNameInput.FillAsync(lastName);
            await EmailInput.FillAsync(Email);

            await PasswordInput.FillAsync(Password);
            await ConfirmPasswordInput.FillAsync(Password);

            if (gender.Equals("Male", StringComparison.OrdinalIgnoreCase))
            {
                await MaleRadioButton.CheckAsync();
            }
            else if (gender.Equals("Female", StringComparison.OrdinalIgnoreCase))
            {
                await FemaleRadioButton.CheckAsync();
            }

            await RegisterButton.ClickAsync();
        }
    }

}
