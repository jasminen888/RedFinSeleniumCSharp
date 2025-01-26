using NUnit.Framework;
using MyRedFinProject.PageObjects;
using RHSAutomationTest.tests;
using System.Threading;

namespace MyRedFinProject.Tests
{
    [TestFixture]
    public class PropertySearchTest: BaseTests
    {
        private SearchPage searchPage;     

        [Test]
        public void VerifyPropertySearchWithFilters()
        {
            searchPage = new(driver);

            // Step 1: Enter the City for search
            searchPage.EnterCity("Portland, OR");
            Thread.Sleep(30000);
            // Step 2: Set filters for price range, bedrooms, and property type
            searchPage.SetPriceRange("400000", "700000"); //Filter #1 - Search for Price Range
            searchPage.SelectBedrooms(3); //Filter #2 - Search for #s of Bedrooms
            searchPage.SelectHomeType("House"); //Filter #3 - Search for Property Type
            searchPage.ClickSearchBtn();

            // Step 3: Verify search results return matches the search criteria.
            Assert.IsTrue(searchPage.VerifyPropertyCards(400000, 700000, 3), "Verify Search Results return matches the search criteria.");
        }
    }
}
