using EAuction.Selenium.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace EAuction.Selenium.Fixtures
{
    public class TestFixture : IDisposable
    {
        public IWebDriver Driver { get; private set; }

        public TestFixture()
        {
            Driver = new ChromeDriver(TestHelper.ExecutablePath());
        }

        public void Dispose()
        {
            Driver.Quit();
        }
    }
}
