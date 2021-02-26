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
            app.Contact.CheckContact(1);
            app.Contact.DeleteContact();
            app.Navigator.GoToHomePage();
        }

       


    }
}
