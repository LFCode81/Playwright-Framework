using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Playwright;

namespace Playwright_Framework.Pages
{
    public class LoginPage(IPage page) : BasePage(page)
    {

        public ILocator LoginTitle => Page.GetByRole(AriaRole.Heading, new() { Name = "Welcome, Please Sign In!" });

        public ILocator RegisterLink => Page.GetByRole(AriaRole.Button, new() { Name = "Register" });

        public ILocator EmailInput => Page.GetByRole(AriaRole.Textbox, new() { Name = "Email:" });
        public ILocator PasswordInput => Page.GetByRole(AriaRole.Textbox, new() { Name = "Password:" });

        public ILocator RememberMeCheckbox => Page.GetByRole(AriaRole.Checkbox, new() { Name = "Remember me" });

        public ILocator ForgotPasswordLink => Page.GetByRole(AriaRole.Link, new() { Name = "Forgot password?" });

        public ILocator LoginButton => Page.GetByRole(AriaRole.Button, new() { Name = "Log in" });

        public ILocator LoginErrorMessage => Page.GetByText("Login was unsuccessful. Please correct the errors and try again.");

        public ILocator EmailErrorMessage => Page.GetByText("Please enter your email");

        public ILocator PasswordErrorMessage => Page.GetByText("Please enter your password");

        public ILocator NewCustomerDescription => Page.GetByText("By creating an account on our website you will be able to shop faster, be up to date on an orders status, and keep track of the orders you have previously made.");


        public async Task LoginAsync(string email, string password, bool rememberMe = false)
        {
            await EmailInput.FillAsync(email);
            await PasswordInput.FillAsync(password);

            if (rememberMe)
            {
                await RememberMeCheckbox.CheckAsync();
            }
            else
            {
                await RememberMeCheckbox.UncheckAsync();
            }
            await LoginButton.ClickAsync();
        }


    }
}
