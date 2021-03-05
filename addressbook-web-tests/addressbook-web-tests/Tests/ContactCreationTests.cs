using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;


namespace addressbook_web_tests
{
    [TestFixture]
    public class CreateNewContact : AuthTestBase
    {
       

        [Test]
        public void CreatingNewContact()
        {
            
            //Creating contact data to fill
            ContactData contact = new ContactData("Sidor", "Sidorov");
            contact.Nickname = "Chuvak";
            contact.Bday = "2";
            contact.Bmonth = "March";
            contact.Byear = "1981";
            contact.Address = "Revolucii, 123";
            contact.Notes = "TEST132TEST";

            List<ContactData> oldContacts = app.Contact.GetContactList();

            app.Contact.Create(contact);
            app.Navigator.GoToHomePage();

            List<ContactData> newContacts = app.Contact.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(newContacts, oldContacts);


            app.Auth.LogOut();
        }

        
        

        


       
    }
}
