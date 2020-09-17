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
    class SebTest
    {
        private static IWebDriver _driver;

        [OneTimeSetUp]

        public static void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Url = "https://www.seb.lt/privatiems/kreditai-ir-lizingas/kreditai/busto-kreditas-0#1";
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.FindElement(By.CssSelector("body div.seb-cookie-consent.seb-cookiemessage > div > div:nth-child(4) > ul > li:nth-child(1) > a > span")).Click();
            _driver.SwitchTo().Frame(0);
        }

        [Test]

        public static void TestSeb()
        {
            SebPage page = new SebPage(_driver);
            page.InsertIncome("1000");
            page.SelectDropDownValue("Klaipeda");

        }

        [OneTimeTearDown]

        public static void TearDown()
        {
            //_driver.Quit();
        }
    }
}
