﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;



namespace addressbook_web_tests
{
    [TestFixture]
    public class CreateNewContact : AuthTestBase
    {

        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();

            string[] listaPol = new[] {"Middlename", "Nickname", "Title", "Address", "Company", "Telhome", "Telwork", "Telmobile",
                "Fax", "Email", "Email2", "Email3", "Homepage", "Address2", "Home", "Notes" };
            
            Random rnd = new Random();

            int howManyFields = rnd.Next(1, listaPol.Length);

            List<int> whatFileds = new List<int>();
            for (int i = 0; i < howManyFields; i++)
            {
                whatFileds.Add(rnd.Next(0, listaPol.Length - 1));
            }

            //Fill variable contacts
            for (int i = 0; i < 5; i++)
            {
                List<string> filledFieldList = new List<string>(); //Fields which we want to fill in contact
                for (int a = 0; a < whatFileds.Count; a++)
                {
                    string pole = listaPol[i];
                    filledFieldList.Add(pole);

                }
                ContactData contact = new ContactData(GenerateRandomString(10), GenerateRandomString(10));

                //filling other fields in contact
                for (int x = 0; x < filledFieldList.Count; x++)
                {
                    filledFieldList[x] = GenerateRandomString(10);
                }

                contacts.Add(contact);


            }
            return contacts;
        }


        


        [Test, TestCaseSource("RandomContactDataProvider")]
        public void CreatingNewContact(ContactData contact)
        {

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
