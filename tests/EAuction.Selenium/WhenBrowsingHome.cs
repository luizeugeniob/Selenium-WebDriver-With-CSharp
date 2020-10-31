using EAuction.Selenium.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace EAuction.Selenium
{
    public class WhenBrowsingHome
    {
        [Fact]
        public void GivenChromeOpenShouldShowsLeiloesOnTitle()
        {
            //Arrange
            IWebDriver driver = new ChromeDriver(TestHelper.ExecutablePath());

            //Action
            driver.Navigate().GoToUrl("http://localhost:5000");

            //Assert
            Assert.Contains("Leilões", driver.Title);
        }

        [Fact]
        public void GivenChromeOpenShouldShowsNextAuctionsOnPage()
        {
            //Arrange
            IWebDriver driver = new ChromeDriver(TestHelper.ExecutablePath());

            //Action
            driver.Navigate().GoToUrl("http://localhost:5000");

            //Assert
            Assert.Contains("Próximos Leilões", driver.PageSource);
        }
    }
}
