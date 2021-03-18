using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactInformationTest : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            ContactData fromTable =  app.Contact.GetContactInformationFromTable(2);
            ContactData fromForm = app.Contact.GetContactInformationFromEditForm(2);

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllMails, fromForm.AllMails);

        }

        [Test]
        public void ContactDetailInformationTest()
        {
            string detailData = app.Contact.GetInformationFromInfopage(1);
            string contactData = app.Contact.AllDataOfContact(app.Contact.GetContactInformationFromEditForm(1));
            Console.Out.Write("Assertion Date:" + "\r\n" + "Detailed Data\r\n" + detailData + "\r\n" + "Contact Data\r\n" + contactData);
            Assert.AreEqual(detailData, contactData);
        }
    }
}
