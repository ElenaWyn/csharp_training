﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace addressbook_web_tests
{

    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {


        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("Mode", "mode", "mode");

            app.Group.IsThereAnyGroup();
            List<GroupData> oldGroups = app.Group.GetGroupList();


            app.Group.GroupModify(0, newData);

            List<GroupData> newGroups = app.Group.GetGroupList();
            oldGroups[0].Groupname = newData.Groupname;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            app.Auth.LogOut();
        }
    }
}
