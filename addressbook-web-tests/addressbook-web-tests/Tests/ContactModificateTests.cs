using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;


namespace addressbook_web_tests
{

    [TestFixture]
    public class ContactModificateTests : ContactTestBase
    {
        [Test]
        public void ContactModificateTest()
        {
            //Creating contact data to fill
            ContactData newContact = ContactHelper.GenrateRandomContactData();

            app.Contact.IsThereAnyContactsOnList();
            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData oldContact = oldContacts[1];

            app.Contact.Modificate(oldContact, newContact);
            app.Navigator.GoToHomePage();

            List<ContactData> newContacts = ContactData.GetAll();
            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == oldContact.Id)
                {
                    Assert.AreEqual(newContact.Firstname, contact.Firstname);
                    Assert.AreEqual(newContact.Lastname, contact.Lastname);
                }
            }

            app.Auth.LogOut();

        }

       
    }
}
