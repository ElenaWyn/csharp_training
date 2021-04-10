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
            driver.FindElement(By.LinkText("Зарегистрировать новую учётную запись")).Click();
        }

        public void SubmitRegistration()
        {
            driver.FindElement(By.XPath("//input[@value = 'Зарегистрироваться']")).Click();
        }

        public void FillRegistrationForm(AccountData account)
        {
           
            driver.FindElement(By.Id("username")).SendKeys(account.Name);
            driver.FindElement(By.Id("email-field")).SendKeys(account.Email);
        }

        public void OpenMainPage()
        {
            manager.Driver.Url = "https://localhost/mantisbt-2.25.0/login_page.php";
            Thread.Sleep(5000);
        }
    }
}
