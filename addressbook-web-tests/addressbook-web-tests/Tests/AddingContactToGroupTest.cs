using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]

    public class AddingContactToGroupTest : AuthTestBase
    {
        new Random rnd = new Random();

        [Test]
        public void TestAddingContactToGroup()
        {
            GroupData group = GroupData.GetAll()[3];
            List<ContactData> oldList = group.GetContacts();
            ContactData contact = ContactData.GetAll().Except(group.GetContacts()).First();

            app.Contact.AddContactToGroup(group, contact);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);
        }

        [Test]
        public void TestDeletingContactFromGroup()
        {
            
            GroupData group = GroupData.GetAll()[app.Group.WhatGroup()];
            List<ContactData> oldList = group.GetContacts();
            if (oldList.Count<=0)
            {
                Assert.Fail("There are no contacts in this group");
            }
            ContactData contactToDelete = oldList[rnd.Next(0, oldList.Count - 1)];

            app.Contact.DeleteContactFromGroup(group.Groupname, contactToDelete.Id);

            List<ContactData> newList = group.GetContacts();
            oldList.Remove(contactToDelete);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);

        }

    }
}
