using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;

namespace addressbook_web_tests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = TakeCellsOfIndex(index);

            string firstName = cells[2].Text;
            string lastName = cells[1].Text;
            string addres = cells[3].Text;

            string allPhones = cells[5].Text;

            string allMails = cells[4].Text;

            return new ContactData(firstName, lastName)
            {
                Address = addres,
                AllPhones = allPhones,
                AllMails = allMails
            };





        }

        private IList<IWebElement> TakeCellsOfIndex(int index)
        {
            return driver.FindElements(By.Name("entry"))[index].
                            FindElements(By.TagName("td"));
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string middlename = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string nickname = driver.FindElement(By.Name("nickname")).GetAttribute("value");

            string company = driver.FindElement(By.Name("company")).GetAttribute("value");
            string title = driver.FindElement(By.Name("title")).GetAttribute("value");

            string addres = driver.FindElement(By.Name("address")).Text;
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string fax = driver.FindElement(By.Name("fax")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            string homePage = driver.FindElement(By.Name("homepage")).GetAttribute("value");

            string bday = driver.FindElement(By.Name("bday")).
                FindElement(By.XPath("./option[@selected = 'selected']")).Text;
            //string bmonth =  driver.FindElement(By.Name("bmonth")).
            //FindElement(By.XPath("//option[@selected = 'selected']")).Text;
            string bmonth = driver.FindElement(By.Name("bmonth")).
                FindElement(By.XPath("./option[@selected = 'selected']")).GetAttribute("value");
            string byear = driver.FindElement(By.Name("byear")).GetAttribute("value");

            string aday = driver.FindElement(By.Name("aday")).
                FindElement(By.XPath("./option[@selected = 'selected']")).Text;
            string amonth = driver.FindElement(By.Name("amonth")).
                FindElement(By.XPath("./option[@selected = 'selected']")).Text;
            string ayear = driver.FindElement(By.Name("ayear")).GetAttribute("value");

            string address2 = driver.FindElement(By.Name("address2")).Text;
            string notes = driver.FindElement(By.Name("notes")).Text;
            string extraPhone = driver.FindElement(By.Name("phone2")).GetAttribute("value");




            return new ContactData(firstName, lastName)
            {
                Middlename = middlename,
                Address = addres,
                Telhome = homePhone,
                Telwork = workPhone,
                Telmobile = mobilePhone,
                Email = email,
                Email2 = email2,
                Email3 = email3,
                Nickname = nickname,
                Company = company,
                Title = title,
                Address2 = address2,
                Fax = fax,
                Homepage = homePage,
                Bday = bday,
                Bmonth = bmonth,
                Byear = byear,
                Aday = aday,
                Amonth = amonth,
                Ayear = ayear,
                Home  = extraPhone,
                Notes = notes
            };
            
        }

        public string GetInformationFromInfopage(int index)
        {
            manager.Navigator.GoToHomePage();
            SeeContactInfo(index);
            return driver.FindElement(By.XPath("//div[@id = 'content']")).Text;
        }

        public string AllDataOfContact(ContactData contact)
        {
            string telhome = null;
            string telmobile = null;
            string telwork = null;
            string fax = null;
            string homepage = null;
            string home = null;

            string birthday = null;
            string anniversary = null;
            if (contact.Bday != "-" || contact.Bmonth != "-" || contact.Byear != null)
            {
                string day = null;
                string month = null;
                string dday;
                string mmonth;
                string year = null;

                if (contact.Bday != "-")
                {
                    day = contact.Bday + ". ";
                    dday = contact.Bday;
                }
                else
                {
                    day = "";
                    dday = "1";
                }
                if (contact.Bmonth != "-")
                {
                    month = contact.Bmonth;
                    mmonth = contact.Bmonth;
                }
                else
                {

                    month = "";
                    mmonth = "January";
                }

                if (contact.Byear != null)
                {
                    DateTime bDate = DateTime.Parse(dday + "." + mmonth + "." + contact.Byear);
                    year = contact.Byear + " " + "(" + CountAge(bDate) + ")";
                }

                birthday = "Birthday " + day + month + " " + year + "\r\n";
            }
            if (contact.Aday != "-" || contact.Amonth != "-" || contact.Ayear != null)
            {

                string day = null;
                string dday;
                string month = null;
                string mmonth;
                string year = null;

                if (contact.Aday != "-")
                {
                    day = contact.Aday + ". ";
                    dday = contact.Aday;

                }
                else
                {

                    day = "";
                    dday = "1";
                }

                if (contact.Amonth != "-")
                {
                    month = contact.Amonth + " ";
                    mmonth = contact.Amonth;
                }
                else
                {
                    month = "";
                    mmonth = "January";
                }
                if (contact.Ayear != null)
                {
                    DateTime aDate = DateTime.Parse(dday + "." + mmonth + "." + contact.Ayear);
                    year = contact.Ayear + " " + "(" + CountAge(aDate) + ")";
                }
                anniversary = "Anniversary " + day + month + year + "\r\n";
            }

            string middlename = null;
            if (contact.Middlename != "")
            {
                middlename = " " + contact.Middlename;
            }
            if (contact.Telhome !="")
            {
                telhome = "H: " + CutField(contact.Telhome);
            }
            if (contact.Telmobile != "")
            {
                telmobile = "M: " + CutField(contact.Telmobile);
            }
            if (contact.Telwork != "")
            {
                telwork = "W: " + CutField(contact.Telwork);
            }
            if (contact.Fax != "")
            {
                fax = "F: " + CutField(contact.Fax);
            }
            if (contact.Homepage != "")
            {
                homepage = "Homepage:\r\n" + CutField(contact.Homepage);
            }
            if (contact.Home != "")
            {
                home = "P: " + CutField(contact.Home);
            }
            string tels = "";
            if (telhome != null || telmobile != null || telwork != null || fax != null)
            {
                tels = "\r\n" + telhome + telmobile + telwork + fax;
            }
            string mails = "";
            if (CutField(contact.Email) != null || CutField(contact.Email2) != null || CutField(contact.Email3) != null || homepage != null)
            {
                mails = "\r\n" + CutField(contact.Email) + CutField(contact.Email2) + CutField(contact.Email3) + homepage;
            }
            string dates = "";
            if (birthday != null || anniversary != null)
            {
                dates = "\r\n" + birthday + anniversary;
            }
            string address2 = "";
            if (CutField(contact.Address2) != null)
            {
                address2 = "\r\n" + CutField(contact.Address2);
            }
            string secondPhone = "";
            if (home != null)
            {
                secondPhone = "\r\n" + home;
            }
            string notes = "";
            if(contact.Notes != "")
            {
                notes = "\r\n" + contact.Notes;
            }



            return contact.Firstname + middlename + " " + CutField(contact.Lastname)
                + CutField(contact.Nickname) +
                CutField(contact.Title) +
                CutField(contact.Company) +
                CutField(contact.Address) +
                tels + mails
                + dates + address2
                + secondPhone + notes;
        }

        public string CutField (string field)
        {
            if (field == "")
            {
                return null;
            }
            else
            {
                return field + "\r\n";
            }
        }
        public string CountAge(DateTime dateOfBirth)
        { 
            DateTime dateNow = DateTime.Now;
            int year = dateNow.Year - dateOfBirth.Year;
            if (dateNow.Month < dateOfBirth.Month ||
                (dateNow.Month == dateOfBirth.Month && dateNow.Day < dateOfBirth.Day)) year--;
            return year.ToString();
        }

        public void SeeContactInfo(int index)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells =  TakeCellsOfIndex(index);
            cells[6].Click();
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
            contactCache = null;
            return this;
        }

        private List<ContactData> contactCache = null;
        
        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.GoToHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.XPath("//tr[@name = 'entry']"));
                foreach (IWebElement element in elements)
                {
                    string name = element.FindElement(By.XPath(".//td[3]")).Text;
                    string surname = element.FindElement(By.XPath(".//td[2]")).Text;
                    contactCache.Add(new ContactData(name, surname)
                        {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("id")
                    });
                }
            }
            return new List<ContactData>(contactCache);
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
            contactCache = null;
            return this;
        }

        public ContactHelper InitContactModification(int v)
        {
            CheckContact(v);
            //driver.FindElement(By.XPath("//tr[" + (v+2) + "]//img[@title = 'Edit']")).Click();
            driver.FindElements(By.Name("entry"))[v].
                FindElements(By.TagName("td"))[7].
                FindElement(By.TagName("a")).Click();
            return this;

        }

        public ContactHelper CheckContact(int v)
        {
            driver.FindElement(By.XPath("//tr[" + (v+2) + "]//input[@type = 'checkbox']")).Click();
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
            contactCache = null;
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

        public int GetNumberOfResults()
        {
            manager.Navigator.GoToHomePage();
            /*string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);*/
            return Int32.Parse(driver.FindElement(By.XPath("//*[@id=\"search_count\"]")).Text);
        }


    }
}
