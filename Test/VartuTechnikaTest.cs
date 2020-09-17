﻿using AutoTestai.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTestai.Test
{
    class VartuTechnikaTest
    {
        private static IWebDriver _driver;

        [OneTimeSetUp]

        public static void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Url = "http://vartutechnika.lt/";
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.FindElement(By.Id("cookiescript_reject")).Click();
        }

        [TestCase("2000", "2000", true, false, "665.98", TestName = "2000 x 2000 + Vartų automatika = 665.98")]
        [TestCase("4000", "2000", true, true, "1006.43", TestName = "4000 x 2000 + Vartu automatika + montavimas = 1006.43")]
        [TestCase("4000", "2000", false, false, "692.35", TestName = "4000 x 2000 = 692.35")]
        [TestCase("5000", "2000", false, true, "989.21", TestName = "5000 x 2000 + montavimas = 989.21")]

        public static void TestVartuTechnika(string width, string height, bool auto, bool darbai, string result)
        {
            VartuTechnikaPage page = new VartuTechnikaPage(_driver);
            page.InsertWidthHeight(width, height);
            page.checkAuto(auto);
            page.checkMontavimas(darbai);
            page.Submit();
            page.CheckResult(result);
        }

        [OneTimeTearDown]

        public static void TearDown()
        {
            _driver.Quit();
        }
    }
}
