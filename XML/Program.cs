using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace XML
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("..\\..\\test.xml");
            XmlNode root = doc.FirstChild;
            string get_text = root.Attributes["data"].Value;

            XmlNode iterator = root.FirstChild;
            get_text = iterator.Attributes["data"].Value;

            iterator = iterator.NextSibling;
            get_text = iterator.Attributes["data"].Value;

            iterator = iterator.NextSibling;
            get_text = iterator.Attributes["data"].Value;

            iterator = iterator.FirstChild;
            get_text = iterator.Attributes["data"].Value;
        }
    }
}
