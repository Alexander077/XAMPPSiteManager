using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

namespace XAMPPSiteManager
{
	class ConfigManager
	{
		private const string ConfigFileName = "config.xml";

		public static string GetVHostsParseRegex()
		{
			XDocument configXML = XDocument.Load(ConfigFileName);
			return configXML.XPathSelectElement("//vHostsParseRegex").Value;
		}

		public static string GetHostsParseRegex()
		{
			XDocument configXML = XDocument.Load(ConfigFileName);
			return configXML.XPathSelectElement("//hostsParseRegex").Value;
		}

		public static string GetVHostsEntryTemplate()
		{
			XDocument configXML = XDocument.Load(ConfigFileName);
			return configXML.XPathSelectElement("//newVHostsEntryTemplate").Value;
		}

		public static string GetHostsEntryTemplate()
		{
			XDocument configXML = XDocument.Load(ConfigFileName);
			return configXML.XPathSelectElement("//newHostsEntryTemplate").Value;
		}

		public static string GetXAMPPInstallDir()
		{
			XDocument configXML = XDocument.Load(ConfigFileName);
			return configXML.XPathSelectElement("//XAMPPInstallDir").Value;
		}

		public static void SetXAMPPInstallDir(string XAMPPinstallDir)
		{
			XDocument configXML = XDocument.Load(ConfigFileName);
			configXML.XPathSelectElement("//XAMPPInstallDir").Value = XAMPPinstallDir;
			string xml = configXML.ToString();
			configXML.Save(ConfigFileName);
		}


		public static string GetXAMPPApacheStopFilePath()
		{
			XDocument configXML = XDocument.Load(ConfigFileName);
			return configXML.XPathSelectElement("//XAMPPApacheStopFilePath").Value;
		}

		public static string GetXAMPPApacheStartFilePath()
		{
			XDocument configXML = XDocument.Load(ConfigFileName);
			return configXML.XPathSelectElement("//XAMPPApacheStartFilePath").Value;
		}

	}
}
