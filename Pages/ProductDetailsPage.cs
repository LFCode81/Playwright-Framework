
using Microsoft.Playwright;
using Playwright_Framework.Extensions;
using static Microsoft.Playwright.Assertions;

namespace Playwright_Framework.Pages
{
    public class ProductDetailsPage(IPage page) : BasePage(page)
    {
 
        public ILocator ProductTitle => Page.Locator(".product-name h1");
        public ILocator ProductPrice => Page.Locator(".product-price .price-value");
        
        public ILocator AddToCartButton => Page.Locator(".add-to-cart-panel")
                                               .GetByRole(AriaRole.Button, new() { Name = "Add to cart" });


        public ILocator AddToWishlistButton => Page.Locator(".add-to-wishlist-button");
        public ILocator QuantityInput => Page.Locator(".qty-input");

        public ILocator SuccessNotification => Page.Locator(".bar-notification.success");

        public ILocator ShoppingCartQty => Page.Locator(".cart-qty");



        public async Task<string> GetProductTitleAsync()
        {
            return await ProductTitle.InnerTextAsync();
        }

        public async Task<string> GetProductPriceAsync()
        {
            return await ProductPrice.InnerTextAsync();
        }

        public async Task AddItemToCartAsync()
        {
            var currentQtyText = await ShoppingCartQty.InnerTextAsync();

            await Expect(AddToCartButton).ToBeVisibleAsync();
            await AddToCartButton.ClickAsync();

            await Expect(SuccessNotification).ToBeVisibleAsync();
            await Expect(ShoppingCartQty).Not.ToHaveTextAsync(currentQtyText);
        }

        public async Task AddToWishlistAsync()
        {
            await AddToWishlistButton.ClickAsync();
        }

        public async Task SetQuantityAsync(string quantity)
        {
            await QuantityInput.FillAsync(quantity);
        }

        public async Task<ShoppingCartPage> OpenShoppingCartAsync()
        {
            await HeaderLinks.ShoppingCartLink.ClickAsyncSafe();
            var cartPage = new ShoppingCartPage(Page);
            await cartPage.WaitForPageAsync();

            return cartPage;

        }
    }
}
