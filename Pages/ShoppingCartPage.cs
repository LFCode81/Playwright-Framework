using static Microsoft.Playwright.Assertions;
using Microsoft.Playwright;

namespace Playwright_Framework.Pages
{
    public class ShoppingCartPage(IPage page) : BasePage(page)
    {
        public ILocator PageTitle => Page.Locator(".page-title h1");
        public ILocator CheckOutButon => Page.GetByRole(AriaRole.Button, new() { Name = "Checkout" });
        public ILocator CartTableRows => Page.Locator("table.cart tbody tr");

        public ILocator FirstItemPriceCell => CartTableRows.First.Locator(".product-unit-price");

        public async Task WaitForPageToLoadAsync()
        {
            await Expect(Page).ToHaveURLAsync(new Regex("cart", RegexOptions.IgnoreCase));
            await Expect(PageTitle).ToHaveTextAsync("Shopping cart");
        }

        public async Task<string> GetFirstItemPriceAsync()
        {
            await Expect(CartTableRows.First).ToBeVisibleAsync();
            await Expect(FirstItemPriceCell).ToBeVisibleAsync();

            return await FirstItemPriceCell.InnerTextAsync();
        }
    }
}
