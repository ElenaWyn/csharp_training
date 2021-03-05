using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }


        public ContactHelper Create(ContactData contact)
        {
            AddNewContact();
            FillContactData(contact);
            SubmitContact();
            return this;
        }

        public ContactHelper SubmitContact()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            return this;
        }

        public List<ContactData> GetContactList()
        {
            List<ContactData> contacts = new List<ContactData>();
            manager.Navigator.GoToHomePage();
            ICollection<IWebElement> elements = driver.FindElements(By.XPath("//tr[@name = 'entry']"));
            foreach (IWebElement element in elements)
            {
                string name = element.FindElement(By.XPath("//td[3]")).Text;
                string surname = element.FindElement(By.XPath("//td[2]")).Text;
                contacts.Add(new ContactData(name, surname));
            }

            return contacts;
        }

        public ContactHelper Modificate(int v, ContactData newContact)
        {
            InitContactModification(v);
            FillContactData(newContact);
            SubmitContactModification();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();

            return this;
        }

        public ContactHelper InitContactModification(int v)
        {
            CheckContact(v);
            int input = v + 1;
            driver.FindElement(By.XPath("//tr[" + input + "]//img[@title = 'Edit']")).Click();
            return this;

        }

        public ContactHelper CheckContact(int v)
        {
            int input = v + 1;
            driver.FindElement(By.XPath("//tr[" + input + "]//input[@type = 'checkbox']")).Click();
            return this;
        }

        public ContactHelper FillContactData(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);
            driver.FindElement(By.Name("nickname")).Clear();
            driver.FindElement(By.Name("nickname")).SendKeys(contact.Nickname);
            driver.FindElement(By.Name("address")).Clear();
            driver.FindElement(By.Name("address")).SendKeys(contact.Address);
            driver.FindElement(By.Name("bday")).Click();
            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(contact.Bday);
            driver.FindElement(By.Name("bday")).Click();
            driver.FindElement(By.Name("bmonth")).Click();
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(contact.Bmonth);
            driver.FindElement(By.Name("bmonth")).Click();
            driver.FindElement(By.Name("byear")).Click();
            driver.FindElement(By.Name("byear")).Clear();
            driver.FindElement(By.Name("byear")).SendKeys(contact.Byear);
            driver.FindElement(By.Name("notes")).Clear();
            driver.FindElement(By.Name("notes")).SendKeys(contact.Notes);
            return this;
        }

       
        public ContactHelper AddNewContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper PushDeleteContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }

        public ContactHelper DeleteContact()
        {
            PushDeleteContact();    
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper IsThereAnyContactsOnList()
        {
            manager.Navigator.GoToHomePage();
            if (! IsElementPresent(By.XPath("//tr//img[@title = 'Edit']")))
            {
                Create(new ContactData("Ivan", "Ivanov"));
                return this;
            }
            return this;
        }


    }
}
