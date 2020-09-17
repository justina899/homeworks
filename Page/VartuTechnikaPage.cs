using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTestai.Page
{
    class VartuTechnikaPage
    {
        private static IWebDriver _driver;

        private IWebElement _widthInput => _driver.FindElement(By.Id("doors_width"));

        private IWebElement _heightInput => _driver.FindElement(By.Id("doors_height"));

        private IWebElement _automatikaCheckbox => _driver.FindElement(By.Id("automatika"));

        private IWebElement _montavimasCheckbox => _driver.FindElement(By.Id("darbai"));

        private IWebElement _submit => _driver.FindElement(By.Id("calc_submit"));

        private IWebElement _actualResult => _driver.FindElement(By.CssSelector("#calc_result > div > strong"));


        public VartuTechnikaPage(IWebDriver webdriver)
        {
            _driver = webdriver;
        }

        public void InsertWidth(string width)
        {
            _widthInput.Clear();
            _widthInput.SendKeys(width);
        }

        public void InsertHeight(string height)
        {
            _heightInput.Clear();
            _heightInput.SendKeys(height);
        }

        public void InsertWidthHeight(string width, string height)
        {
            InsertWidth(width);
            InsertHeight(height);
        }

        public void checkAuto(bool shouldBeChecked)
        {
            if (_automatikaCheckbox.Selected != shouldBeChecked)
            {
                _automatikaCheckbox.Click();
            }
        }

        public void checkMontavimas(bool shouldBeChecked)
        {
            if (_montavimasCheckbox.Selected != shouldBeChecked)
            {
                _montavimasCheckbox.Click();
            }
        }

        public void Submit()
        {
            _submit.Click();
        }

        public void CheckResult(string result)
        {
            WaitForResult();
            Assert.IsTrue(_actualResult.Text.Contains(result), "Results are not the same");
        }

        private void WaitForResult()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.CssSelector("#calc_result > div")).Displayed);
        }
    }
}
