using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace addressbook_web_tests
{
    [TestFixture]
    public class CreateNewContact : TestBase
    {
       

        [Test]
        public void CreatingNewContact()
        {
            
            //Creating contact data to fill
            ContactData contact = new ContactData("Piotr", "Petrov");
            contact.Nickname = "Bratan";
            contact.Bday = "2";
            contact.Bmonth = "March";
            contact.Byear = "1981";
            contact.Address = "Lenina, 123";
            contact.Notes = "Test Completed";

            app.Contact.Create(contact);
            app.Navigator.GoToHomePage();
            app.Auth.LogOut();
        }

        
        

        


       
    }
}
