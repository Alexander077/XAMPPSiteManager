using System.Net;

namespace XAMPPSiteManager
{
	public class HostsEntry
	{
		public string DomainName { get; set; }
		public string IpAddress { get; set; }
		public bool Enabled { get; set; }
		public int Index { get; set; }
		public int Length { get; set; }

		public HostsEntry(string domainName, string ipAddress, bool enabled)
		{
			DomainName = domainName;
			IpAddress = ipAddress;
			Enabled = enabled;
		}
	}
}