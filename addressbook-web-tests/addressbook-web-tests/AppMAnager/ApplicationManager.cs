using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace addressbook_web_tests
{
    public class ApplicationManager
    {
        protected LogInHelper loginHelper;
        protected NavigationHelper navigationHelper;
        protected GroupHelper group;
        protected ContactHelper contactHelper;

        protected IWebDriver driver = new FirefoxDriver();
        protected string baseURL;
        protected bool acceptNextAlert = true;

        public ApplicationManager()
        {
            loginHelper = new LogInHelper(this);
            navigationHelper = new NavigationHelper(this, "http://localhost/addressbook");
            group = new GroupHelper(this);
            contactHelper = new ContactHelper(this);
            driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook";
        }

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }

        public string BaseURL
        {
            get
            {
                return baseURL;
            }
        }

        public LogInHelper Auth
        {
            get
            {
                return loginHelper;
            }
        }

        public NavigationHelper Navigator
        {
            get
            {
                return navigationHelper;
            }
        }

        public GroupHelper Group
        {
            get
            {
                return group;
            }
        }

        public ContactHelper Contact
        {
            get
            {
                return contactHelper;
            }
        }

        public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

    }

}

