using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests
{
    public class LogInHelper : HelperBase
    {

        public LogInHelper(ApplicationManager manager) : base(manager)
        {
        }
        public void LogIn(AccountData user)
        {
            if(IsLoggedIn())
            {
                if(IsLoggedIn(user))
                {
                    return;
                }
                LogOut();
            }
            driver.FindElement(By.Name("user")).Click();
            driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.Name("user")).SendKeys(user.Login);
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys(user.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        public void LogOut()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.Name("logout"));
            }
        }

        public bool IsLoggedIn(AccountData user)
        {
            return IsLoggedIn()
              && GetLoggetUsername() == user.Login;
        }

        public string GetLoggetUsername()
        {
            string text = driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text;
            //Text == "(" + user.Login = ")";
            return text.Substring(1, text.Length - 2);
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.Name("logout"));
        }


    }
}
