using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XAMPPSiteManager
{
	public partial class FormAddNewSite : Form
	{
		private ApacheVhostsConfigManager _vhostsManager;
		private HostsFileManager _hostsManager;
		private string _XAMPPSiteRoot;
		private string _XAMPPSiteInstallDir;


		public FormAddNewSite(ApacheVhostsConfigManager vhostsParser,
			HostsFileManager hostsParser,
			string XAMPPSiteRootDir,
			string XAMPPSiteInstallDir)
		{
			InitializeComponent();

			_vhostsManager = vhostsParser;
			_hostsManager = hostsParser;
			_XAMPPSiteRoot = XAMPPSiteRootDir;
			_XAMPPSiteInstallDir = XAMPPSiteInstallDir;
		}

		private void buttonAddSite_Click(object sender, EventArgs e)
		{
			CreateSite();
		}

		private void CreateSite()
		{
			string siteName = textBoxNewSiteDomainName.Text;

			if (siteName == "")
			{
				MessageBox.Show(
					this,
					"Site domain name can't be empty",
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Stop);
				return;
			}

			if (_vhostsManager.GetVHostEntries().Count(p => p.ServerName == siteName) > 0)
			{
				MessageBox.Show(
					this,
					"Site with that domain name already exists",
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Stop);
				return;
			}

			try
			{
				string sitePath = Path.Combine(_XAMPPSiteRoot, siteName);

				if (Directory.Exists(sitePath))
				{
					DirectoryInfo dirInfo = new DirectoryInfo(sitePath);

					if (dirInfo.GetFiles().Length > 0 || dirInfo.GetDirectories().Length > 0)
					{
						DialogResult res = MessageBox.Show(
							this,
							string.Format("Directory for {0} site is not empty. Do you want to truncate all its content?", siteName),
							"Confirmation needed",
							MessageBoxButtons.YesNoCancel,
							MessageBoxIcon.Question);

						if (res == DialogResult.Yes)
						{
							Directory.Delete(sitePath, true);
						}
						else if (res == DialogResult.Cancel)
						{
							return;
						}
					}
				}


				_vhostsManager.CreateEntry(siteName);
				_hostsManager.CreateEntry(siteName);
				Directory.CreateDirectory(Path.Combine(_XAMPPSiteRoot, siteName));
				DialogResult dRes = MessageBox.Show(
					this,
					string.Format("Site successfuly created.\r\nApache need to be restarted so new settings to take effect.\r\nPlace your web application files to {0} folder and site will be accessible throu {1} url from the web browser.\r\nDo you want to restart Apache now?",
						Path.Combine(_XAMPPSiteRoot, siteName), siteName),
						"Success", MessageBoxButtons.YesNo,
						MessageBoxIcon.Information);

				if (dRes == DialogResult.Yes)
				{
					try
					{
						ProcessStartInfo startInfo = new ProcessStartInfo();
						startInfo.FileName = Path.Combine(_XAMPPSiteInstallDir, ConfigManager.GetXAMPPApacheStopFilePath());
						startInfo.RedirectStandardOutput = true;
						startInfo.RedirectStandardError = true;
						startInfo.UseShellExecute = false;
						startInfo.CreateNoWindow = true;

						Process processApache = new Process();
						processApache.StartInfo = startInfo;
						processApache.EnableRaisingEvents = true;
						processApache.Start();
						processApache.WaitForExit();

						startInfo.FileName = Path.Combine(_XAMPPSiteInstallDir, ConfigManager.GetXAMPPApacheStartFilePath());
						processApache.Start();
						MessageBox.Show(this,
							"Apache successfuly restarted",
							"Information",
							MessageBoxButtons.OK,
							MessageBoxIcon.Information);
					}
					catch (Exception ex)
					{
						MessageBox.Show(this,
							"Failed to restart Apache\r\nDetails:\r\n" + ex.Message,
							"Error",
							MessageBoxButtons.OK,
							MessageBoxIcon.Error);
							}

				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(this,
					"Failed to register new site\r\nDetails:\r\n" + ex.Message,
					"Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}

			this.Close();
		}

		private void textBoxNewSiteDomainName_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				CreateSite();
			}
		}
	}
}
