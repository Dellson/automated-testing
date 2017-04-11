using OpenQA.Selenium;

namespace SeleniumCsharp
{
    class Common
    {
        private IWebDriver firefoxDriver;
        public string mainUrl { get; private set; }
        public string contactUrl { get; private set; }

        public Common(IWebDriver firefoxDriver)
        {
            this.firefoxDriver = firefoxDriver;
            mainUrl = "http://www.amberteam.pl";
            contactUrl = "http://www.amberteam.pl/pl/kontakt";
        }

        public IWebElement GetContactButton()
        {
            return firefoxDriver.FindElement(By.CssSelector("a[href='/pl/kontakt']"));
        }
    }
}
