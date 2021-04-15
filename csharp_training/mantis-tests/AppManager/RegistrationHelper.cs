using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class RegistrationHelper : HelperBase
    {
        public RegistrationHelper(ApplicationManager manager) : base(manager) { }

        public void Register(AccountData account)
        {
            OpenMainPage();
            OpenRegistrationForm();
            FillRegistrationForm(account);
            SubmitRegistration();
        }

        public void OpenRegistrationForm()
        {
            driver.FindElements(By.CssSelector("span.bracket-link"))[0].Click();
        }

        public void SubmitRegistration()
        {
            driver.FindElement(By.CssSelector("input.button")).Click();
        }

        public void FillRegistrationForm(AccountData account)
        {
           
            driver.FindElement(By.Name("username")).SendKeys(account.Name);
            driver.FindElement(By.Name("email")).SendKeys(account.Email);
        }

        public void OpenMainPage()
        {
            manager.Driver.Url = "https://localhost/mantisbt-1.3.20/login_page.php";
            Thread.Sleep(5000);
        }
    }
}
