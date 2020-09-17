using AutoTestai.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTestai.Test
{
    class BasicDemoTest
    {
        private static IWebDriver _driver;

        [OneTimeSetUp]

        public static void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.FindElement(By.Id("at-cv-lightbox-close")).Click();
        }

        [Test]

        public static void EnterMessageTestWithPageObject()
        {
            string testText = "saldainiai";

            BasicDemoPage page = new BasicDemoPage(_driver);
            page.InsertText(testText);
            page.ClickButton();
            page.CheckResult(testText);
        }

        [TestCase("2", "2", "4", TestName = "Du plius du")]
        [TestCase("-3", "5", "2", TestName = "-3 plius 5")]
        [TestCase("a", "b", "NaN", TestName = "a plius b")]

        public static void TestSumWithPageObject(string firstInput, string secondInput, string sumResult)
        {
            BasicDemoPage page = new BasicDemoPage(_driver);
            page.InsertAll(firstInput, secondInput);
            page.ClickSumbutton();
            page.CheckSum(sumResult);
        }

        [OneTimeTearDown]

        public static void TearDown()
        {
            _driver.Quit();
        }
    }
}
