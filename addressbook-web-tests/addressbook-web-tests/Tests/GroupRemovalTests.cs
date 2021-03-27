using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;



namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupRemovalTests : GroupsTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            app.Group.IsThereAnyGroup();

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeRemoved = oldGroups[0];


            app.Group.Remove(toBeRemoved);

            List<GroupData> newGroups = GroupData.GetAll();
            
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }

        }




    }
}
