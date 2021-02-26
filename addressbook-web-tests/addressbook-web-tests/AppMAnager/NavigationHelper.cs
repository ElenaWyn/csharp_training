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
    public class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }
        
        public void GoToGroupsPage()
        {
            if(driver.Url == baseURL + "/group.php"
                && IsElementPresent(By.Name("new")))
            {
                return;
            }

            driver.FindElement(By.LinkText("groups")).Click();
            //driver.FindElement(By.XPath("//a[contains(., 'groups')]")).Click();


        }


        public void GoToHomePage()
        {
            if (driver.Url == baseURL)
            {
                return;
            }
            driver.FindElement(By.XPath("//a[@href = './']")).Click();        
        }

        public void OpenHomePage()
        {
            if (driver.Url == baseURL)
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL);
        }

        public void ReturnToGroupsPage()
        {
            if (driver.Url == baseURL + "/group.php")
            {
                return; 
            }
            driver.FindElement(By.LinkText("group page")).Click();

        }

        

    }
}
