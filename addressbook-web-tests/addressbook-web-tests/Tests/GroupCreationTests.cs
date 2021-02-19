using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        

        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("test", "test1", "test2");
            app.Group.CreateGroup(group);
            app.Auth.LogOut();
        }

        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("", "", "");
            app.Group.CreateGroup(group);
            app.Auth.LogOut();
        }

       
    }
}
