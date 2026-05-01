
using Microsoft.Playwright;
using Playwright_Framework.Extensions;

namespace Playwright_Framework.Pages
{
    public class CategoryPage( IPage page ) : BasePage( page )
    {
        public ILocator PageTitle => Page.Locator(".page-title h1");


        public ILocator ProductTitles => Page.Locator(".product-title a");

        public ILocator GetProductItem(string productName) =>
            ProductTitles.Filter(new() { HasText = productName }).First;



        //Navigate to product details page by clicking on the product link

        public async Task<ProductDetailsPage> OpenProductAsync(string productName)
        {
            await GetProductItem(productName).ClickAsyncSafe();

            var productDetails = new ProductDetailsPage(Page);
            await productDetails.WaitForPageAsync(); // Redo this later.

            return productDetails;
        }
    }

}
