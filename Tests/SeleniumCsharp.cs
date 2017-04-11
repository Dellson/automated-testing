using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumCsharp
{
    [TestFixture]
    public class SeleniumCsharp
    {
        private static IWebDriver firefoxDriver;
        private static Common common;
        private static ContactPage contactPage;

        [SetUp]
        public static void SetUp()
        {
            firefoxDriver = new FirefoxDriver();
            common = new Common(firefoxDriver);
            contactPage = new ContactPage(firefoxDriver);
        }

        [TearDown]
        public static void TearDown()
        {
            CloseBrowser();
        }

        [Test]
        public void TestCaseOne()
        {
            LoadPage();
            ClickContactButton();
            FillName();
            FillEmail();
            FillTopic();
            FillText();
            ClickSubmitButton();
        }

        private void LoadPage()
        {
            firefoxDriver.Navigate().GoToUrl(common.mainUrl);
        }

        private void ClickContactButton()
        {
            common.GetContactButton().Click();
            WebDriverWait wait = new WebDriverWait(firefoxDriver, new TimeSpan(0, 0, 5));
            wait.Until(drv => drv.Url == common.contactUrl);
        }

        private void FillName()
        {
            contactPage.GetName().SendKeys("Zbigniew Testowy");
        }

        private void FillEmail()
        {
            contactPage.GetEmail().SendKeys("zbigniew.testowy@gmail.com");
        }

        private void FillTopic()
        {
            contactPage.GetTopic().SendKeys("Test automatyczny");
        }

        private void FillText()
        {
            contactPage.GetText().SendKeys("Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
                "Curabitur id venenatis metus. Integer pharetra sed arcu in varius. Nulla faucibus ante nulla, " +
                "nec elementum odio porttitor fermentum. Nulla convallis dapibus fermentum.");
        }

        private void ClickSubmitButton()
        {
            contactPage.GetSubmitButton().SendKeys(Keys.Enter);
            WebDriverWait wait = new WebDriverWait(firefoxDriver, new TimeSpan(0, 0, 5));
            wait.Until(drv => contactPage.GetValidationError(drv));
        }

        private static void CloseBrowser()
        {
            firefoxDriver.Quit();
        }
    }
}