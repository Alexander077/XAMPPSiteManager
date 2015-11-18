using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XAMPPSiteManager
{
	public partial class FormMain : Form
	{
		string _XAMPPInstallDir;
		string _XAMPPWebRootPath;
		string _XAMPPApacheVhostsConfigFile;
		private ApacheVhostsConfigManager _vhostsManager;
		private HostsFileManager _hostsManager = new HostsFileManager();


		public FormMain()
		{
			InitializeComponent();
		}

		private void FormMain_Shown(object sender, EventArgs e)
		{
			BuildExistingSiteList();
		}

		public void BuildExistingSiteList()
		{
			listViewSites.Items.Clear();
			_XAMPPInstallDir = ConfigManager.GetXAMPPInstallDir();
			_XAMPPWebRootPath = Path.Combine(_XAMPPInstallDir, "htdocs");
			_XAMPPApacheVhostsConfigFile = Path.Combine(_XAMPPInstallDir, "apache\\conf\\extra\\httpd-vhosts.conf");

			if (_XAMPPInstallDir != "" &&
				!Directory.Exists(_XAMPPInstallDir))
			{
				MessageBox.Show(this, "Provided XAMMP install dir is not exists", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			else
			{
				if (!Directory.Exists(_XAMPPWebRootPath))
				{
					MessageBox.Show(this, "Can't find XAMPP web root dir", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				if (!File.Exists(_XAMPPApacheVhostsConfigFile))
				{
					MessageBox.Show(this, "Can't find XAMPP Apache virtual hosts config file", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
			}

			_vhostsManager = new ApacheVhostsConfigManager(_XAMPPApacheVhostsConfigFile, _XAMPPWebRootPath);

			listViewSites.Items.Clear();
			List<VhostsEntry> vhostEntries = _vhostsManager.GetVHostEntries();
			List<HostsEntry> hostsEntries = _hostsManager.GetHostsEntries();
			List<DirectoryInfo> sites = new DirectoryInfo(_XAMPPWebRootPath).GetDirectories("*", SearchOption.TopDirectoryOnly).ToList();

			foreach (VhostsEntry vHostEntry in vhostEntries)
			{
				if (hostsEntries.Count(p => p.DomainName == vHostEntry.ServerName) > 0 ||
					sites.Count(p => p.Name == vHostEntry.ServerName) > 0)
				{
					ListViewItem lvi = new ListViewItem(vHostEntry.ServerName);
					lvi.SubItems.Add("OK");
					listViewSites.Items.Add(lvi);
				}
			}
		}

		private void buttonAddNewSite_Click(object sender, EventArgs e)
		{
			FormAddNewSite addSiteForm = new FormAddNewSite(_vhostsManager,_hostsManager,_XAMPPWebRootPath,_XAMPPInstallDir);
			addSiteForm.ShowDialog(this);
			BuildExistingSiteList();
		}

		private void buttonSelectXAMPPInstallDir_Click(object sender, EventArgs e)
		{
			OpenFileDialog fod = new OpenFileDialog();
			fod.ValidateNames = false;
			fod.CheckFileExists = false;
			fod.CheckPathExists = true;
			// Always default to Folder Selection.
			fod.FileName = "Folder Selection";
			fod.ShowDialog(this);
			textBoxXAMPPInstallDir.Text = new FileInfo(fod.FileName).DirectoryName;
			ConfigManager.SetXAMPPInstallDir(textBoxXAMPPInstallDir.Text);
			BuildExistingSiteList();
		}

		private void buttonDeleteSite_Click(object sender, EventArgs e)
		{
			if (listViewSites.SelectedIndices.Count == 0)
			{
				MessageBox.Show(this,
						"Please select item first",
						"Info",
						MessageBoxButtons.OK,
						MessageBoxIcon.Exclamation);
				return;
			}

			string siteToDelete = listViewSites.SelectedItems[0].Text;
			string sitePath = Path.Combine(_XAMPPWebRootPath, siteToDelete);


			DialogResult delSiteRes = MessageBox.Show(this,
						"Delete Site?",
						"Confirmation needed",
						MessageBoxButtons.YesNo,
						MessageBoxIcon.Question);

			if (delSiteRes == DialogResult.Yes)
			{
				if (Directory.Exists(sitePath))
				{
					DirectoryInfo dirInfo = new DirectoryInfo(sitePath);

					if (dirInfo.Exists && dirInfo.GetFiles().Length > 0 || dirInfo.GetDirectories().Length > 0)
					{
						DialogResult res = MessageBox.Show(this,
							"Site directory is not empty. Do you want to truncate all its content?",
							"Confirmation needed",
							MessageBoxButtons.YesNoCancel,
							MessageBoxIcon.Question);

						try
						{
							if (res == DialogResult.Yes)
							{
								Directory.Delete(sitePath, true);
							}
							else if (res == DialogResult.Cancel)
							{
								return;
							}
						}
						catch (Exception ex)
						{
							MessageBox.Show(this,
								"Failed to delete site\r\n\r\n" + ex.Message,
								"Error",
								MessageBoxButtons.OK,
								MessageBoxIcon.Error);
						}
					}
				}

				_vhostsManager.DeleteEntry(siteToDelete);
				_hostsManager.DeleteEntry(siteToDelete);

				MessageBox.Show(this,
					"Site deleted",
					"Confirmation",
					MessageBoxButtons.OK,
					MessageBoxIcon.Information);
			}

			BuildExistingSiteList();
		}

		private void buttonRefreshSitesList_Click(object sender, EventArgs e)
		{
			BuildExistingSiteList();
		}
	}
}
