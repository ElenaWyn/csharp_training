using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests
{
    class GeneralMethods
    {
        private IWebDriver driver = new FirefoxDriver();
        




        public void LogOut()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }
        public void LogIn(AccountData user)
        {
            driver.FindElement(By.Name("user")).Click();
            driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.Name("user")).SendKeys(user.Login);
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys(user.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        public void OpenHomePage(string baseURL)
        {
            driver.Navigate().GoToUrl(baseURL);
        }

    }
}
