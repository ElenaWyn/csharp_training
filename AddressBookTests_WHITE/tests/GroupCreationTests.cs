using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Addressbook_white
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void TestGroupCreation()
        {
            List<GroupData> oldGroups = app.groups.GetGroupList();

            GroupData newGroup = new GroupData()
            {
                Name = "new group"
            };
            app.groups.Add(newGroup);
            List<GroupData> newGroups = app.groups.GetGroupList();
            oldGroups.Add(newGroup);
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
