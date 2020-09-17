using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTestai.Page
{
    class BasicDemoPage
    {
        private static IWebDriver _driver;

        private IWebElement _inputField => _driver.FindElement(By.Id("user-message"));

        private IWebElement _button => _driver.FindElement(By.CssSelector("#get-input > button"));

        private IWebElement _actualResult => _driver.FindElement(By.Id("display"));

        private IWebElement _firstInput => _driver.FindElement(By.Id("sum1"));
       
        private IWebElement _secondInput => _driver.FindElement(By.Id("sum2"));

        private IWebElement _sumButton => _driver.FindElement(By.CssSelector("#gettotal > button"));

        private IWebElement _actualSumResult => _driver.FindElement(By.Id("displayvalue"));
        

        public BasicDemoPage(IWebDriver webdriver)
        {
            _driver = webdriver;
        }

        public void InsertText(string text)
        {
            _inputField.SendKeys(text);
        }

        public void InsertFirstInput(string text)
        {
            _firstInput.Clear();
            _firstInput.SendKeys(text);
        }

        public void InsertSecondInput(string text)
        {
            _secondInput.Clear();
            _secondInput.SendKeys(text);
        }

        public void InsertAll(string firstText, string secondText)
        {
            InsertFirstInput(firstText);
            InsertSecondInput(secondText);
        }

        public void ClickSumbutton()
        {
            _sumButton.Click();
        }

        public void ClickButton()
        {
            _button.Click();
        }

        public void CheckSum(string sumResult)
        {
            Assert.AreEqual(sumResult, _actualSumResult.Text, "Result is NOK");
        }

        public void CheckResult(string expectedResult)
        {
            Assert.AreEqual(expectedResult, _actualResult.Text, "Text is not the same");
        }
    }
}
