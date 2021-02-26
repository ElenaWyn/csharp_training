using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("", "", "");
            app.Group.CreateGroup(group);
            app.Auth.LogOut();
        }

        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("nowa", "123", "321");

            app.Group.IsThereAnyGroup();

            app.Group.CreateGroup(group);
            app.Auth.LogOut();
        }


    }
}
