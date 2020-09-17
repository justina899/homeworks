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
    class CheckBoxDemoTest
    {
        private static IWebDriver _driver;

        [OneTimeSetUp]

        public static void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Url = "https://www.seleniumeasy.com/test/basic-checkbox-demo.html";
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //_driver.FindElement(By.Id("at-cv-lightbox-close")).Click();
        }

        [Test]
        public static void TestIfCheckBoxIsChecked()
        {
            CheckBoxDemoPage page = new CheckBoxDemoPage(_driver);
            page.CheckThisCheckBox(true);
            page.IsChecked("Success - Check box is checked");

        }

        [Test]
        public static void TestIfAllElementsAreChecked()
        {
            CheckBoxDemoPage page = new CheckBoxDemoPage(_driver);
            page.CheckElements();
            page.CheckValue("Uncheck All");
        }

        [OneTimeTearDown]

        public static void TearDown()
        {
           // _driver.Quit();
        }
    }
}
