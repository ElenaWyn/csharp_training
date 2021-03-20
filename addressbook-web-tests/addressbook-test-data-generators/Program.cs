using System;
using addressbook_web_tests;
using System.IO;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel =  Microsoft.Office.Interop.Excel;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]);
            string format = args[2];
            string filename = args[1];
            string typeOfData = args[3];
            List<GroupData> groups = new List<GroupData>();
            List<ContactData> contacts = new List<ContactData>();
            StreamWriter writer = new StreamWriter(filename);


            if (typeOfData == "group")
            {
                for (int i = 0; i < count; i++)
                {
                    groups.Add(new GroupData(TestBase.GenerateRandomString(10),
                        TestBase.GenerateRandomString(10),
                        TestBase.GenerateRandomString(10)));
                }

                switch (format)
                {
                    case "excel":
                        writeGroupsToExcelFile(groups, filename);
                        break;
                    case "csv" :
                           writeGroupsToCSVFile(groups, writer);
                        break;
                    case "xml":
                        writeGroupsToXMLFile(groups, writer);
                        break;
                    case "json":
                        writeGroupsToJsonFile(groups, writer);
                        break;
                    default:
                        System.Console.Out.Write("Unrecognized format " + format);
                        break;
                }
            } else if (typeOfData == "contact")
            {
                for (int c = 0; c < count; c++)
                {
                    contacts.Add(ContactHelper.GenrateRandomContactData());
                }

                switch (format)
                {
                    case "xml":
                        writeContactsToXMLFile(contacts, writer);
                        break;
                    case "json":
                        writeContactsToJsonFile(contacts, writer);
                        break;
                    default:
                        System.Console.Out.Write("Unrecognized format " + format);
                        break;
                }

            }
            else
            {
                System.Console.Out.Write("Unrecognized type of data " + typeOfData);

            }

                writer.Close();
            

        }

        public static void writeContactsToJsonFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }

        public static void writeContactsToXMLFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }

        static void writeGroupsToExcelFile(List<GroupData> groups, string filename)
        {
            Excel.Application app = new Excel.Application();
            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet sheet = (Excel.Worksheet)wb.ActiveSheet;

            int row = 1;
            foreach (GroupData group in groups)
            {
                sheet.Cells[row, 1] = group.Groupname;
                sheet.Cells[row, 2] = group.Header;
                sheet.Cells[row, 3] = group.Footer;
                row++;
            }
            string fullpath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            File.Delete(fullpath);
            wb.SaveAs(fullpath);

            wb.Close();
            app.Quit();

        }

        static void writeGroupsToCSVFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach(GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0}, ${1}, ${2}",
                    group.Groupname, group.Header, group.Footer)); 
            }
        }

        static void writeGroupsToXMLFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        static void writeGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }

       



    }
}
