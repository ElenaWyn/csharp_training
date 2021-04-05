using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Addressbook_white
{
    [TestFixture]
    class GroupDeletingTest : TestBase
    {
        [Test]
        public void GroupDeleTest()
        {
            Random rnd = new Random();
            List<GroupData> oldGroups = app.groups.GetGroupList();
            if (oldGroups.Count <=0)
            {
                app.groups.Add(new GroupData{ Name = "new" });
                oldGroups = app.groups.GetGroupList();
            }

            GroupData groupToDelete = oldGroups[rnd.Next(0, oldGroups.Count)];
            app.groups.DeleteGroup(groupToDelete, "Delete Group");
            List<GroupData> newGroups = app.groups.GetGroupList();
            newGroups.Sort();
            oldGroups.Remove(groupToDelete);
            oldGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);


        }
    }
}
