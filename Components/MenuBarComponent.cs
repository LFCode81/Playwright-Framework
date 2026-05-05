using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Playwright;
using Playwright_Framework.Pages;

namespace Playwright_Framework.Components
{

    public class MenuBarComponent(IPage page) : BasePage(page)
    {
        private ILocator TopMenu => Page.Locator(".top-menu");

        public ILocator HomeLink =>
            TopMenu.GetByRole(AriaRole.Link, new() { Name = "Home", Exact = true });

        public ILocator BooksLink =>
            TopMenu.GetByRole(AriaRole.Link, new() { Name = "Books", Exact = true });

        public ILocator ComputersLink =>
            TopMenu.GetByRole(AriaRole.Link, new() { Name = "Computers", Exact = true });

        public ILocator ElectronicsLink =>
            TopMenu.GetByRole(AriaRole.Link, new() { Name = "Electronics", Exact = true });

        public ILocator ApparelLink =>
            TopMenu.GetByRole(AriaRole.Link, new() { Name = "Apparel & Shoes", Exact = true });

        public ILocator DigitalDownloadsLink =>
            TopMenu.GetByRole(AriaRole.Link, new() { Name = "Digital downloads", Exact = true });

        public ILocator JewelryLink =>
            TopMenu.GetByRole(AriaRole.Link, new() { Name = "Jewelry", Exact = true });

        public ILocator GiftCardsLink =>
            TopMenu.GetByRole(AriaRole.Link, new() { Name = "Gift Cards", Exact = true });

        public async Task GoToCategoryAsync(string categoryName)
        {
            ILocator categoryLink = categoryName switch
            {
                "Home" => HomeLink,
                "Books" => BooksLink,
                "Computers" => ComputersLink,
                "Electronics" => ElectronicsLink,
                "Apparel & Shoes" => ApparelLink,
                "Digital downloads" => DigitalDownloadsLink,
                "Jewelry" => JewelryLink,
                "Gift Cards" => GiftCardsLink,
                _ => throw new ArgumentException($"Unsupported category: {categoryName}")
            };
            await categoryLink.ClickAsync();
        }
    }
}
