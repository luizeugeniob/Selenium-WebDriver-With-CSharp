using EAuction.Selenium.Fixtures;
using OpenQA.Selenium;
using Xunit;

namespace EAuction.Selenium.Tests
{
    [Collection(Constants.CollectionDefinitionName)]
    public class WhenBrowsingHome
    {
        private readonly IWebDriver _driver;

        public WhenBrowsingHome(TestFixture fixture)
        {
            _driver = fixture.Driver;
        }

        [Fact]
        public void GivenChromeOpenShouldShowsLeiloesOnTitle()
        {
            //Action
            _driver.Navigate().GoToUrl("http://localhost:5000");

            //Assert
            Assert.Contains("Leilões", _driver.Title);
        }

        [Fact]
        public void GivenChromeOpenShouldShowsNextAuctionsOnPage()
        {
            //Action
            _driver.Navigate().GoToUrl("http://localhost:5000");

            //Assert
            Assert.Contains("Próximos Leilões", _driver.PageSource);
        }
    }
}
