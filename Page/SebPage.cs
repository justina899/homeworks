using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoTestai.Page
{
    class SebPage
    {
        private static IWebDriver _driver;
        private IWebElement _incomeInput => _driver.FindElement(By.Id("income"));

        private IWebElement _frame => _driver.FindElement(By.Id("lease-calculator"));

        private SelectElement _cityDropDown => new SelectElement(_driver.FindElement(By.Id("city")));

        public SebPage(IWebDriver webdriver)
        {
            _driver = webdriver;
        }
        public void InsertIncome(string income)
        {
            
            _incomeInput.Clear();
            _incomeInput.SendKeys(income);
        }

        public void SelectDropDownValue(string city)
        {
            _cityDropDown.SelectByValue(city);

        }
    }
}
