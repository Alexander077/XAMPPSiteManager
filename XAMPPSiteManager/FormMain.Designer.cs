namespace XAMPPSiteManager
{
	partial class FormMain
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxXAMPPInstallDir = new System.Windows.Forms.TextBox();
			this.buttonAddNewSite = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.listViewSites = new System.Windows.Forms.ListView();
			this.columnHeaderSiteName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.buttonDeleteSite = new System.Windows.Forms.Button();
			this.buttonSelectXAMPPInstallDir = new System.Windows.Forms.Button();
			this.buttonRefreshSitesList = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 30);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(121, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "XAMMP install directory:";
			// 
			// textBoxXAMPPInstallDir
			// 
			this.textBoxXAMPPInstallDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxXAMPPInstallDir.Location = new System.Drawing.Point(137, 27);
			this.textBoxXAMPPInstallDir.Name = "textBoxXAMPPInstallDir";
			this.textBoxXAMPPInstallDir.ReadOnly = true;
			this.textBoxXAMPPInstallDir.Size = new System.Drawing.Size(249, 20);
			this.textBoxXAMPPInstallDir.TabIndex = 1;
			this.textBoxXAMPPInstallDir.Text = "c:\\xampp\\";
			// 
			// buttonAddNewSite
			// 
			this.buttonAddNewSite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonAddNewSite.Location = new System.Drawing.Point(266, 381);
			this.buttonAddNewSite.Name = "buttonAddNewSite";
			this.buttonAddNewSite.Size = new System.Drawing.Size(75, 23);
			this.buttonAddNewSite.TabIndex = 2;
			this.buttonAddNewSite.Text = "Add new";
			this.buttonAddNewSite.UseVisualStyleBackColor = true;
			this.buttonAddNewSite.Click += new System.EventHandler(this.buttonAddNewSite_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.listViewSites);
			this.groupBox1.Location = new System.Drawing.Point(15, 70);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(407, 305);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Registered sites";
			// 
			// listViewSites
			// 
			this.listViewSites.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderSiteName,
            this.columnHeaderStatus});
			this.listViewSites.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listViewSites.FullRowSelect = true;
			this.listViewSites.Location = new System.Drawing.Point(3, 16);
			this.listViewSites.MultiSelect = false;
			this.listViewSites.Name = "listViewSites";
			this.listViewSites.Size = new System.Drawing.Size(401, 286);
			this.listViewSites.TabIndex = 0;
			this.listViewSites.UseCompatibleStateImageBehavior = false;
			this.listViewSites.View = System.Windows.Forms.View.Details;
			// 
			// columnHeaderSiteName
			// 
			this.columnHeaderSiteName.Text = "Site name";
			this.columnHeaderSiteName.Width = 187;
			// 
			// columnHeaderStatus
			// 
			this.columnHeaderStatus.Text = "Status";
			this.columnHeaderStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeaderStatus.Width = 97;
			// 
			// buttonDeleteSite
			// 
			this.buttonDeleteSite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonDeleteSite.Location = new System.Drawing.Point(347, 381);
			this.buttonDeleteSite.Name = "buttonDeleteSite";
			this.buttonDeleteSite.Size = new System.Drawing.Size(75, 23);
			this.buttonDeleteSite.TabIndex = 5;
			this.buttonDeleteSite.Text = "Delete";
			this.buttonDeleteSite.UseVisualStyleBackColor = true;
			this.buttonDeleteSite.Click += new System.EventHandler(this.buttonDeleteSite_Click);
			// 
			// buttonSelectXAMPPInstallDir
			// 
			this.buttonSelectXAMPPInstallDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSelectXAMPPInstallDir.Location = new System.Drawing.Point(392, 25);
			this.buttonSelectXAMPPInstallDir.Name = "buttonSelectXAMPPInstallDir";
			this.buttonSelectXAMPPInstallDir.Size = new System.Drawing.Size(31, 23);
			this.buttonSelectXAMPPInstallDir.TabIndex = 7;
			this.buttonSelectXAMPPInstallDir.Text = "...";
			this.buttonSelectXAMPPInstallDir.UseVisualStyleBackColor = true;
			this.buttonSelectXAMPPInstallDir.Click += new System.EventHandler(this.buttonSelectXAMPPInstallDir_Click);
			// 
			// buttonRefreshSitesList
			// 
			this.buttonRefreshSitesList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonRefreshSitesList.Location = new System.Drawing.Point(185, 381);
			this.buttonRefreshSitesList.Name = "buttonRefreshSitesList";
			this.buttonRefreshSitesList.Size = new System.Drawing.Size(75, 23);
			this.buttonRefreshSitesList.TabIndex = 8;
			this.buttonRefreshSitesList.Text = "Refresh";
			this.buttonRefreshSitesList.UseVisualStyleBackColor = true;
			this.buttonRefreshSitesList.Click += new System.EventHandler(this.buttonRefreshSitesList_Click);
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(435, 416);
			this.Controls.Add(this.buttonRefreshSitesList);
			this.Controls.Add(this.buttonSelectXAMPPInstallDir);
			this.Controls.Add(this.buttonDeleteSite);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.buttonAddNewSite);
			this.Controls.Add(this.textBoxXAMPPInstallDir);
			this.Controls.Add(this.label1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(300, 200);
			this.Name = "FormMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "XAMPP Site Manager 0.9.1b";
			this.Shown += new System.EventHandler(this.FormMain_Shown);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxXAMPPInstallDir;
		private System.Windows.Forms.Button buttonAddNewSite;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button buttonDeleteSite;
		private System.Windows.Forms.ListView listViewSites;
		private System.Windows.Forms.ColumnHeader columnHeaderSiteName;
		private System.Windows.Forms.ColumnHeader columnHeaderStatus;
		private System.Windows.Forms.Button buttonSelectXAMPPInstallDir;
		private System.Windows.Forms.Button buttonRefreshSitesList;
	}
}

