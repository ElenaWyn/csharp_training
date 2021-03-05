﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;



namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            app.Group.IsThereAnyGroup();

            List<GroupData> oldGroups = app.Group.GetGroupList();

            app.Group.RemoveGroup(0);

            List<GroupData> newGroups = app.Group.GetGroupList();
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);


        }




    }
}
