using static Microsoft.Playwright.Assertions;
using Playwright_Framework.Fixtures;


namespace Playwright_Framework.Tests.Search;

[TestClass]
[TestCategory("Smoke")]
public class SearchTests : TestBase
{
    [TestMethod]
    [DataRow("laptop",true)]
    [DataRow("book", true)]
    [DataRow("000", false)] 
    [TestCategory("Smoke")]
    public async Task Search_Should_Return_Matching_Products(string searchTerm, bool shouldHaveResults)
    {
        
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
}
