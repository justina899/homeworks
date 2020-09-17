using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTestai.Page
{
    class CheckBoxDemoPage
    {
        private static IWebDriver _driver;
        private IWebElement _checkBox => _driver.FindElement(By.Id("isAgeSelected"));
        private IWebElement _checkBoxIsCheckedText => _driver.FindElement(By.Id("txtAge"));
        private IWebElement _checkButton => _driver.FindElement(By.Id("check1"));

        public CheckBoxDemoPage(IWebDriver webdriver)
        {
            _driver = webdriver;
        }

        public void CheckThisCheckBox(bool shouldBeChecked)
        {
            if (_checkBox.Selected != shouldBeChecked)
            {
                _checkBox.Click();
            }
        }

        public void IsChecked(string text)
        {
            Assert.IsTrue(_checkBoxIsCheckedText.Text.Contains(text), "Results are not the same");
        }

        public void CheckElements() 
        {
            var elements = _driver.FindElements(By.ClassName("checkbox"));
            foreach (var element in elements)
            {
                element.Click();
            }
        }

        public void CheckValue(string value)
        {
            Assert.AreEqual(value, _checkButton.GetAttribute("value"), "value is not the same");
        }

    }
}
