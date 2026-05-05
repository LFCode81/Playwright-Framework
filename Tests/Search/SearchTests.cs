using Playwright_Framework.Fixtures;
using Playwright_Framework.Models;
using Playwright_Framework.TestDataProviders;
using static Microsoft.Playwright.Assertions;
using System.Reflection;

namespace Playwright_Framework.Tests.Search;

[TestClass]
public class SearchTests : TestBase
{
    [TestMethod]
    [TestCategory("Search")]
    [TestCategory("Smoke")]
    [DataRow("Laptop search returns products", "laptop", true)]
    [DataRow("Unknown search shows no results", "zzzz-no-match", false)]

    public async Task Search_Should_Return_Matching_Products(string caseName, string searchTerm, bool shouldHaveResults)
    {
        _ = caseName; // Temp for now.
        var searchResultsPage = await NavigateToSearchResultsPageAsync(searchTerm);

        if (shouldHaveResults)
        {
            await Expect(searchResultsPage.ProductItems.First).ToBeVisibleAsync();
        }
        else
        {
            await Expect(searchResultsPage.NoResultsMessage).ToBeVisibleAsync();
        }

    }

    [TestMethod]
    [TestCategory("Search")]
    [TestCategory("Regression")]
    [DataRow("From Books Category -> Search For Laptops", "Books", "laptop")]
    public async Task Search_Should_Work_From_Category_Page(string caseName, string category, string searchTerm)
    {
        _ = caseName; // Temp for now.

        //Arrange 
        var categoryPage = await NavigateToCategoryPageAsync(category);

        //Act
        var searchResultsPage = await categoryPage.Search.ForItemAsync(searchTerm);

        // Assert
        await Expect(searchResultsPage.SearchKeyword).ToHaveValueAsync(searchTerm);
        await Expect(searchResultsPage.ProductItems.First).ToBeVisibleAsync();

    }
}
