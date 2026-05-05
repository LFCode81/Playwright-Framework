using static Microsoft.Playwright.Assertions;
using Microsoft.Playwright;
using Playwright_Framework.Extensions;

namespace Playwright_Framework.Pages
{
    public class ShoppingCartPage(IPage page) : BasePage(page)
    {
        public ILocator PageTitle => Page.Locator(".page-title h1");
        public ILocator CheckOutButon => Page.GetByRole(AriaRole.Button, new() { Name = "Checkout" });

        public ILocator UpdateShoppingCart => Page.GetByRole(AriaRole.Button, new() { Name = "Update shopping cart" });
        public ILocator CartTableRows => Page.Locator("table.cart tbody tr");

        public ILocator FirstItemPriceCell => CartTableRows.First.Locator(".product-unit-price");

        public ILocator ProductTotal => CartTableRows.Locator(".product-subtotal");

        public ILocator OrderTotal => Page.GetByRole(AriaRole.Row).Filter(new() { HasText = "Total:" })
                                                                  .Locator("strong");

        public ILocator SubTotal => Page.GetByRole(AriaRole.Row).Filter(new() { HasText = "Sub-Total:" })
                                                                .Locator(".product-price");


        public ILocator EmptyCartMessage => Page.Locator(".order-summary-content")
                                                .Filter(new() { HasText = "Your Shopping Cart is empty!" });



        public async Task<string> GetItemInCartAsync(string productName)
        {
            var row = GetProduct(productName);

            await Expect(row).ToBeVisibleAsync();
            var priceCell = row.Locator(".product-unit-price");
            await Expect(priceCell).ToBeVisibleAsync();

            return await priceCell.InnerTextAsync();
        }

        public async Task SetQuantityAsync(string productName, string quantity)
        {
            var row = GetProduct(productName);

            string InitialSubTotal = await GetSubTotalAsync();

            var quantityInput = row.Locator(".qty-input");

            await quantityInput.FillAsync(quantity);
            await Expect(quantityInput).ToHaveValueAsync(quantity);

            await UpdateShoppingCart.ClickAsyncSafe();
            await Expect(OrderTotal).Not.ToHaveTextAsync(InitialSubTotal);

        }

        public async Task RemoveProductFromCart(string productName)
        {
            var row = GetProduct(productName);

            var removeCheckbox = row.Locator("input[type='checkbox']");
            await removeCheckbox.CheckAsync();
            await UpdateShoppingCart.ClickAsyncSafe();

            await Expect(GetProduct(productName)).ToHaveCountAsync(0);
        }

        public ILocator GetProduct(string productName)
        {
            return CartTableRows.Filter(new() { HasText = productName }).First;
        }

        public async Task<string> GetSubTotalAsync()
        {
            await Expect(SubTotal).ToBeVisibleAsync();
            return (await SubTotal.InnerTextAsync()).Trim();
        }
    }
}
