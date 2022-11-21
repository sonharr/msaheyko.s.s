using System;
using System.Collections.Generic;
using System.Xml;

namespace HelloApp
{
    class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Company { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<User> users = new List<User>();
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@"D:\Документы\users.xml");
            XmlElement xRoot = xDoc.DocumentElement;

            XmlElement userElem = xDoc.CreateElement("user");  
            XmlAttribute nameAttr = xDoc.CreateAttribute("name");  
            XmlElement companyElem = xDoc.CreateElement("company");  
            XmlElement ageElem = xDoc.CreateElement("age");  

            Console.WriteLine("Введите имя:");
            string file1 = Console.ReadLine();
            XmlText nameText = xDoc.CreateTextNode(file1);

            Console.WriteLine();
            Console.WriteLine("Введите компанию:");
            string file2 = Console.ReadLine();
            XmlText companyText = xDoc.CreateTextNode(file2);

            Console.WriteLine();
            Console.WriteLine("Введите возраст:");
            string file3 = Console.ReadLine();
            XmlText ageText = xDoc.CreateTextNode(file3);

            nameAttr.AppendChild(nameText);
            companyElem.AppendChild(companyText);
            ageElem.AppendChild(ageText);
            userElem.Attributes.Append(nameAttr);
            userElem.AppendChild(companyElem);
            userElem.AppendChild(ageElem);
            xRoot.AppendChild(userElem);
            xDoc.Save(@"D:\Документы\users.xml");
            Console.WriteLine();
            foreach (XmlElement xnode in xRoot)
            {
                User user = new User();
                XmlNode attr = xnode.Attributes.GetNamedItem("name");
                if (attr != null)
                    user.Name = attr.Value;

                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    if (childnode.Name == "company")
                        user.Company = childnode.InnerText;

                    if (childnode.Name == "age")
                        user.Age = Int32.Parse(childnode.InnerText);
                }
                users.Add(user);
            }
            foreach (User u in users)
                Console.WriteLine($"{u.Name} ({u.Company}) - {u.Age}");

            string path1 = @"D:\Документы\users.xml";
            FileInfo fileInf = new FileInfo(path1);
            Console.WriteLine("После нажатия ENTER файл будет удалён:");
            string enter = Console.ReadLine();
            if (enter == "")
                if (fileInf.Exists)
                {
                    fileInf.Delete();
                }
        }
    }
}