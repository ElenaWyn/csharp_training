using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using TestStack.White;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems;


namespace Addressbook_white
{
    public class ApplicationManager
    {

        public static string WINTITLE = "Free Address Book";
        private GroupHelper groupHelper;
        public Window MainWindow { get; private set; }
        public ApplicationManager()
        {
            groupHelper = new GroupHelper(this);
            Application app = Application.Launch(@"C:\Users\elena\Desktop\FreeAddressBookPortable\AddressBook.exe");
            MainWindow = app.GetWindow(WINTITLE);
        }
        
        public void Stop()
        {
            MainWindow.Get<Button>("uxExitAddressButton").Click();
        }

        public GroupHelper groups
        {
            get
            {
                return groupHelper;
            }
        }
    }


}