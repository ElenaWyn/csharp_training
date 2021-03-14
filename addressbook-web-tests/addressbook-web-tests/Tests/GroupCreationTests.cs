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

   
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++ )
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {

                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });
                

            }
            return groups;
        }

        
        [Test, TestCaseSource("RandomGroupDataProvider")]
        public void GroupCreationTest(GroupData group)
        {
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
