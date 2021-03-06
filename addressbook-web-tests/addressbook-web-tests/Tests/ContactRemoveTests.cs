using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactRemoveTests : AuthTestBase
    {
        [Test]
        public void ContactRemoveTest()
        {

            app.Contact.IsThereAnyContactsOnList();

            List<ContactData> oldContacts = app.Contact.GetContactList();
            ContactData toBeRemoved = oldContacts[1];

            app.Contact.CheckContact(1);
            app.Contact.DeleteContact();
            System.Threading.Thread.Sleep(2000);

            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts.RemoveAt(1);

            Assert.AreEqual(oldContacts, newContacts);
            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }

            app.Navigator.GoToHomePage();
        }

       


    }
}
