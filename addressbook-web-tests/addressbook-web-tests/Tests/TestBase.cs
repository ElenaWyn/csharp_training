using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace addressbook_web_tests
{
    public class TestBase
    {


        protected ApplicationManager app;


       

        [SetUp]
        protected void SetupTest()
        {
            app = new ApplicationManager();
            app.Navigator.OpenHomePage();
            app.Auth.LogIn(new AccountData("admin", "secret"));
        }

        [TearDown]
        protected void TeardownTest()
        {

            app.Stop();
        }
    }
}
