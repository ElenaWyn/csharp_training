﻿using System;
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
            
            OpenHomePage();
            LogIn(new AccountData("admin", "secret"));
            GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(new GroupData("test", "test1", "test2"));
            SubmitGroupCreation();
            ReturnToGroupsPage();
            LogOut();
        }

       
    }
}
