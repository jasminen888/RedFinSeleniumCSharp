using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace MyRedFinProject.PageObjects
{
    public class SearchPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        private By searchBoxField => By.Id("search-box-input");
        private By priceBox => By.XPath("//p[text()='Price']/../parent::div[@role='button']");
        private By selectPriceMin => By.XPath("//input[@placeholder='Enter min']");
        private By selectPriceMax => By.XPath("//input[@placeholder='Enter max']");
        private By selectPriceComplete => By.XPath("//span[text()='Done']/parent::button");
        private By selectBedComplete => By.XPath("//span[text()='Done']/parent::button");
        private By selectHomeTypeComplete => By.XPath("//span[text()='Done']/parent::button");
        private By searchBtn => By.XPath("//button[@data-rf-test-name='searchButton']");
        private By selectHomeType => By.XPath("//p[text()='Home type']/../parent::div[@role='button']");
        private By selectNumberofBeds => By.XPath("//p[text()='Beds/baths']/../parent::div[@role='button']");


        public SearchPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        // Enter the city name into the search box
        public void EnterCity(string city)
        {
            var searchBox = wait.Until(driver => 
            {
                var element = driver.FindElement(searchBoxField);
                return element.Displayed && element.Enabled ? element : null;
            });
            
            searchBox.Clear();
            searchBox.SendKeys(city);
            searchBox.Submit();
        }

        // Set a price range by specifying minimum and maximum prices
        public void SetPriceRange(string minPrice, string maxPrice)
{

            driver.FindElement(priceBox).Click();
            driver.FindElement(selectPriceMin).SendKeys(minPrice);
            driver.FindElement(selectPriceMax).SendKeys(maxPrice);
            driver.FindElement(selectPriceComplete).Click();
}
        // Select a property type from the dropdown
        public void SelectHomeType(string homeType)
        {
            var propertyTypeDropdown = wait.Until(driver => 
            {
                var element = driver.FindElement(selectHomeType);
                return element.Displayed && element.Enabled ? element : null;
            });
            propertyTypeDropdown.Click();

            var option = wait.Until(driver => 
            {
                var element = driver.FindElement(By.XPath($"//span[text()='{homeType}']/../../parent::div"));
                return element.Displayed && element.Enabled ? element : null;
            });
            option.Click();
            driver.FindElement(selectHomeTypeComplete).Click();
        }

        // Set the number of bedrooms
        public void SelectBedrooms(int bedrooms)
        {
            var bedroomsDropdown = wait.Until(driver => 
            {
                var element = driver.FindElement(selectNumberofBeds);
                return element.Displayed && element.Enabled ? element : null;
            });
            bedroomsDropdown.Click();

            var option = wait.Until(driver => 
            {
                var element = driver.FindElement(By.XPath($"//div[@aria-label='Number of bedrooms']/div[@data-text='{bedrooms}']"));
                return element.Displayed && element.Enabled ? element : null;
            });
            option.Click();
            driver.FindElement(selectBedComplete).Click();
        }

        // Apply the selected filters
        public void ClickSearchBtn()
        {
            var searchButton = wait.Until(driver => 
            {
                var element = driver.FindElement(searchBtn);
                return element.Displayed && element.Enabled ? element : null;
            });
            searchButton.Click();
        }

        // Verify search results based on set filters
        public bool VerifyPropertyCards(int expectedMinPrice, int expectedMaxPrice, int expectedBedrooms)
        {
            var propertyCards = wait.Until(driver => 
            {
                var elements = driver.FindElements(By.XPath("//div[@data-rf-test-name='mapHomeCard']"));
                return elements.Count > 0 ? elements : null;
            });

            foreach (var card in propertyCards)
            {               
                var price = Convert.ToInt32(card.FindElement(By.XPath("//span[contains(@class,'Price--value')]")).Text.Replace("$", "").Replace(",", "").Trim());
                var bedrooms = Convert.ToInt32(card.FindElement(By.XPath("//span[contains(@class,'Stats--bed')]")).Text.Replace("beds", "").Trim());

                if (!(price >= expectedMinPrice && price <= expectedMaxPrice)) return false;
                if (!(bedrooms >= expectedBedrooms)) return false;

            }

            return true;
        }
    }
}