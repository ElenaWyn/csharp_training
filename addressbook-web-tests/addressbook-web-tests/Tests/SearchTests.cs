using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace addressbook_web_tests
{
    [TestFixture]
    public class SearchTests : AuthTestBase
    {
        [Test]
        public void TestSearch()
        {
            Console.Out.Write(app.Contact.GetNumberOfResults());
        }

        [Test]
        public void Dane()
        {
            Console.Out.Write(app.Contact.GetInformationFromInfopage(0));
            Console.Out.Write("\r\n");
            ContactData con = app.Contact.GetContactInformationFromEditForm(0);
            Console.Out.Write(app.Contact.AllDataOfContact(con));

        }

        [Test]
        public void TestConnectivity()
        {
            foreach (ContactData con in GroupData.GetAll()[2].GetContacts())
            {
                System.Console.Out.WriteLine(con);
            }
        }




    }


}
