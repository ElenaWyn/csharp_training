using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


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

            app.Contact.Create(contact);
            app.Navigator.GoToHomePage();
            app.Auth.LogOut();
        }

        
        

        


       
    }
}
