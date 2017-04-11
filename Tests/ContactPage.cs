using OpenQA.Selenium;

namespace SeleniumCsharp
{
    class ContactPage
    {
        private IWebDriver firefoxDriver;

        public ContactPage(IWebDriver firefoxDriver)
        {
            this.firefoxDriver = firefoxDriver;
        }

        public IWebElement GetName()
        {
            return firefoxDriver.FindElement(By.Id("name"));
        }

        public IWebElement GetEmail()
        {
            return firefoxDriver.FindElement(By.Id("email"));
        }

        public IWebElement GetTopic()
        {
            return firefoxDriver.FindElement(By.Id("topic"));
        }

        public IWebElement GetText()
        {
            return firefoxDriver.FindElement(By.Id("text"));
        }

        public IWebElement GetSubmitButton()
        {
            return firefoxDriver.FindElement(By.Id("submit"));
        }

        public IWebElement GetValidationError(IWebDriver drv)
        {
            return drv.FindElement(By.XPath("//*[text()='Wpisany kod jest niepoprawny.']"));
        }
    }
}
