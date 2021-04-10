using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading.Tasks;
using System.Threading;

namespace mantis_tests
{
    public class ApplicationManager
    {
        
        protected HelperBase help;

        protected IWebDriver driver;
        protected string baseURL;
        protected bool acceptNextAlert = true;
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();
        public RegistrationHelper Reg;
        public FtpHelper Ftp;

        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = "https://localhost/mantisbt-2.25.0/login_page.php";
            Reg = new RegistrationHelper(this);
            Ftp = new FtpHelper(this);
            
            
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
                newInstance.driver.Url = "https://localhost/mantisbt-2.25.0/login_page.php";
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

        



    }

}

