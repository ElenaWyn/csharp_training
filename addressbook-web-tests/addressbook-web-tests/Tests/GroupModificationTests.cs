using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace addressbook_web_tests
{

    [TestFixture]
    public class GroupModificationTests : GroupsTestBase
    {


        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("Mode", "mode", "mode");

            app.Group.IsThereAnyGroup();
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeModificated = oldGroups[0];

            app.Group.GroupModify(toBeModificated, newData);

            List<GroupData> newGroups = GroupData.GetAll();

            toBeModificated.Groupname = newData.Groupname;
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if(group.Id == toBeModificated.Id)
                {
                    Assert.AreEqual(newData.Groupname, group.Groupname);
                }
            }

            app.Auth.LogOut();
        }
    }
}
