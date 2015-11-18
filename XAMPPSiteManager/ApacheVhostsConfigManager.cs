using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace XAMPPSiteManager
{
	public class ApacheVhostsConfigManager
	{
		private string _configFilePath;
		private string _XAMPPWebRootDir;

		public ApacheVhostsConfigManager(string apacheVhostsConfigFilePath, string XAMPPWebRootDir)
		{
			_configFilePath = apacheVhostsConfigFilePath;
			_XAMPPWebRootDir = XAMPPWebRootDir;
		}

		public List<VhostsEntry> GetVHostEntries()
		{
			string fileComtents = File.ReadAllText(_configFilePath);
			MatchCollection vhostsMatches = Regex.Matches(fileComtents,
				ConfigManager.GetVHostsParseRegex(), RegexOptions.IgnoreCase | RegexOptions.Singleline);

			List<VhostsEntry> vhostsEntries = new List<VhostsEntry>(10);

			foreach (Match match in vhostsMatches)
			{
				vhostsEntries.Add(new VhostsEntry
					(
						match.Groups["serverAdmin"].Value,
						match.Groups["documentRoot"].Value,
						match.Groups["serverName"].Value,
						match.Groups["errorLog"].Value,
						match.Groups["customLog"].Value
					){Index = match.Index,
					Length = match.Length,
					  MatchStr = match.Value});
			}

			return vhostsEntries;
		}

		public void CreateEntry(string domainName)
		{
			string newEntry = ConfigManager.GetVHostsEntryTemplate().
				Replace("{domainName}", domainName).
				Replace("{XAMPPInstallDir}", _XAMPPWebRootDir).Replace("\n","\r\n");

			File.WriteAllText(_configFilePath, File.ReadAllText(_configFilePath) + newEntry);
		}

		public void DeleteEntry(string domainName)
		{
			VhostsEntry entryToDelete = GetVHostEntries().Single(p => p.ServerName == domainName);
			string configFileStr = File.ReadAllText(_configFilePath);
			File.WriteAllText(_configFilePath,configFileStr.Remove(entryToDelete.Index, entryToDelete.Length));
		}
	}
}
