using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        

        [Test]
        public void GroupRemovalTest()
        {
            OpenHomePage();
            LogIn(new AccountData("admin", "secret"));
            GoToGroupsPage();
            ChooseGroup(1);
            DeleteGroup();
            ReturnToGroupsPage();
        }

       

        
    }
}
