 using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Playwright;

namespace Playwright_Framework.Pages
{
    public class RegisterPage(IPage page) : BasePage(page)
    {
        public ILocator FirstNameInput => Page.GetByRole(AriaRole.Textbox, new() { Name = "First name:" });
        public ILocator LastNameInput => Page.GetByRole(AriaRole.Textbox, new() { Name = "Last name:" });
        public ILocator EmailInput => Page.GetByRole(AriaRole.Textbox, new() { Name = "Email:" });
        public ILocator PasswordInput => Page.GetByRole(AriaRole.Textbox, new() { Name = "Password:" });
        public ILocator ConfirmPasswordInput => Page.GetByRole(AriaRole.Textbox, new() { Name = "Confirm password:" });
        public ILocator RegisterButton => Page.GetByRole(AriaRole.Button, new() { Name = "Register" });

        public ILocator MaleRadioButton => Page.GetByRole(AriaRole.Radio, new() { Name = "Male", Exact = true });
        public ILocator FemaleRadioButton => Page.GetByRole(AriaRole.Radio, new() { Name = "Female", Exact = true });
    }
}
