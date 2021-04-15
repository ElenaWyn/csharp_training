using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace mantis_tests
{
    public class LogInHelper : HelperBase
    {
        public LogInHelper(ApplicationManager manager) : base(manager) { }

        public void CheckIfAccountIsLogedIn()
        {
            if(IsElementPresent(By.Id("logout-link")))
            {
                driver.FindElement(By.Id("logout-link")).Click();
            }
        }

        public void LogIn(AccountData account)
        {
            driver.FindElement(By.Id("username")).SendKeys(account.Name);
            driver.FindElement(By.Id("password")).SendKeys(account.Password);
            driver.FindElement(By.XPath("//input[@class='button']")).Click();
            string xpath = "//*[contains(text(), '" +  account.Name + "')]";
            IsElementPresent(By.XPath(xpath));
        }


    }
}
