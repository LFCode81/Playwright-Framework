using Microsoft.Playwright;
using Playwright_Framework.Extensions;
using Playwright_Framework.Pages;
using static System.Net.Mime.MediaTypeNames;

namespace Playwright_Framework.Components
{
    public class HeaderLinksComponent( IPage page ) : BasePage( page )
    {
  
        private ILocator HeaderLnks => Page.Locator(".header-links");

        public ILocator RegisterLink =>
            HeaderLnks.GetByRole(AriaRole.Link, new() { Name = "Register", Exact = true });

        public ILocator LoginLink =>
            HeaderLnks.GetByRole(AriaRole.Link, new() { Name = "Log in", Exact = true });

        public ILocator LogoutLink =>
            HeaderLnks.GetByRole(AriaRole.Link, new() { Name = "Log out", Exact = true });

        public ILocator ShoppingCartLink =>
            HeaderLnks.GetByRole(AriaRole.Link, new() { Name = "Shopping cart", Exact = false });

        public ILocator WishlistLink =>
            HeaderLnks.GetByRole(AriaRole.Link, new() { Name = "Wishlist", Exact = false });

        public async Task GoToRegisterAsync()
        {
            await RegisterLink.ClickAsyncSafe();
        }

        public async Task GoToLoginAsync()
        {
            await LoginLink.ClickAsyncSafe();
        }

        public async Task GoToShoppingCartAsync()
        {
            await ShoppingCartLink.ClickAsyncSafe();
        }

        public async Task GoToWishlistAsync()
        {
            await WishlistLink.ClickAsyncSafe();
        }

        public async Task LogoutAsync()
        {
            await LogoutLink.ClickAsyncSafe();
        }

        public async Task<int> GetShoppingCartItemCountAsync()
        {
            var cartText = await ShoppingCartLink.InnerTextAsync();
            var match = Regex.Match(cartText, @"\((\d+)\)");
            if (!match.Success)
                throw new InvalidOperationException($"Could not parse cart count from: {cartText}");

            return int.Parse(match.Groups[1].Value);
        }

    }
}
