namespace XAMPPSiteManager
{
	public class VhostsEntry
	{
		public string ServerAdmin { get; set; }
		public string DocumentRoot { get; set; }
		public string ServerName { get; set; }
		public string ErrorLog { get; set; }
		public string CustomLog { get; set; }
		public int Index { get; set; }
		public int Length { get; set; }
		public string MatchStr { get; set; }

		public VhostsEntry(
			string serverAdmin, 
			string documentRoot, 
			string serverName, 
			string errorLog, 
			string customLog)
		{
			ServerAdmin = serverAdmin;
			DocumentRoot = documentRoot;
			ServerName = serverName;
			ErrorLog = errorLog;
			CustomLog = customLog;
		}
	}
}