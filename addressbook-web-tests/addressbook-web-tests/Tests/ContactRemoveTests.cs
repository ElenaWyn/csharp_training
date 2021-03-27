using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactRemoveTests : ContactTestBase
    {
        [Test]
        public void ContactRemoveTest()
        {

            app.Contact.IsThereAnyContactsOnList();

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData toBeRemoved = oldContacts[1];

            app.Contact.CheckContact(toBeRemoved.Id);
            app.Contact.DeleteContact();
            System.Threading.Thread.Sleep(2000);

            List<ContactData> newContacts = ContactData.GetAll();
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
