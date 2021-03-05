using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;


namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("", "", "");
            app.Group.IsThereAnyGroup();
            List<GroupData> oldGroups = app.Group.GetGroupList();
           

            app.Group.CreateGroup(group);

            List<GroupData> newGroups = app.Group.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            app.Auth.LogOut();
        }

        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("nowa", "123", "321");

            app.Group.IsThereAnyGroup();
            List<GroupData> oldGroups = app.Group.GetGroupList();

            app.Group.CreateGroup(group);

            List<GroupData> newGroups = app.Group.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            app.Auth.LogOut();
        }


    }
}
