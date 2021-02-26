using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{

    [TestFixture]
    public class ContactModificateTests : AuthTestBase
    {
        [Test]
        public void ContactModificateTest()
        {
            //Creating contact data to fill
            ContactData newContact = new ContactData("Sidor", "Sidorov");
            newContact.Nickname = "Novichok";
            newContact.Bday = "28";
            newContact.Bmonth = "April";
            newContact.Byear = "1981";
            newContact.Address = "Ajskaja, 123";
            newContact.Notes = "TEST987TEST";

            app.Contact.Modificate(1, newContact);
            app.Navigator.GoToHomePage();
            app.Auth.LogOut();

        }
    }
}
