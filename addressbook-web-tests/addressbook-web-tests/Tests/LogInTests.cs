using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace addressbook_web_tests
{
   [TestFixture]
    public class LogInTests : TestBase
    {
        [Test]
        public void LogInWithValidCredentials()
        {
            app.Auth.LogOut();

            AccountData trueUser = new AccountData("admin", "secret");
            app.Auth.LogIn(trueUser);

            Assert.IsTrue(app.Auth.IsLoggedIn(trueUser));
        }

        [Test]
        public void LogInWithInvalidCredentials()
        {
            app.Auth.LogOut();

            AccountData trueUser = new AccountData("admin", "password");
            app.Auth.LogIn(trueUser);

            Assert.IsFalse(app.Auth.IsLoggedIn(trueUser));
        }
    }
}
