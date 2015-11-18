using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace XAMPPSiteManager
{
	public class HostsFileManager
	{
		string _hostsFilePath;

		public HostsFileManager()
		{
			_hostsFilePath = Path.Combine(Environment.ExpandEnvironmentVariables("%WINDIR%"), @"SYSTEM32\drivers\etc\hosts");
		}

		public List<HostsEntry> GetHostsEntries()
		{
			string hostsFileContents = FileUtil.ReadText(_hostsFilePath,Encoding.UTF8);

			MatchCollection hostEntriesMatches =
				Regex.Matches(hostsFileContents, ConfigManager.GetHostsParseRegex(), RegexOptions.IgnoreCase | RegexOptions.Multiline);

			List<HostsEntry> res = new List<HostsEntry>(1000);

			foreach (Match match in hostEntriesMatches)
			{
				res.Add(new HostsEntry(
					match.Groups["domainName"].Value,
					match.Groups["ip"].Value,
					match.Groups["disabled"].Value == ""
					){Index = match.Index,
					Length = match.Length});
			}

			return res;
		}

		public void CreateEntry(string domainName)
		{
			string newEntry = ConfigManager.GetHostsEntryTemplate().
				Replace("{domainName}", domainName).Replace("\n","\r\n");

			FileUtil.AppendBytes(_hostsFilePath, new UTF8Encoding().GetBytes(newEntry));
		}


		public string GetHostsFilePath()
		{
			return _hostsFilePath;
		}

		public void DeleteEntry(string domainName)
		{
			HostsEntry entryToDelete = GetHostsEntries().Single(p => p.DomainName == domainName);
			string hostsFileContents = FileUtil.ReadText(_hostsFilePath, Encoding.UTF8);
			string res = hostsFileContents.Remove(entryToDelete.Index, entryToDelete.Length);
			FileUtil.WriteText(_hostsFilePath,
				res,
				Encoding.UTF8);
		}

	}
}
