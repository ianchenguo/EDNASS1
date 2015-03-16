using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;
using System.IO;
using System.Timers;
using System.Web;
using System.Xml;
using System.Xml.Linq;

namespace SystemLinQ.xml
{
    class medicineXml
    {
        static void Main()
        {
            XDocument pharmacyDoc = new XDocument
                (
                new XDeclaration("1.0", "utf-8", "yes"),
                new XComment("linQ to XML medicine products"),
                new XElement("medicine",
                    new XElement("pharmacon", new XAttribute("pId", 1),
                        new XElement("name", "medication_1"),
                        new XElement("expiration", "12_Month"),
                        new XElement("price", "10")),
                    new XElement("pharmacon", new XAttribute("pId", 3),
                        new XElement("name", "medication_3"),
                        new XElement("expiration", "24_Month"),
                        new XElement("price", "20")),
                    new XElement("pharmacon", new XAttribute("pId", 5),
                        new XElement("name", "medication_5"),
                        new XElement("expiration", "36_Month"),
                        new XElement("price", "30")),
                    new XElement("pharmacon", new XAttribute("pId", 7),
                        new XElement("name", "medication_7"),
                        new XElement("expiration", "48_Month"),
                        new XElement("price", "40"))
               ));

            //this is save function.
            XmlDocument.Save(@"C:\LASTSemesterCshap\XML\LinQxml\SystemLinQ.xml\firstXml.xml");
            
        }
    }
}
