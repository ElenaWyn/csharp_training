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
        public LogInHelper Login;
        //public FtpHelper Ftp;
        public ProjectManagmentHelper Proj;
        public APIHelper APIHelper { get; private set; }



        /*
        FirefoxOptions op = new FirefoxOptions
        {
            AcceptInsecureCertificates = true
        };*/








        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/mantisbt-1.3.20/login_page.php";
            Reg = new RegistrationHelper(this);
            //Ftp = new FtpHelper(this);
            Login = new LogInHelper(this);
            Proj = new ProjectManagmentHelper(this);
            APIHelper = new APIHelper(this);


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
                newInstance.driver.Url = "http://localhost/mantisbt-1.3.20/login_page.php";
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

