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
        private void IsthereanythingInAddressBook()
        {
            app.Group.IsThereAnyGroup();
            app.Contact.IsThereAnyContactsOnList();
        }


        [Test]
        public void TestAddingContactToGroup()
        {
            //check if there are any group or any contact, if no, create new
            IsthereanythingInAddressBook();

            //Choosing group to add contact
            GroupData group = app.Group.ChooseGroupFromList();

            //Choosing contact to add to group, if all the contacts are in group, create new one
            List<ContactData> oldList;
            ContactData contact;
            app.Contact.ChooseContactFromList(group, out oldList, out contact);

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
            //check if there are any group or any contact, if no, create new
            IsthereanythingInAddressBook();

            GroupData group = app.Group.ChooseGroupFromList();
            List<ContactData> oldList = group.GetContacts();
            ContactData contactToDelete = oldList[rnd.Next(0, oldList.Count - 1)];

            if (oldList.Count <= 0)
            {
                app.Contact.AddContactToGroup(group, ContactData.GetAll()[0]);
                contactToDelete = ContactData.GetAll()[0];
                oldList = group.GetContacts();
            }

            app.Contact.DeleteContactFromGroup(group.Groupname, contactToDelete.Id);

            List<ContactData> newList = group.GetContacts();
            oldList.Remove(contactToDelete);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);

        }

        
    }
}
