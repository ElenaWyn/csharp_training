using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading.Tasks;
using System.Threading;

namespace addressbook_web_tests
{
    public class ApplicationManager
    {
        protected LogInHelper loginHelper;
        protected NavigationHelper navigationHelper;
        protected GroupHelper group;
        protected ContactHelper contactHelper;

        protected IWebDriver driver;
        protected string baseURL;
        protected bool acceptNextAlert = true;
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook";

            loginHelper = new LogInHelper(this);
            navigationHelper = new NavigationHelper(this, baseURL);
            group = new GroupHelper(this);
            contactHelper = new ContactHelper(this);
            
        }

         ~ApplicationManager()
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

        public static ApplicationManager GetInstance()
        {
           if (! app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navigator.OpenHomePage();
                app.Value = newInstance;
            }
            return app.Value;
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



    }

}

