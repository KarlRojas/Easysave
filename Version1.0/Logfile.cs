using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace ProjectEasysafe
{
	public class Logfile
	{
		public double fileSize { get; set; }
		public double fileTransferTime { get; set; }
		public String Time { get; set; }
        
        public void createJsonFile()
        {
            Logfile json = new Logfile()
            {
                fileSize = 1,
                fileTransferTime = 300,
                Time = DateTime.Now.ToString("dd/MM/yyyy HH:mm")
            };

            String JsonResult = JsonConvert.SerializeObject(json, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(@"logfile.json", JsonResult);
            Console.WriteLine("Log has been created successfully !");

            JsonResult = String.Empty;
            JsonResult = File.ReadAllText(@"logfile.json");
            Logfile resultLog = JsonConvert.DeserializeObject<Logfile>(JsonResult);
        } 

        public void createXmlFile()
        {
            
            {

                XmlDocument xmlDoc = new XmlDocument();
                XmlNode rootNode = xmlDoc.CreateElement("logfile");
                xmlDoc.AppendChild(rootNode);

                XmlNode userNode = xmlDoc.CreateElement("fileSize");
                userNode.InnerText = "1.0";
                rootNode.AppendChild(userNode);

                userNode = xmlDoc.CreateElement("fileTransferTime");
                userNode.InnerText = "300.0";
                rootNode.AppendChild(userNode);

                userNode = xmlDoc.CreateElement("Time");
                userNode.InnerText = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                rootNode.AppendChild(userNode);

                xmlDoc.Save("xmllogfile.xml");
            }
            Console.WriteLine("Log has been created successfully !");

            
        }
	}

}
