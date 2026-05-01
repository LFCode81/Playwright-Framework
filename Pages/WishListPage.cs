using Microsoft.Playwright;

namespace Playwright_Framework.Pages
{
    public class WishListPage(IPage page): BasePage(page)
    {
        public ILocator Header => Page.GetByRole(AriaRole.Heading, new() { Name = "Wishlist" });
    }
}
